using GameCenter.Models.Games;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Models.Rating
{
    public class Rating
    {
        public int Id { get; set; }
        [Range(1, 5)]
        public int Rate { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
