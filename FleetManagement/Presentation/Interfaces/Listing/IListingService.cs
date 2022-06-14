using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces.Listing
{
    public interface IListingService
    {
        ObservableCollection<ViewModelBase> Items { get; }
        ICollectionView View { get; set; }

        Task Create(ViewModelBase item);
        Task Update(ViewModelBase item);
        Task Delete(ViewModelBase item);
        bool Contains(ViewModelBase item);

        Task LoadItems();
    }
}
