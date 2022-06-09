using Microsoft.AspNetCore.Mvc;

namespace GameCenter.Business.Behavior
{
    public class BadRequest
    {
        public static void Parse(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var response = new List<string>();
                foreach (var key in context.ModelState.Keys)
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    foreach (var error in context.ModelState[key].Errors)
                    {
                        response.Add($"{key}: {error.ErrorMessage}");
                    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
                return new BadRequestObjectResult(response);
            };
        }
    }
}
