using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using RestAPI.Authentication.Constants;

namespace RestAPI.Authentication.AuthorizationHandlers
{
    public class UsersAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, IdentityUser>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, IdentityUser resource)
        {
            if(context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If asking for read
            if(requirement.Name == UserActions.Read)
            {
                // Users can read
                if(context.User.IsInRole(UserRoles.Normal))
                {
                    context.Succeed(requirement);
                }

                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
