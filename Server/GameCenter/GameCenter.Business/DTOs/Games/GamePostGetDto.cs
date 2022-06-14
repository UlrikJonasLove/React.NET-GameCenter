using GameCenter.Business.DTOs.GameCenters;
using GameCenter.Business.DTOs.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.DTOs.Games
{
    public class GamePostGetDto
    {
        public List<GenreDto>? Genres { get; set; }
        public List<GameCenterDto>? GameCenter { get; set; }
    }
}
