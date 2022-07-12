using GameCenter.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Repositories.Ratings
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext context;

        public RatingRepository(AppDbContext context)
        {
            this.context = context;
        }
        //public bool CheckIfRatingExistAsync(int id)
        //{
        //    return context.Ratings.AnyAsync(x => x.GameId == id);
        //}

        public async Task GetUsersGameRateByIdAsync(int id, string userId)
        {
            await context.Ratings.FirstOrDefaultAsync(x => x.GameId == id && x.UserId == userId);
        }

        public async Task GetAverageVoteAsync(int id)
        {
            await context.Ratings.Where(x => x.GameId == id)
                    .AverageAsync(x => x.Rate);
        }
    }
}
