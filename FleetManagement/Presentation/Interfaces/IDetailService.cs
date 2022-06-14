using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IDetailService
    {
        Task Open(ViewModelBase item);
        Task Create();
        Task Delete(ViewModelBase item);
        Task CreatePerson();
        Task CreateCar();
        Task CreateFuelCard();
    }
}
