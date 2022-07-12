using AutoMapper;
using GameCenter.Business.DTOs.Pagination;
using GameCenter.Business.DTOs.User;
using GameCenter.Business.Helpers;
using GameCenter.Business.Services.Users;
using GameCenter.DataAccess.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameCenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserService service;

        public UserController(AppDbContext context, IMapper mapper, UserManager<IdentityUser> userManager, IUserService service)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.service = service;
        }

        [HttpGet("listUsers")]
        public async Task<ActionResult<List<UserDto>>> GetListUsers([FromQuery] PaginationDto pagination)
        {
            var queryable = service.GetUsersAsQueryable();
            await HttpContext.InsertParametersPaginationInHeader(queryable);
            var users = await queryable.OrderBy(x => x.Email).Paginate(pagination).ToListAsync();

            return mapper.Map<List<UserDto>>(users);
        }

        [HttpPost("assignAdminClaim")]
        public async Task<ActionResult> AssignAdminClaim([FromBody] string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            await userManager.AddClaimAsync(user, new Claim("role", "admin"));
            return NoContent();
        }

        [HttpPost("removeAdminClaim")]
        public async Task<ActionResult> RemoveAdminClaim([FromBody] string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveClaimAsync(user, new Claim("role", "admin"));
            return NoContent();
        }
    }
}
