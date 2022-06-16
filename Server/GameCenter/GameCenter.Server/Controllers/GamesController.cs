using AutoMapper;
using GameCenter.Business.DTOs.GameCenters;
using GameCenter.Business.DTOs.Games;
using GameCenter.Business.DTOs.Genres;
using GameCenter.Business.Helpers;
using GameCenter.Business.Helpers.FileStorage;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorage;
        private string containerName = "games";

        public GamesController(AppDbContext context, IMapper mapper, IFileStorageService fileStorage)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileStorage = fileStorage;
        }

        [HttpGet]
        public async Task<ActionResult<GameLandingPageDto>> Get()
        {
            var top = 6;
            var today = DateTime.Today;

            var upcomingReleases = await context.Games
                .Where(x => x.ReleaseDate > today)
                .OrderBy(x => x.ReleaseDate)
                .Take(top)
                .ToListAsync();

            var newlyReleases = await context.Games
                .Where(x => x.NewlyReleased)
                .OrderBy(x => x.ReleaseDate)
                .Take(top)
                .ToListAsync();

            var landingPageDto = new GameLandingPageDto();
            landingPageDto.UpcomingReleases = mapper.Map<List<GameDto>>(upcomingReleases);
            landingPageDto.NewlyReleased = mapper.Map<List<GameDto>>(newlyReleases);

            return landingPageDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GameDto>> Get(int id)
        {
            var game = await context.Games
                .Include(x => x.GamesGenres).ThenInclude(x => x.Genre)
                .Include(x => x.GameCentersGame).ThenInclude(x => x.GameCenter)
                .Include(x => x.GamesActors).ThenInclude(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (game == null)
            {
                return NotFound();
            }
                

            var dto = mapper.Map<GameDto>(game);
            dto.Actors = dto.Actors.OrderBy(x => x.Order).ToList();

            return dto;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<GameDto>>> Filter([FromQuery] GameFilterDto gameFilter)
        {
            var gamesQueryable = context.Games.AsQueryable();

            if (!string.IsNullOrEmpty(gameFilter.Title))
            {
                gamesQueryable = gamesQueryable.Where(x => x.Title.Contains(gameFilter.Title));
            }

            if(gameFilter.NewlyReleased)
            {
                gamesQueryable = gamesQueryable.Where(x => x.NewlyReleased);
            }

            if (gameFilter.UpcomingReleases)
            {
                var today = DateTime.Today;
                gamesQueryable = gamesQueryable.Where(x => x.ReleaseDate > today);
            }

            if(gameFilter.GenreId != 0)
            {
                gamesQueryable = gamesQueryable
                    .Where(x => x.GamesGenres.Select(y => y.GenreId)
                    .Contains(gameFilter.GenreId));
            }

            await HttpContext.InsertParametersPaginationInHeader(gamesQueryable);
            var games = await gamesQueryable
                .OrderBy(x => x.Title)
                .Paginate(gameFilter.PaginationDto)
                .ToListAsync();

            return mapper.Map<List<GameDto>>(games);
        }

        [HttpGet("postget")]
        public async Task<ActionResult<GamePostGetDto>> PostGet()
        {
            var gameCenter = await context.GameCenters.ToListAsync();
            var genres = await context.Genres.ToListAsync();

            var gameCenterDto = mapper.Map<List<GameCenterDto>>(gameCenter);
            var genresDto = mapper.Map<List<GenreDto>>(genres);

            return new GamePostGetDto() { Genres = genresDto, GameCenter = gameCenterDto };
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromForm] GameCreationDto gameCreation)
        {
            var game = mapper.Map<Game>(gameCreation);

            if(gameCreation.Poster != null)
            {
                game.Poster = await fileStorage.SaveFile($"{containerName}/{gameCreation.Title}", gameCreation.Poster);
            }

            AnnotateActorsOrder(game);
            context.Add(game);
            await context.SaveChangesAsync();

            return game.Id;
        }

        [HttpGet("putget/{id:int}")]
        public async Task<ActionResult<GamePutGetDto>> PutGet(int id)
        {
            var gameActionResult = await Get(id);
            if (gameActionResult.Result is NotFoundResult)
            {
                return NotFound();
            }
               
            var game = gameActionResult.Value;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var genreSelectedIds = game.Genres.Select(x => x.Id).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var nonSelectedGenres = await context.Genres.Where(x => !genreSelectedIds.Contains(x.Id)).ToListAsync();

            var gameCentersIds = game.GameCenters.Select(x => x.Id).ToList();
            var nonSelectedGameCenters = await context.GameCenters.Where(x => !gameCentersIds.Contains(x.Id)).ToListAsync();

            var nonSelectedGenresDtos = mapper.Map<List<GenreDto>>(nonSelectedGenres);
            var nonSelectedGameCentersDtos = mapper.Map<List<GameCenterDto>>(nonSelectedGameCenters);

            var response = new GamePutGetDto();
            response.Game = game;
            response.SelectedGenres = game.Genres;
            response.NonSelectedGenres = nonSelectedGenresDtos;
            response.SelectedGameCenters = game.GameCenters;
            response.NonSelectedGameCenters = nonSelectedGameCentersDtos;
            response.Actors = game.Actors;

            return response;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] GameCreationDto gameCreation)
        {
            var game = await context.Games.Include(x => x.GamesActors)
                .Include(x => x.GamesGenres)
                .Include(x => x.GameCentersGame)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (game == null)
                return NotFound();

            game = mapper.Map(gameCreation, game);

            if (gameCreation.Poster != null)
            {
                game.Poster = await fileStorage.EditFile($"{containerName}/{gameCreation.Title}", gameCreation.Poster, game.Poster);
            }
                

            AnnotateActorsOrder(game);

            await context.SaveChangesAsync();
            return NoContent();
        }

        private static void AnnotateActorsOrder(Game game)
        {
            if(game.GamesActors != null)
            {
                for(int i = 0; i < game.GamesActors.Count; i++)
                {
                    game.GamesActors[i].Order = i;
                }
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var game = await context.Games.FirstOrDefaultAsync(x => x.Id == id);

            if (game == null)
                return NotFound();

            context.Remove(game);
            await context.SaveChangesAsync();
            await fileStorage.DeleteFile(game.Poster, containerName);

            return NoContent();
        }
    }
}
