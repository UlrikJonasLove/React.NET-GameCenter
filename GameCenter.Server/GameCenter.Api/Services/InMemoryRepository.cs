using GameCenter.Models.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Repositories
{
    public class InMemoryRepository
    {
        private List<Genre> genres;

        public InMemoryRepository()
        {
            genres = new List<Genre>()
            {
                new Genre(){Id = 1, Name = "RPG"},
                new Genre(){Id=2, Name = "Adventure"}
            };
        }

        public List<Genre> GetAllGenres()
        {
            return genres;
        }
    }
}
