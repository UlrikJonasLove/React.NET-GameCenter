using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.DTOs.Pagination
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        private int recordsPerPage = 10;
        private readonly int totalRecordsPerPage = 50;

        public int RecordsPerPage
        {
            get
            {
                return recordsPerPage;
            }
            set
            {
                recordsPerPage = (value > totalRecordsPerPage) ? totalRecordsPerPage : value;
            }
        }
    }
}
