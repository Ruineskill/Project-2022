using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using RestAPI.Authentication.Constants;

namespace RestAPI.Authentication.AuthorizationHandlers
{
    public class AdministratorAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, IdentityUser>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, IdentityUser resource)
        {
            if(context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if(context.User.IsInRole(UserRoles.Admin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
