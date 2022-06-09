using AutoMapper;
using GameCenter.Business.DTOs.Actors;
using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.Helpers;
using GameCenter.Business.Helpers.FileStorage;
using GameCenter.Business.Services.Actors;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Actors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameCenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorage;
        private readonly IActorService service;
        private readonly string containerName = "actors";

        public ActorsController(IMapper mapper, IFileStorageService fileStorage, IActorService service)
        {
            this.mapper = mapper;
            this.fileStorage = fileStorage;
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDto>>> Get([FromQuery] PaginationDto pagination)
        {
            var queryable = service.GetActorsAsQueryable();
            await HttpContext.InsertParametersPaginationInHeader(queryable);
            var actors = await queryable.OrderBy(x => x.Name).Paginate(pagination).ToListAsync();
            return mapper.Map<List<ActorDto>>(actors);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActorDto>> Get(int id)
        {
            var actor = await service.GetActorByIdAsync(id);

            if(actor == null)
            {
                return NotFound();
            }

            return mapper.Map<ActorDto>(actor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreationDto actorCreation)
        {
            var actor = mapper.Map<Actor>(actorCreation);
            if(actorCreation.Picture != null) 
            {
                actor.Picture = await fileStorage.SaveFile(containerName, actorCreation.Picture);
            }

            service.AddActor(actor);
            await service.SaveActorAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] ActorCreationDto actorCreation)
        {
            var actor = await service.GetActorByIdAsync(id);

            if (actor == null)
                return NotFound();

            actor = mapper.Map(actorCreation, actor);

            if(actorCreation.Picture != null)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                actor.Picture = await fileStorage.EditFile(containerName, actorCreation.Picture, actor.Picture);
#pragma warning restore CS8604 // Possible null reference argument.
            }

            await service.SaveActorAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var actor = await service.GetActorByIdAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            service.DeleteActor(actor);
            await service.SaveActorAsync();
#pragma warning disable CS8604 // Possible null reference argument.
            await fileStorage.DeleteFile(actor.Picture, containerName);
#pragma warning restore CS8604 // Possible null reference argument.
            return NoContent();
        }

    }
}
