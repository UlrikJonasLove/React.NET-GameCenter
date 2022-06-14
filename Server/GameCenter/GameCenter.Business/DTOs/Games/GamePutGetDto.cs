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
    public class GamePutGetDto
    {
        public GameDto? Game { get; set; }
        public List<GenreDto>? SelectedGenres { get; set; }
        public List<GenreDto>? NonSelectedGenres { get; set; }
        public List<GameCenterDto>? SelectedGameCenters { get; set; }
        public List<GameCenterDto>? NonSelectedGameCenters { get; set; }
        public List<ActorsGameDto>? Actors { get; set; }
    }
}
