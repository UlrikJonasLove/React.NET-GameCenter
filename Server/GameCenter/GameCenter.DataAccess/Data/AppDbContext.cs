using GameCenter.Models.Actors;
using GameCenter.Models.Genres;
using GameCenter.Models.GameCenter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCenter.Models.Games;

namespace GameCenter.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AppDbContext([NotNull] DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GamesActors>()
                .HasKey(x => new { x.ActorId, x.GameId });

            builder.Entity<GamesGenres>()
                .HasKey(x => new { x.GenreId, x.GameId });

            builder.Entity<GameCentersGames>()
                .HasKey(x => new { x.GameCenterId, x.GameId });

            base.OnModelCreating(builder);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<GameCenters> GameCenters { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamesActors> GamesActors { get; set; }
        public DbSet<GamesGenres> GamesGenres { get; set; }
        public DbSet<GameCentersGames> GameCentersGames { get; set; }
    }
}
