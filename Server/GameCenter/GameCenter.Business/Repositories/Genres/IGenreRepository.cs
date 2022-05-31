using GameCenter.Business.DTOs.Pagination;
using GameCenter.Models.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Repositories.Genres
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetGenresAsync(PaginationDto pagination);
        Task<Genre> GetGenreByIdAsync(int id);
        void AddGenres(Genre genre);



        Task SaveGenresAsync();
    }
}
