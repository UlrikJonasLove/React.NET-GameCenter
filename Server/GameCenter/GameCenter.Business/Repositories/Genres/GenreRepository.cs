using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.Helpers;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Genre;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Repositories.Genres
{
    public class GenreRepository : ControllerBase, IGenreRepository
    {
        private readonly AppDbContext context;

        public GenreRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Genre>> GetGenresAsync(PaginationDto pagination)
        {
            var queryable = context.Genres.AsQueryable();
            await HttpContext.InsertParametersPaginationInHeader(queryable);

            return await queryable.OrderBy(x => x.Name).Paginate(pagination).ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void AddGenres(Genre genre)
        {
            context.Genres.Add(genre);
        }

        public async Task SaveGenresAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
