using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.Repositories.Genres;
using GameCenter.Models.Genre;

namespace GameCenter.Server.Services.Genres
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

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await repository.GetGenreByIdAsync(id);
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
