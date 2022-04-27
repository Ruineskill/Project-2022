﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IApiSecurityService
    {
        Task<bool> SignIn(string username, SecureString password);

        void SignOut();


    }
}
