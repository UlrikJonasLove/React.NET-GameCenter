using GameCenter.Models.Games;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Seeders
{
    public static class GamesActorsSeeder
    {
        public static void SeedGamesActors(ModelBuilder builder)
        {
            for (var i = 0; i <= 32; i++)
            {
                builder.Entity<GamesActors>().HasData(new GamesActors
                {
                    GameId = i,
                    ActorId = 1,
                    Character = "Programmer / Director",
                    Order = 1
                });
            }
            builder.Entity<GamesActors>().HasData(new GamesActors
            {
                GameId = 1,
                ActorId = 5,
                Character = "Arthur Morgan",
                Order = 2
            });
            builder.Entity<GamesActors>().HasData(new GamesActors
            {
                GameId = 1,
                ActorId = 6,
                Character = "John Marston",
                Order = 3
            });
            builder.Entity<GamesActors>().HasData(new GamesActors
            {
                GameId = 2,
                ActorId = 6,
                Character = "John Marston",
                Order = 2
            });
            builder.Entity<GamesActors>().HasData(new GamesActors
            {
                GameId = 6,
                ActorId = 4,
                Character = "Alexios",
                Order = 2
            });
            builder.Entity<GamesActors>().HasData(new GamesActors
            {
                GameId = 7,
                ActorId = 3,
                Character = "Eivor wolf-kissed",
                Order = 2
            });
            builder.Entity<GamesActors>().HasData(new GamesActors
            {
                GameId = 11,
                ActorId = 7,
                Character = "Geralt of Rivia",
                Order = 2
            });
            builder.Entity<GamesActors>().HasData(new GamesActors
            {
                GameId = 12,
                ActorId = 7,
                Character = "Geralt of Rivia",
                Order = 2
            });
            builder.Entity<GamesActors>().HasData(new GamesActors
            {
                GameId = 13,
                ActorId = 7,
                Character = "Geralt of Rivia",
                Order = 2
            });
            builder.Entity<GamesActors>().HasData(new GamesActors
            {
                GameId = 31,
                ActorId = 2,
                Character = "Six",
                Order = 2
            });
            builder.Entity<GamesActors>().HasData(new GamesActors
            {
                GameId = 32,
                ActorId = 2,
                Character = "Six / Mono",
                Order = 2
            });
        }
    }
}
