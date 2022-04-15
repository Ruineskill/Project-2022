using Microsoft.AspNetCore.Authorization;
using RestAPI.Authentication.AuthorizationRequirement;
using RestAPI.Authentication.Constants;

namespace RestAPI.Authentication.AuthorizationHandlers
{
    public class UserHandler : AuthorizationHandler<UserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
        {
            if(context.User == null)
            {
                return Task.CompletedTask;
            }

            var user = context.User;
            // Users can read
            if(user.IsInRole(UserRoles.Manager) || user.IsInRole(UserRoles.Admin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
