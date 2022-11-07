using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserRegistration.Helper
{
    public class AuthorizeByRoleAttribute : Attribute, IAuthorizationFilter
    {
        readonly string role;
        public AuthorizeByRoleAttribute(string role)
        {
            this.role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.FindFirst(ClaimTypes.Role) == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }

            else
            {
                bool authorize = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == role;
                if (!authorize)
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
