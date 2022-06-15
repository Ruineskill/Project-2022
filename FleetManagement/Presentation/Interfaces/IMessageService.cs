using Presentation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IMessageService
    {
        Task DisplayErrorAsync(string message, DialogHosting host);
        Task<bool> DisplayWarningAsync(string message, DialogHosting host);
    }
}
