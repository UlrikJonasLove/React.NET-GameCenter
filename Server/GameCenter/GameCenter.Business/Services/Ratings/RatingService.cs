using GameCenter.DataAccess.Repositories.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Services.Ratings
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository repository;

        public RatingService(IRatingRepository repository)
        {
            this.repository = repository;
        }
        
        //public async Task<bool> CheckIfRatingExistAsync(int id)
        //{
        //    return await repository.CheckIfRatingExistAsync(id);
        //}
        
        public async Task GetUsersGameRateByIdAsync(int id, string userId)
        {
            await repository.GetUsersGameRateByIdAsync(id, userId);
        }
        
        public async Task GetAverageVoteAsync(int id)
        {
            await repository.GetAverageVoteAsync(id);
        }
    }
}
