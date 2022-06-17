using AutoMapper;
using GameCenter.Business.DTOs.Genres;
using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.Helpers;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Genres;
using GameCenter.Business.Services.Genres;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace GameCenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService service;
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GenresController(IGenreService service, AppDbContext context, IMapper mapper)
        {
            this.service = service;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GenreDto>>> Get()
        {
            var genres = await context.Genres.OrderBy(x => x.Name).ToListAsync();
            return mapper.Map<List<GenreDto>>(genres);
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDto>>> Get([FromQuery] PaginationDto pagination)
        {
            var queryable = service.GetGenresAsQueryable();
            await HttpContext.InsertParametersPaginationInHeader(queryable);
            var genres = await queryable.OrderBy(x => x.Name).Paginate(pagination).ToListAsync();
            return mapper.Map<List<GenreDto>>(genres);
        }

        [HttpGet("{Id:Int}")]
        public async Task<ActionResult<GenreDto>> Get(int id)
        {
            var genre = await service.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            return mapper.Map<GenreDto>(genre);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDto genreCreation)
        {
            var genre = mapper.Map<Genre>(genreCreation);
            service.AddGenres(genre);
            await service.SaveGenresAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDto genreCreation)
        {
            var genre = await service.GetGenreByIdAsync(id);
            if(genre == null)
                return NotFound();

            genre = mapper.Map(genreCreation, genre);
            await service.SaveGenresAsync();

            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Genres.AnyAsync(x => x.Id == id);

            if (!exist)
                return NotFound();

            service.DeleteGenres(id);
            await service.SaveGenresAsync();

            return NoContent();
        }
    }
}
