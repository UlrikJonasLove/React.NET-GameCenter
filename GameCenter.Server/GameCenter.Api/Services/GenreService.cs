using GameCenter.Api.Services.Interfaces;
using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.Repositories.Interfaces;
using GameCenter.Models.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Api.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository repository;
        public GenreService(IGenreRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Genre>> GetGenresAsync(PaginationDto pagination)
        {
            return await repository.GetGenresAsync(pagination);
        }

        public void AddGenres(Genre genre)
        {
            repository.AddGenres(genre);
        }


        public async Task SaveGenresAsync()
        {
            await repository.SaveGenresAsync();
        }
    }
}
