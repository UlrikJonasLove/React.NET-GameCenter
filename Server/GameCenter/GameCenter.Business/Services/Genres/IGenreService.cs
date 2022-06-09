using GameCenter.Business.DTOs.Pagination;
using GameCenter.Models.Genres;

namespace GameCenter.Business.Services.Genres
{
    public interface IGenreService
    {
        IQueryable<Genre> GetGenresAsQueryable();
        Task<Genre> GetGenreByIdAsync(int id);
        void AddGenres(Genre genre);
        void DeleteGenres(int id);
        Task SaveGenresAsync();
    }
}
