
#nullable disable warnings
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

                Filter(null);

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

        private void Filter(string? p)
        {

            if(_listing != null)
            {

                switch(_listing)
                {
                    case ICarListingService:
                        FilterCars(p);
                        break;
                    case IPersonListingService:
                        FilterPeople(p);
                        break;
                    case IFuelCardListingService:
                        FilterFuelCards(p);
                        break;
                    default:
                        break;
                }



            }

        }

        private void FilterCars(string p)
        {
            if(p != null)
            {
                _listing.View.Filter = new Predicate<object>(bool (object s) =>
                {
                    var car = (CarViewModel)s;
                    var pre = p.ToLower();

                    if(car.Person == null || car.Brand.Contains(pre, StringComparison.CurrentCultureIgnoreCase)
                    || car.Model.Contains(pre, StringComparison.CurrentCultureIgnoreCase)
                    || car.ChassisNumber.Contains(pre, StringComparison.CurrentCultureIgnoreCase)) return true;
                    return false;
                });
            }
            else
            {
                _listing.View.Filter = new Predicate<object>(bool (object s) =>
                {
                    var car = (CarViewModel)s;
                    if(car.Person == null) return true;
                    return false;
                });
            }
        }

        private void FilterPeople(string p)
        {
            if(p != null)
            {
                _listing.View.Filter = new Predicate<object>(bool (object s) =>
                {
                    var person = (PersonViewModel)s;
                    var pre = p.ToLower();

                    if(person.FirstName.Contains(pre, StringComparison.CurrentCultureIgnoreCase)
                    || person.LastName.Contains(pre, StringComparison.CurrentCultureIgnoreCase)
                    || person.NationalID.Contains(pre, StringComparison.CurrentCultureIgnoreCase)) return true;
                    return false;
                });
            }
            else
            {
                _listing.View.Filter = new Predicate<object>(bool (object s) =>
                {
                    var person = (PersonViewModel)s;

                    if(person.Car ==null || person.FuelCard ==null) return true;
                    return false;
                });
            }
        }

        private void FilterFuelCards(string p)
        {
            if(p != null)
            {
                _listing.View.Filter = new Predicate<object>(bool (object s) =>
                {
                    var fuelCard = (FuelCardViewModel)s;
                    var pre = p.ToLower();

                    if(fuelCard.Person == null || fuelCard.CardNumber.ToString().Contains(pre, StringComparison.CurrentCultureIgnoreCase)) return true;
                    return false;
                });
            }
            else
            {
                _listing.View.Filter = new Predicate<object>(bool (object s) =>
                {
                    var fuelCard = (FuelCardViewModel)s;

                    if(fuelCard.Person == null) return true;
                    return false;
                });
            }
        }
    }
}
