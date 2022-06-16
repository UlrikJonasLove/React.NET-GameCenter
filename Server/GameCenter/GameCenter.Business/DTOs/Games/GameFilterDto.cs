using GameCenter.Business.DTOs.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.DTOs.Games
{
    public class GameFilterDto
    {
        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
        public PaginationDto PaginationDto 
        { 
            get { return new PaginationDto { Page = Page, RecordsPerPage = RecordsPerPage }; }
        }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public bool NewlyReleased { get; set; }
        public bool UpcomingReleases { get; set; }
    }
}
