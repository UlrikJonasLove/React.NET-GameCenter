using GameCenter.DataAccess.Data;
using GameCenter.Models.Genres;
using Microsoft.EntityFrameworkCore;

namespace GameCenter.DataAccess.Repositories.Genres
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext context;

        public GenreRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Genre> GetGenresAsQueryable()
        {
            return context.Genres.AsQueryable();
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

        public void DeleteGenres(int id)
        {
            context.Remove(new Genre() { Id = id });
        }

        public async Task SaveGenresAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
