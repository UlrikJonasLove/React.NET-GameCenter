using GameCenter.Models.GameCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Services.GameCenter
{
    public interface IGameCenterService
    {
        IQueryable<GameCenters> GetGameCentersAsQueryable();
        Task<GameCenters> GetGameCenterByIdAsync(int id);
        void AddGameCenter(GameCenters gameCenter);
        void DeleteGameCenter(GameCenters gameCenters);
        Task SaveGameCenterAsync();
    }
}
