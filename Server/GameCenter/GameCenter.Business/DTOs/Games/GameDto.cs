using GameCenter.Business.DTOs.Actors;
using GameCenter.Business.DTOs.GameCenters;
using GameCenter.Business.DTOs.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.DTOs.Games
{
    public class GameDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Trailer { get; set; }
        public bool? NewlyReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Poster { get; set; }
        public List<GenreDto>? Genres { get; set; }
        public List<GameCenterDto>? GameCenters { get; set; }
        public List<ActorsGameDto>? Actors { get; set; }
    }
}
