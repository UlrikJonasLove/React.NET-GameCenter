using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCenter.Models.Genres;

namespace GameCenter.Models.Games
{
    public class GamesGenres
    {
        public int GenreId { get; set; }
        public int GameId { get; set; }
        public Genre? Genre { get; set; }
        public Game? Game { get; set; }
    }
}
