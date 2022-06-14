using GameCenter.Models.Actors;
using GameCenter.Models.GameCenter;
using GameCenter.Models.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Models.Games
{
    public class Game
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 75)]
        [Required]
        public string? Title { get; set; }
        public string? Trailer { get; set; }
        public bool NewlyReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Poster { get; set; }
        public List<GamesGenres>? GamesGenres { get; set; }
        public List<GameCentersGames>? GameCentersGame { get; set; }
        public List<GamesActors>? GamesActors { get; set; }
    }
}
