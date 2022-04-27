using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Dto
{
    public record AuthenticationReponse
    {
        public string UserName { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;

        public bool IsAuthenticated { get; set; } = false;

        public string Message { get; set; } = string.Empty;
    }
}
