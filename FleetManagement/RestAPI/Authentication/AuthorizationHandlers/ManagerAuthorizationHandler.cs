using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using RestAPI.Authentication.Constants;

namespace RestAPI.Authentication.AuthorizationHandlers
{
    public class ManagerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, IdentityUser>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, IdentityUser resource)
        {
            if(context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If asking for read/create
            if(requirement.Name == UserActions.Create || requirement.Name == UserActions.Read)
            {
                // Managers can read and create.
                if(context.User.IsInRole(UserRoles.Manager))
                {
                    context.Succeed(requirement);
                }

                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
