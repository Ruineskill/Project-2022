using Presentation.ViewModels;
using System;
using System.Threading.Tasks;

namespace Presentation.Interfaces.Listing
{
    public interface IPersonListingService : IListingService
    {
        Task<PersonViewModel?> Find(Func<PersonViewModel, bool> predicate);
        bool ContainsNationalId(string result);
    }
}
