using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.DTOs.Actors
{
    public class ActorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }
    }
}
