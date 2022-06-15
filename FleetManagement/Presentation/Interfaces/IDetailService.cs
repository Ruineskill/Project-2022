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
        Task Open(ValidatedViewModelBase item);
        Task Create();
        Task Delete(ValidatedViewModelBase item);
        Task CreatePerson();
        Task CreateCar();
        Task CreateFuelCard();
    }
}
