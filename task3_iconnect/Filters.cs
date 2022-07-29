using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace task3_iconnect
{
    public class Filters : IActionFilter
    {
            public void OnActionExecuting(ActionExecutingContext context)
            {
                var author = context.HttpContext.Request.Headers["Rule"];

                if (author == "admin")
                {
                    return;
                }
                else
                {
                    context.Result = new BadRequestObjectResult(" Error ! not authorized");
                    return;
                }
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
            }
        }
}
