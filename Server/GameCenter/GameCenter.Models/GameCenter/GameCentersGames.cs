using GameCenter.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Models.GameCenter
{
    public class GameCentersGames
    {
        public int GameCenterId { get; set; }
        public int GameId { get; set; }
        public GameCenters GameCenter { get; set; }
        public Game Game { get; set; }
    }
}
