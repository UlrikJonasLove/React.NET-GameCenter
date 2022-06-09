using GameCenter.Models.Genres;

namespace GameCenter.DataAccess.Repositories.Genres
{
    public interface IGenreRepository
    {
        IQueryable<Genre> GetGenresAsQueryable();
        Task<Genre> GetGenreByIdAsync(int id);
        void AddGenres(Genre genre);
        void DeleteGenres(int id);
        Task SaveGenresAsync();
    }
}
