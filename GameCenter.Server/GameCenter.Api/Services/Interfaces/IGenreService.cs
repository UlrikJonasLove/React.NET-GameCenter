using GameCenter.Business.DTOs.Pagination;
using GameCenter.Models.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Api.Services.Interfaces
{
    public interface IGenreService
    {
        Task<List<Genre>> GetGenresAsync(PaginationDto genre);
        void AddGenres(Genre genre);



        Task SaveGenresAsync();
    }
}
