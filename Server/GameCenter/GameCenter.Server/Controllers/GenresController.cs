using AutoMapper;
using GameCenter.Business.DTOs.Genres;
using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.Helpers;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Genre;
using GameCenter.Server.Services.Genres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameCenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService service;
        private readonly ILogger<GenresController> logger;
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GenresController(IGenreService service, ILogger<GenresController> logger, AppDbContext context, IMapper mapper)
        {
            this.service = service;
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDto>>> Get([FromQuery] PaginationDto pagination)
        {
            var queryable = context.Genres.AsQueryable();
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
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDto model)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if(genre == null)
                return NotFound();

            genre = mapper.Map(model, genre);
            await service.SaveGenresAsync();

            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Genres.AnyAsync(x => x.Id == id);

            if (!exist)
                return NotFound();

            context.Remove(new Genre() { Id = id });
            await service.SaveGenresAsync();

            return NoContent();
        }
    }
}
