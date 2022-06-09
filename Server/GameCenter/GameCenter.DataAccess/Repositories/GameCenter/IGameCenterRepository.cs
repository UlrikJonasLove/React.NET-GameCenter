using GameCenter.Models.GameCenter;

namespace GameCenter.DataAccess.Repositories.GameCenter
{
    public interface IGameCenterRepository
    {
        IQueryable<GameCenters> GetGameCentersAsQueryable();
        Task<GameCenters> GetGameCenterByIdAsync(int id);
        void AddGameCenter(GameCenters gameCenter);
        void DeleteGameCenter(GameCenters gameCenter);
        Task SaveGameCenterAsync();
    }
}
