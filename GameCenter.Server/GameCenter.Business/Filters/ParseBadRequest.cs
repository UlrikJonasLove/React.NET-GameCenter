using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GameCenter.Business.Filters
{
    public class ParseBadRequest : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result as IStatusCodeActionResult;
            if (result == null)
            {
                return;
            }

            var statusCode = result.StatusCode;
            if (statusCode == 400)
            {
                var response = new List<string>();
                var badRequestObjectResult = context.Result as BadRequestObjectResult;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (badRequestObjectResult.Value is string)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    response.Add(badRequestObjectResult.Value.ToString());
#pragma warning restore CS8604 // Possible null reference argument.
                }
                else if (badRequestObjectResult.Value is IEnumerable<IdentityError> errors)
                {
                    foreach (var error in errors)
                    {
                        response.Add(error.Description);
                    }
                }
                else
                {
                    foreach (var key in context.ModelState.Keys)
                    {
                        foreach (var error in context.ModelState[key].Errors)
                        {
                            response.Add($"{key}: {error.ErrorMessage}");
                        }
                    }
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                context.Result = new BadRequestObjectResult(response);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}