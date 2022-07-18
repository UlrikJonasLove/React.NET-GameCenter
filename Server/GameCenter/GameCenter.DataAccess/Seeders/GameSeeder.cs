using GameCenter.Models.Games;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Seeders
{
    public static class GameSeeder
    {
        public static void SeedGames(ModelBuilder builder) 
        {
            builder.Entity<Game>().HasData(new Game
            {
                Id = 1,
                Title = "Red Dead Redemption 2",
                Summary = "* Red Dead Redemption 2",
                ReleaseDate = new DateTime(2018, 10, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=SXvQ1nK4oxk",
                Poster = "",


            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 2,
                Title = "Red Dead Redemption",
                Summary = "* Red Dead Redemption",
                ReleaseDate = new DateTime(2011, 10, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=-o7rES_3ymA&t",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 3,
                Title = "Star Wars Jedi - Fallen Order",
                Summary = "* Star Wars Jedi - Fallen Order",
                ReleaseDate = new DateTime(2018, 5, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=0GLbwkfhYZk",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 4,
                Title = "Star Wars Jedi - Survivor",
                Summary = "* Star Wars Jedi - Survivor",
                ReleaseDate = new DateTime(2050, 5, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=f22IVaqCAdw",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 5,
                Title = "Assassins Creed - Origins",
                Summary = "* Assassins Creed - Origins",
                ReleaseDate = new DateTime(2017, 10, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=cK4iAjzAoas",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 6,
                Title = "Assassins Creed - Odyssey",
                Summary = "* Assassins Creed - Odyssey",
                ReleaseDate = new DateTime(2018, 10, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=s_SJZSAtLBA",
                Poster = "",
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 7,
                Title = "Assassins Creed - Valhalla",
                Summary = "* Assassins Creed - Valhalla",
                ReleaseDate = new DateTime(2020, 10, 26),
                NewlyReleased = true,
                Trailer = "https://www.youtube.com/watch?v=ssrNcwxALS4",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 8,
                Title = "Star Wars - Knights Of The Old Republic",
                Summary = "* Star Wars - Knights Of The Old Republic",
                ReleaseDate = new DateTime(2003, 04, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=xSbpETpkE9M",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 9,
                Title = "Star Wars - Knights Of The Old Republic II",
                Summary = "* Star Wars - Knights Of The Old Republic II",
                ReleaseDate = new DateTime(2005, 04, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=7EaTWlh-mLA",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 10,
                Title = "Elden Ring",
                Summary = "* Elden Ring",
                ReleaseDate = new DateTime(2022, 01, 26),
                NewlyReleased = true,
                Trailer = "https://www.youtube.com/watch?v=E3Huy2cdih0",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 11,
                Title = "The Witcher",
                ReleaseDate = new DateTime(2007, 10, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=w2F_Ti_6E_k",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 12,
                Title = "The Witcher 2 - Assassins Of Kings",
                Summary = "* The Witcher 2 - Assassins Of Kings",
                ReleaseDate = new DateTime(2011, 10, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=WwCXw8m0PHI",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 13,
                Title = "The Witcher 3 - Wild Hunt",
                Summary = "* The Witcher 3 - Wild Hunt",
                ReleaseDate = new DateTime(2015, 05, 26),
                NewlyReleased = false,
                Trailer = "https://www.youtube.com/watch?v=c0i88t0Kacs",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 14,
                Title = "Cyberpunk 2077",
                Summary = "* Cyberpunk 2077",
                ReleaseDate = new DateTime(2020, 10, 26),
                NewlyReleased = true,
                Trailer = "https://www.youtube.com/watch?v=LembwKDo1Dk",
                Poster = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 15,
                Title = "Lego Star Wars - The Skywalker Saga",
                Summary = "* Lego Star Wars - The Skywalker Saga",
                ReleaseDate = new DateTime(2022, 04, 26),
                NewlyReleased = true,
                Trailer = "https://www.youtube.com/watch?v=n49TsZAwFEs"
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 16,
                Title = "The Legend Of Zelda - The Wind Waker",
                Summary = "* The Legend Of Zelda - The Wind Waker",
                ReleaseDate = new DateTime(2002, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 17,
                Title = "The Legend Of Zelda - Twilight Princess",
                Summary = "* The Legend Of Zelda - Twilight Princess",
                ReleaseDate = new DateTime(2006, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 18,
                Title = "The Legend Of Zelda - Breath Of The Wild",
                Summary = "* The Legend Of Zelda - Breath Of The Wild",
                ReleaseDate = new DateTime(2017, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 19,
                Title = "The Legend Of Zelda - Ocarina Of Time",
                Summary = "* The Legend Of Zelda - Ocarina Of Time",
                ReleaseDate = new DateTime(1997, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 20,
                Title = "The Legend Of Zelda - Majora's Mask",
                Summary = "* The Legend Of Zelda - Majora's Mask",
                ReleaseDate = new DateTime(1998, 04, 26),
                NewlyReleased = false,
                Trailer = "",
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 21,
                Title = "The Elder Scrolls III - Morrowind",
                Summary = "* The Elder Scrolls III - Morrowind",
                ReleaseDate = new DateTime(2004, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 22,
                Title = "The Elder Scrolls IV - Oblivion",
                Summary = "* The Elder Scrolls IV - Oblivion",
                ReleaseDate = new DateTime(2006, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 23,
                Title = "The Elder Scrolls V - Skyrim",
                Summary = "* The Elder Scrolls V - Skyrim",
                ReleaseDate = new DateTime(2011, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 24,
                Title = "Fallout 3",
                Summary = "* Fallout 3",
                ReleaseDate = new DateTime(2008, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 25,
                Title = "Fallout 4",
                Summary = "* Fallout 4",
                ReleaseDate = new DateTime(2015, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 26,
                Title = "Fallout - New Vegas",
                Summary = "* Fallout - New Vegas",
                ReleaseDate = new DateTime(2009, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 27,
                Title = "FarCry - Primal",
                Summary = "* FarCry - Primal",
                ReleaseDate = new DateTime(2016, 04, 26),
                NewlyReleased = false,
                Trailer = ""

            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 28,
                Title = "FarCry 4",
                Summary = "* FarCry 4",
                ReleaseDate = new DateTime(2017, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 29,
                Title = "The Last Of Us part 1",
                Summary = "* The Last Of Us part 1",
                ReleaseDate = new DateTime(2022, 04, 26),
                NewlyReleased = true,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 30,
                Title = "The Last Of us part 2",
                Summary = "* The Last Of Us part 2",
                ReleaseDate = new DateTime(2030, 04, 26),
                NewlyReleased = false,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 31,
                Title = "Little Nightmares",
                Summary = "* Little Nightmares",
                ReleaseDate = new DateTime(2018, 04, 26),
                NewlyReleased = true,
                Trailer = ""
            });
            builder.Entity<Game>().HasData(new Game
            {
                Id = 32,
                Title = "Little Nightmares 2",
                Summary = "* Little Nightmares 2",
                ReleaseDate = new DateTime(2021, 04, 26),
                NewlyReleased = true,
                Trailer = ""
            });
        }
    }
}
