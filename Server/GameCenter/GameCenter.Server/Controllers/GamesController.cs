using AutoMapper;
using GameCenter.Business.DTOs.GameCenters;
using GameCenter.Business.DTOs.Games;
using GameCenter.Business.DTOs.Genres;
using GameCenter.Business.Helpers;
using GameCenter.Business.Helpers.FileStorage;
using GameCenter.Business.Services.Games;
using GameCenter.Business.Services.Ratings;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Games;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IGameService gameService;
        private readonly IRatingService ratingService;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorage;
        private readonly UserManager<IdentityUser> userManager;
        private string containerName = "games";

        public GamesController(AppDbContext context, IGameService gameService, IRatingService ratingService,
            IMapper mapper, 
            IFileStorageService fileStorage, 
            UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.gameService = gameService;
            this.ratingService = ratingService;
            this.mapper = mapper;
            this.fileStorage = fileStorage;
            this.userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
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

            var averageVote = 0.0;
            var userVote = 0;
               
            if(await context.Ratings.AnyAsync(x => x.GameId == id))
            {
                averageVote = await context.Ratings.Where(x => x.GameId == id)
                    .AverageAsync(x => x.Rate);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
                    var user = await userManager.FindByEmailAsync(email);
                    var userId = user.Id;

                    var ratingDb = await context.Ratings.FirstOrDefaultAsync(x => x.GameId == id && x.UserId == userId);


                    if(ratingDb != null)
                    {
                        userVote = ratingDb.Rate;
                    }
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            var dto = mapper.Map<GameDto>(game);
            dto.AverageVote = averageVote;
            dto.UserVote = userVote;
            dto.Actors = dto.Actors.OrderBy(x => x.Order).ToList();

            return dto;
        }

        [HttpGet("filter")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GameDto>>> Filter([FromQuery] GameFilterDto gameFilter)
        {
            var gamesQueryable = gameService.GetGamesAsQueryable();

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
                game.Poster = await fileStorage.SaveFile($"{containerName}/{game.Title}", gameCreation.Poster);
            }

            AnnotateActorsOrder(game);
            gameService.AddGame(game);
            await gameService.SaveGameAsync();

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
                game.Poster = await fileStorage.EditFile($"{containerName}/{game.Title}", gameCreation.Poster, game.Poster);
            }
                

            AnnotateActorsOrder(game);

            await gameService.SaveGameAsync();
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

            gameService.DeleteGame(game);
            await context.SaveChangesAsync();
            await fileStorage.DeleteFile(game.Poster, $"{containerName}/{game.Title}");

            return NoContent();
        }
    }
}