using GameCenter.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        
        public IQueryable<IdentityUser> GetUsersAsQueryable()
        {
            return context.Users.AsQueryable();
        }
    }
}
