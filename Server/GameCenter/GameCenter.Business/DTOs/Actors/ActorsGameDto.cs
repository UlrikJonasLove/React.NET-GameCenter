using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.DTOs.Actors
{
    public class ActorsGameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
    }
}
