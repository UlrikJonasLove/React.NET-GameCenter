using GameCenter.DataAccess.Repositories.Games;
using GameCenter.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Services.Games
{
    public class GameService : IGameService
    {
        private readonly IGameRepository repository;

        public GameService(IGameRepository repository)
        {
            this.repository = repository;
        }

        public IQueryable<Game> GetGamesAsQueryable()
        {
            return repository.GetGamesAsQueryable();
        }

        public async Task GetUpcomingReleasesAsync(int top, DateTime today)
        {
            await repository.GetUpcomingReleasesAsync(top, today);
        }
        
        public async Task GetNewlyReleasesAsync(int top)
        {
            await repository.GetNewlyReleasesAsync(top);
        }

        public async Task GetGameByIdAsync(int id)
        {
            await repository.GetGameByIdAsync(id);
        }
        public void AddGame(Game game)
        {
            repository.AddGame(game);
        }
        
        public void DeleteGame(Game game)
        {
            repository.DeleteGame(game);
        }

        public async Task SaveGameAsync()
        {
            await repository.SaveGameAsync();
        }
    }
}
