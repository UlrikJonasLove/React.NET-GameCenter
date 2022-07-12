using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Repositories.Ratings
{
    public interface IRatingRepository
    {
        //Task<bool> CheckIfRatingExistAsync(int id)
        Task GetUsersGameRateByIdAsync(int id, string userId);
        Task GetAverageVoteAsync(int id);
    }
}
