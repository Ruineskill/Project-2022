using Presentation.DTO;
using Presentation.ViewModels;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IFleetMediator
    {
        void Create(ViewModelBase obj);
        void Update(ViewModelBase obj);
        void Delete(ViewModelBase obj);

    }
}
