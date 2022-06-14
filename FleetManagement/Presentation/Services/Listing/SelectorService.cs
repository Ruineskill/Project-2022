using Microsoft.Toolkit.Mvvm.Input;
using Presentation.Interfaces.Listing;
using Presentation.ViewModels;
using Presentation.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services.Listing
{
    public class SelectorService : ISelectorService
    {
        private readonly ICarListingService _carListingService;
        private readonly IFuelCardListingService _fuelCardListingService;
        private readonly IPersonListingService _personListingService;
        private readonly SelectorDialog _sd;

        public SelectorService(ICarListingService carListingService, IFuelCardListingService fuelCardListingService, IPersonListingService personListingService)
        {
            _carListingService = carListingService;
            _fuelCardListingService = fuelCardListingService;
            _personListingService = personListingService;

            _sd = new SelectorDialog();
            _sd.Context.SelectCommand = new RelayCommand(SelectHandler);
            _sd.Context.CancelCommand = new RelayCommand(CancelHandler);
        }

        public async Task<CarViewModel?> SelectCar()
        {
            _sd.Context.Listing = _carListingService;
            await _sd.Show("DetailHost");

            return (CarViewModel?)_sd.Context.Selected;
        }

        public async Task<FuelCardViewModel?> SelectFuelCard()
        {
            _sd.Context.Listing = _fuelCardListingService;
            await _sd.Show("DetailHost");
            return (FuelCardViewModel?)_sd.Context.Selected;
        }

        public async Task<PersonViewModel?> SelectPerson()
        {
            _sd.Context.Listing = _personListingService;
            await _sd.Show("DetailHost");
            return (PersonViewModel?)_sd.Context.Selected;
        }

        private void CancelHandler()
        {
            _sd.Close();
        }

        private void SelectHandler()
        {
            _sd.Close();
        }

     
    }
}
