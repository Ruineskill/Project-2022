using Microsoft.AspNetCore.Authorization.Infrastructure;
using RestAPI.Authentication.Constants;

namespace RestAPI.Authentication
{
    public class UserOperations
    {
        public static OperationAuthorizationRequirement Create =
         new OperationAuthorizationRequirement { Name = UserActions.Create };
        public static OperationAuthorizationRequirement Read =
          new OperationAuthorizationRequirement { Name = UserActions.Read };
        public static OperationAuthorizationRequirement Update =
          new OperationAuthorizationRequirement { Name = UserActions.Update };
        public static OperationAuthorizationRequirement Delete =
          new OperationAuthorizationRequirement { Name = UserActions.Delete };

    }
}
