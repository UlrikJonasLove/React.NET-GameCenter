using GameCenter.DataAccess.Repositories.GameCenter;
using GameCenter.Models.GameCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Services.GameCenter
{
    public class GameCenterService : IGameCenterService
    {
        private readonly IGameCenterRepository repository;
        public GameCenterService(IGameCenterRepository repository)
        {
            this.repository = repository;
        }

        public IQueryable<GameCenters> GetGameCentersAsQueryable()
        {
            return repository.GetGameCentersAsQueryable();
        }

        public async Task<GameCenters> GetGameCenterByIdAsync(int id)
        {
            return await repository.GetGameCenterByIdAsync(id);
        }

        public void AddGameCenter(GameCenters gameCenter)
        {
            repository.AddGameCenter(gameCenter);
        }

        public void DeleteGameCenter(GameCenters gameCenter)
        {
            repository.DeleteGameCenter(gameCenter);
        }

        public async Task SaveGameCenterAsync()
        {
            await repository.SaveGameCenterAsync();
        }
    }
}
