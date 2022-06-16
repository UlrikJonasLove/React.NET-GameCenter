using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Models.GameCenter
{
    public class GameCenterCreationDto
    {
        [Required]
        [StringLength(maximumLength: 75)]
        public string Name { get; set; }
        [Range(-90, 90)]
        public double Latitude { get; set; }
        [Range(-180, 180)]
        public double Longitude { get; set; }
    }
}
