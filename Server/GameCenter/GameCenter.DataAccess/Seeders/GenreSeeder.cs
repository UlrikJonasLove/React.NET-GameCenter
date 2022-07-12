using GameCenter.Models.Genres;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Seeders
{
    public class GenreSeeder
    {
        public void SeedGenres(ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 1,
                Name = "Action"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 2,
                Name = "RPG"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 3,
                Name = "Fantasy"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 4,
                Name = "Wild West"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 5,
                Name = "Sci-fi"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 6,
                Name = "Comedy"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 7,
                Name = "Lego"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 8,
                Name = "History"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 9,
                Name = "Norse Mythology"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 10,
                Name = "Greek Mythology"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 11,
                Name = "Post-Apocolyptic"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 12,
                Name = "Platform"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = 13,
                Name = "Horror"
            });
        }
    }
}
