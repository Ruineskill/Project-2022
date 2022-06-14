using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces.ApiHttp
{
    public interface IApiSecurityService
    {
        Task<bool> SignIn(string username, SecureString password);

        Task SignOut();
    }
}
