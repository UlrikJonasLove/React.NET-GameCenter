using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.DTOs.Rating
{
    public class RatingDto
    {
        [Range(1, 5)]
        public int Rating { get; set; }
        public int GameId { get; set; }
    }
}
