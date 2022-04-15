using Microsoft.AspNetCore.Authorization;
using RestAPI.Authentication.AuthorizationRequirement;
using RestAPI.Authentication.Constants;

namespace RestAPI.Authentication.AuthorizationHandlers
{
    public class ManagerHandler : AuthorizationHandler<ManagerRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManagerRequirement requirement)
        {
            if(context.User == null)
            {
                return Task.CompletedTask;
            }

            var user = context.User;
            // Managers can read and create.
            if(user.IsInRole(UserRoles.Manager) || user.IsInRole(UserRoles.Admin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
