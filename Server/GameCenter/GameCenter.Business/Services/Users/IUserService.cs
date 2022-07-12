using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Services.Users
{
    public interface IUserService
    {
        IQueryable<IdentityUser> GetUsersAsQueryable();
    }
}
