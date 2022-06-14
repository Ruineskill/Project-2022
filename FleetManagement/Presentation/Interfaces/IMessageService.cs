using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IMessageService
    {
        Task DisplayErrorAsync(string message);
        Task<bool> DisplayWarningAsync(string message, string hostName);
    }
}
