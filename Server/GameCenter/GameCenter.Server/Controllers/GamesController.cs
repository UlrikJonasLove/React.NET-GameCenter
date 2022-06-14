using AutoMapper;
using GameCenter.Business.DTOs.GameCenters;
using GameCenter.Business.DTOs.Games;
using GameCenter.Business.DTOs.Genres;
using GameCenter.Business.Helpers.FileStorage;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Games;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            var game = await context.Games
                .Include(x => x.GamesGenres).ThenInclude(x => x.Genre)
                .Include(x => x.GameCentersGame).ThenInclude(x => x.GameCenter)
                .Include(x => x.GamesActors).ThenInclude(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

            if (game == null)
                return NotFound();

            var dto = mapper.Map<GameDto>(game);
#pragma warning disable CS8604 // Possible null reference argument.
            dto.Actors = dto.Actors.OrderBy(x => x.Order).ToList();
#pragma warning restore CS8604 // Possible null reference argument.

            return dto;
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
                return NotFound();

            var game = gameActionResult.Value;

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var genreSelectedIds = game.Genres.Select(x => x.Id).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.
            var nonSelectedGenres = await context.Genres.Where(x => !genreSelectedIds.Contains(x.Id)).ToListAsync();

#pragma warning disable CS8604 // Possible null reference argument.
            var gameCentersIds = game.GameCenters.Select(x => x.Id).ToList();
#pragma warning restore CS8604 // Possible null reference argument.
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
#pragma warning disable CS8604 // Possible null reference argument.
                game.Poster = await fileStorage.EditFile($"{containerName}/{gameCreation.Title}", gameCreation.Poster, game.Poster);
#pragma warning restore CS8604 // Possible null reference argument.

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
    }
}
