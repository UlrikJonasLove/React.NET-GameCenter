using GameCenter.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Services.Games
{
    public interface IGameService
    {
        IQueryable<Game> GetGamesAsQueryable();
        Task GetUpcomingReleasesAsync(int top, DateTime today);
        Task GetNewlyReleasesAsync(int top);
        Task GetGameByIdAsync(int id);
        void AddGame(Game game);
        void DeleteGame(Game game);
        Task SaveGameAsync();
    }
}
