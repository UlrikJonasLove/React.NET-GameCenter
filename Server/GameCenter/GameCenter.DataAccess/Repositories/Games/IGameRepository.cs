using GameCenter.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Repositories.Games
{
    public interface IGameRepository
    {
        IQueryable<Game> GetGamesAsQueryable();
        Task<List<Game>> GetUpcomingReleasesAsync(int top, DateTime today);
        Task<List<Game>> GetNewlyReleasesAsync(int top);
        Task<Game> GetGameByIdAsync(int id);
        void AddGame(Game game);
        void DeleteGame(Game game);
        Task SaveGameAsync();
    }
}
