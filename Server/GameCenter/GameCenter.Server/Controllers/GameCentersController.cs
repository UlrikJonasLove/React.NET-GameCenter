using AutoMapper;
using GameCenter.Business.DTOs.GameCenters;
using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.Helpers;
using GameCenter.Business.Services.GameCenter;
using GameCenter.DataAccess.Data;
using GameCenter.Models.GameCenter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCentersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IGameCenterService service;

        public GameCentersController(IMapper mapper, IGameCenterService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GameCenterDto>>> Get([FromQuery] PaginationDto pagination)
        {
            var queryable = service.GetGameCentersAsQueryable();
            await HttpContext.InsertParametersPaginationInHeader(queryable);

            var gameCenters = await queryable.OrderBy(x => x.Name).Paginate(pagination).ToListAsync();
            return mapper.Map<List<GameCenterDto>>(gameCenters);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GameCenterDto>> Get(int id)
        {
            var gameCenter = await service.GetGameCenterByIdAsync(id);
            if (gameCenter == null)
                return NotFound();

            return mapper.Map<GameCenterDto>(gameCenter);
        }

        [HttpPost]
        public async Task<ActionResult> Post(GameCenterCreationDto gameCenterCreation)
        {
            var gameCenter = mapper.Map<GameCenters>(gameCenterCreation);
            service.AddGameCenter(gameCenter);
            await service.SaveGameCenterAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GameCenterCreationDto gameCenterCreation)
        {
            var gameCenter = await service.GetGameCenterByIdAsync(id);
            if (gameCenter == null)
                return NotFound();

            gameCenter = mapper.Map(gameCenterCreation, gameCenter);
            await service.SaveGameCenterAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var gameCenter = await service.GetGameCenterByIdAsync(id);
            if (gameCenter == null)
                return NotFound();

            service.DeleteGameCenter(gameCenter);
            await service.SaveGameCenterAsync();

            return NoContent();
        }
    }
}
