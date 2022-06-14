using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces.Navigation
{
    public interface IDetailNavigationService : INavigationService
    {
        void GoBack();
    }
}
