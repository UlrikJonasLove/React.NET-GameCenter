using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Services.Ratings
{
    public interface IRatingService
    {
        //Task<bool> CheckIfRatingExistAsync(int id);
        Task GetUsersGameRateByIdAsync(int id, string userId);
        Task GetAverageVoteAsync(int id);
    }
}
