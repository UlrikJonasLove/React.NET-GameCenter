using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Repositories.Users
{
    public interface IUserRepository
    {
        IQueryable<IdentityUser> GetUsersAsQueryable();
    }
}
