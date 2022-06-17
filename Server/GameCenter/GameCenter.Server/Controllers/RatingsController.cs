using GameCenter.Business.DTOs.Rating;
using GameCenter.DataAccess.Data;
using GameCenter.Models.Rating;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameCenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public RatingsController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromBody] RatingDto rating)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var user = await userManager.FindByEmailAsync(email);
            var userId = user.Id;

            var currentRate = await context.Ratings.FirstOrDefaultAsync(x => x.GameId == rating.GameId && x.UserId == userId);

            if(currentRate == null)
            {
                var ratingModel = new Rating();
                ratingModel.GameId = rating.GameId;
                ratingModel.Rate = rating.Rating;
                ratingModel.UserId = userId;
                context.Add(ratingModel);
            }
            else
            {
                currentRate.Rate = rating.Rating;
            }

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
