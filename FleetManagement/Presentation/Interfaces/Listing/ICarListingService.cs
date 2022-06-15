using Presentation.ViewModels;
using System;
using System.Threading.Tasks;

namespace Presentation.Interfaces.Listing
{
    public interface ICarListingService : IListingService
    {
        Task<CarViewModel?> Find(Func<CarViewModel, bool> predicate);
        bool ConaintsVinID(string value);
        bool ConaintsLicensePlate(string value);
    }
}
