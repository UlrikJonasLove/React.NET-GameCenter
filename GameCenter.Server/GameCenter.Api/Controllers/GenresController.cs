using AutoMapper;
using GameCenter.Business.DTOs.Genres;
using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.Helpers;
using GameCenter.Api.Services.Interfaces;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Genre;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameCenter.Api.Controllers
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
            var genres = await queryable.OrderBy(x => x.Name).ToListAsync();
            return mapper.Map<List<GenreDto>>(genres);
        }

        [HttpGet("{Id:Int}", Name = "getGenre")]
        public ActionResult<Genre> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDto genreCreation)
        {
            var genre = mapper.Map<Genre>(genreCreation);
            service.AddGenres(genre);
            await service.SaveGenresAsync();

            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] GenreCreationDto genre)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
