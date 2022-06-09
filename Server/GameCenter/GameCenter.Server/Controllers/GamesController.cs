using AutoMapper;
using GameCenter.Business.DTOs.Games;
using GameCenter.Business.Helpers.FileStorage;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Games;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameCenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorage;
        private string container = "games";

        public GamesController(AppDbContext context, IMapper mapper, IFileStorageService fileStorage)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileStorage = fileStorage;
        }

        [HttpPost]
        public async Task<ActionResult> post([FromForm] GameCreationDto gameCreation)
        {
            var game = mapper.Map<Game>(gameCreation);

            if(gameCreation.Poster != null)
            {
                game.Poster = await fileStorage.SaveFile(container, gameCreation.Poster);
            }

            AnnotateActorsOrder(game);
            context.Add(game);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private void AnnotateActorsOrder(Game game)
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
