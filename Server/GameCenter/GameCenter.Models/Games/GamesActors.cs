using GameCenter.Models.Actors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Models.Games
{
    public class GamesActors
    {
        public int ActorId { get; set; }
        public int GameId { get; set; }
        [StringLength(maximumLength: 75)]
        public string Character { get; set; }
        public int Order { get; set; }
        public Actor Actor { get; set; }
        public Game Game { get; set; }
    }
}
