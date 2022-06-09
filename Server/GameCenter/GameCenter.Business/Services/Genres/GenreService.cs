using GameCenter.DataAccess.Repositories.Genres;
using GameCenter.Models.Genres;

namespace GameCenter.Business.Services.Genres
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository repository;
        public GenreService(IGenreRepository repository)
        {
            this.repository = repository;
        }

        public IQueryable<Genre> GetGenresAsQueryable()
        {
            return repository.GetGenresAsQueryable();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await repository.GetGenreByIdAsync(id);
        }

        public void AddGenres(Genre genre)
        {
            repository.AddGenres(genre);
        }

        public void DeleteGenres(int id)
        {
            repository.DeleteGenres(id);
        }


        public async Task SaveGenresAsync()
        {
            await repository.SaveGenresAsync();
        }
    }
}
