
using Presentation.Interfaces.Listing;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;

namespace Presentation.ViewModels.Dialogs
{
    public class SelectorDialogViewModel : ViewModelBase
    {
        public ViewModelBase? Selected { get; set; }

        public IListingService? _listing;
        public IListingService? Listing
        {
            get => _listing;
            set
            {
                
                _listing = value;

                //Items = CollectionViewSource.GetDefaultView(Listing?.Items);
                //Items.Filter = c => ((CarViewModel)c).FuelType == Domain.Models.Enums.FuelType.Diesel;


                //_listing.View.Filter = c => ((CarViewModel)c).FuelType == Domain.Models.Enums.FuelType.Diesel;

                OnPropertyChanged(nameof(Items));
            }
        }

        public ICollectionView? Items => _listing?.View;


        public ICommand? SelectCommand { get; set; }

        public ICommand? CancelCommand { get; set; }

        private string _search = string.Empty;
        public string Search
        {
            get => _search;
            set => SetProperty(ref _search, value);
        }

    }
}
