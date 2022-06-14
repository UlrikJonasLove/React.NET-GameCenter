using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.DTOs.Games
{
    public class GameLandingPageDto
    {
        public List<GameDto>? NewlyReleased { get; set; }
        public List<GameDto>? UpcomingReleases { get; set; }
    }
}
