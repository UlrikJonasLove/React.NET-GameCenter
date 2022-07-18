using GameCenter.Models.Games;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Seeders
{
    public static class GamesGenresSeeder
    {
        public static void SeedGamesGenres(ModelBuilder builder)
        {
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 1,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 1,
                GenreId = 4
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 1,
                GenreId = 8
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 2,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 2,
                GenreId = 4
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 2,
                GenreId = 8
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 3,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 3,
                GenreId = 5
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 4,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 4,
                GenreId = 5
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 5,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 5,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 5,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 5,
                GenreId = 8
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 6,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 6,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 6,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 6,
                GenreId = 8
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 6,
                GenreId = 10
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 7,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 7,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 7,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 7,
                GenreId = 8
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 7,
                GenreId = 9
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 8,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 8,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 8,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 8,
                GenreId = 5
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 9,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 9,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 9,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 9,
                GenreId = 5
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 10,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 10,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 10,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 10,
                GenreId = 13
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 11,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 11,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 11,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 12,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 12,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 12,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 13,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 13,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 13,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 14,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 14,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 14,
                GenreId = 5
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 15,
                GenreId = 5
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 15,
                GenreId = 6
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 15,
                GenreId = 7
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 15,
                GenreId = 12
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 16,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 16,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 17,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 17,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 18,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 18,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 19,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 19,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 20,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 20,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 21,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 21,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 21,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 22,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 22,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 22,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 23,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 23,
                GenreId = 2
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 23,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 24,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 24,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 24,
                GenreId = 5
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 24,
                GenreId = 11
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 25,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 25,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 25,
                GenreId = 5
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 25,
                GenreId = 11
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 26,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 26,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 26,
                GenreId = 5
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 26,
                GenreId = 11
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 27,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 27,
                GenreId = 8
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 28,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 29,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 29,
                GenreId = 11
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 29,
                GenreId = 13
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 30,
                GenreId = 1
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 30,
                GenreId = 11
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 30,
                GenreId = 13
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 31,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 31,
                GenreId = 12
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 31,
                GenreId = 13
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 32,
                GenreId = 3
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 32,
                GenreId = 12
            });
            builder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 32,
                GenreId = 13
            });
        }
    }
}
