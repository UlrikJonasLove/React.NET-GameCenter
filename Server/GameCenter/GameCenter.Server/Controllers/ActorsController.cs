using AutoMapper;
using GameCenter.Business.DTOs.Actors;
using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.Helpers;
using GameCenter.Business.Helpers.FileStorage;
using GameCenter.Business.Services.Actors;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Actors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class ActorsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorage;
        private readonly IActorService service;
        private readonly AppDbContext context;
        private readonly string containerName = "actors";

        public ActorsController(IMapper mapper, IFileStorageService fileStorage, IActorService service, AppDbContext context)
        {
            this.mapper = mapper;
            this.fileStorage = fileStorage;
            this.service = service;
            this.context = context;
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

        [HttpGet("searchByName/{query}")]
        public async Task<ActionResult<List<ActorsGameDto>>> SearchByName(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<ActorsGameDto>();

            return await context.Actors
                .Where(x => x.Name.Contains(query))
                .OrderBy(x => x.Name)
                .Select(x => new ActorsGameDto { Id = x.Id, Name = x.Name, Picture = x.Picture })
                .Take(5)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreationDto actorCreation)
        {
            var actor = mapper.Map<Actor>(actorCreation);
            if(actorCreation.Picture != null) 
            {
                actor.Picture = await fileStorage.SaveFile($"{containerName}/{actor.Name}", actorCreation.Picture);
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
                actor.Picture = await fileStorage.EditFile($"{containerName}/{actor.Name}", actorCreation.Picture, actor.Picture);
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
            await fileStorage.DeleteFile(actor.Picture, containerName);

            return NoContent();
        }
    }
}
