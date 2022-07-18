using GameCenter.Models.Actors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Seeders
{
    public static class ActorsSeeder
    {
        public static void SeedActors(ModelBuilder builder)
        {
            builder.Entity<Actor>().HasData(new Actor
            {
                Id = 1,
                Name = "Ulrik",
                Biography = "* Ulrik",
                DateOfBirth = new DateTime(1993, 09, 30),
                Picture = ""
            });
            builder.Entity<Actor>().HasData(new Actor
            {
                Id = 2,
                Name = "Anna Moberg",
                Biography = "* Anna Moberg",
                Picture = "Images/Person/AnnaMoberg.jpg",
                DateOfBirth = new DateTime(1998, 05, 22)
            });
            builder.Entity<Actor>().HasData(new Actor
            {
                Id = 3,
                Name = "Magnus Bruun",
                Biography = "* Magnus Bruun",
                Picture = "Images/Person/MagnusBruun.jpg",
                DateOfBirth = new DateTime(1993, 10, 22)
            });
            builder.Entity<Actor>().HasData(new Actor
            {
                Id = 4,
                Name = "Michael Antonakos",
                Biography = "* Michael Antanakos",
                Picture = "Images/Person/MichaelAntonakos.jpg",
                DateOfBirth = new DateTime(1980, 10, 22)
            });
            builder.Entity<Actor>().HasData(new Actor
            {
                Id = 5,
                Name = "Roger Clark",
                Biography = "* Roger Clark",
                Picture = "Images/Person/RogerClark.jpg",
                DateOfBirth = new DateTime(1978, 10, 22)
            });
            builder.Entity<Actor>().HasData(new Actor
            {
                Id = 6,
                Name = "Rob Wiethoff",
                Biography = "* Robert Wiethoff",
                Picture = "Images/Person/RobWiethoff.jpg",
                DateOfBirth = new DateTime(1978, 10, 22)
            });
            builder.Entity<Actor>().HasData(new Actor
            {
                Id = 7,
                Name = "Doug Cockle",
                Biography = "* Doug Cockle",
                Picture = "Images/Person/DougCockle.jpg",
                DateOfBirth = new DateTime(1978, 10, 22)
            });
        }
    }
}
