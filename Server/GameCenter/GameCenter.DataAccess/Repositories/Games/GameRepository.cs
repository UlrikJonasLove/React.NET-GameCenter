using GameCenter.DataAccess.Data;
using GameCenter.Models.Games;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Repositories.Games
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext context;

        public GameRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Game> GetGamesAsQueryable()
        {
            return context.Games.AsQueryable();
        }

        public async Task<List<Game>> GetUpcomingReleasesAsync(int top, DateTime today)
        {
            return await context.Games
                .Where(x => x.ReleaseDate > today)
                .OrderBy(x => x.ReleaseDate)
                .Take(top)
                .ToListAsync();
        }

        public async Task<List<Game>> GetNewlyReleasesAsync(int top)
        {
            return await context.Games
                .Where(x => x.NewlyReleased)
                .OrderBy(x => x.ReleaseDate)
                .Take(top)
                .ToListAsync();
        }      
        
        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await context.Games
                .Include(x => x.GamesGenres).ThenInclude(x => x.Genre)
                .Include(x => x.GameCentersGame).ThenInclude(x => x.GameCenter)
                .Include(x => x.GamesActors).ThenInclude(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void AddGame(Game game)
        {
            context.Games.Add(game);
        }

        public void DeleteGame(Game game)
        {
            context.Remove(game);
        }

        public async Task SaveGameAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
