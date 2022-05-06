using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.ApiRoutes
{
    public static class UserRoute
    {
        public const string Base = "User/";

        public const string SignIn =  nameof(SignIn);
        public const string SignOut = nameof(SignOut);
        public const string RefreshToken =  nameof(RefreshToken);
    }
}
