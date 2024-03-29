﻿using GameCenter.DataAccess.Data;
using GameCenter.Models.GameCenter;
using Microsoft.EntityFrameworkCore;

namespace GameCenter.DataAccess.Repositories.GameCenter
{
    public class GameCenterRepository : IGameCenterRepository
    {
        private readonly AppDbContext context;

        public GameCenterRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<GameCenters> GetGameCentersAsQueryable()
        {
            return context.GameCenters.AsQueryable();
        }

        public async Task<GameCenters> GetGameCenterByIdAsync(int id)
        {
            return await context.GameCenters.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void AddGameCenter(GameCenters gameCenter)
        {
            context.GameCenters.Add(gameCenter);
        }

        public void DeleteGameCenter(GameCenters gameCenter)
        {
            context.Remove(gameCenter);
        }

        public async Task SaveGameCenterAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
