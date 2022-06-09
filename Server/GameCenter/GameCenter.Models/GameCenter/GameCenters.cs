using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Models.GameCenter
{
    public class GameCenters
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 75)]
        public string? Name { get; set; }
        public Point? Location { get; set; }
    }
}
