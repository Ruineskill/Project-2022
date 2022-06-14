using Presentation.ViewModels;
using System;
using System.Threading.Tasks;

namespace Presentation.Interfaces.Listing
{
    public interface IFuelCardListingService : IListingService
    {
        Task<FuelCardViewModel> Find(Func<FuelCardViewModel, bool> predicate);
    }
}
