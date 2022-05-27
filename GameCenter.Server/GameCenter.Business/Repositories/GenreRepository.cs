using GameCenter.DataAccess.Data;
using GameCenter.Business.Repositories.Interfaces;
using GameCenter.Models.Genre;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GameCenter.Business.Repositories
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
#pragma warning disable CS8604 // Possible null reference argument.
            return await queryable.OrderBy(x => x.Name).Paginate(pagination).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public void AddGenres(Genre genre)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            context.Genres.Add(genre);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public async Task SaveGenresAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
