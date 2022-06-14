using Presentation.ViewModels;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces.Listing
{
    public interface ISelectorService
    {
       
        Task<CarViewModel?> SelectCar();
        Task<FuelCardViewModel?> SelectFuelCard();
        Task<PersonViewModel?> SelectPerson();
    }
}
