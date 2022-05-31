using GameCenter.Business.DTOs.Pagination;
using GameCenter.Models.Genre;

namespace GameCenter.Server.Services.Genres
{
    public interface IGenreService
    {
        Task<List<Genre>> GetGenresAsync(PaginationDto genre);
        Task<Genre> GetGenreByIdAsync(int id);
        void AddGenres(Genre genre);



        Task SaveGenresAsync();
    }
}
