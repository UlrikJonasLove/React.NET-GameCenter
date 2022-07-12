using GameCenter.DataAccess.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public IQueryable<IdentityUser> GetUsersAsQueryable()
        {
            return repository.GetUsersAsQueryable();
        }
    }
}
