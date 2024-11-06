using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Reactivities.Utils;
using Reactivities.Utils.AppUser;

namespace Reactivities.API.CustomAttribute
{
    public class Authorize : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly RoleType _roleType;

        public Authorize(RoleType roleType)
        {
            _roleType = roleType;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated == false)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                return;
            }

            if (!UserContext.RuntimeContext.User.Roles.Any(p => p >= _roleType))
            {
                context.Result = new Microsoft.AspNetCore.Mvc.ForbidResult();
                return;
            }
        }
    }
}