using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation.ViewModels
{
    public class FuelCardListingViewModel : TabViewModelBase
    {
        public override string Name { get; set; } = "Fuel Cards";

        private readonly IHttpFuelCardService _fuelCardService;

        private ObservableCollection<FuelCardViewModel> _fuelCards;

        public ObservableCollection<FuelCardViewModel> FuelCards { get => _fuelCards; set => _fuelCards = value; }

        private FuelCardViewModel? _selectedFuelCard;
        public FuelCardViewModel? SelectedFuelCard
        {
            get => _selectedFuelCard;
            set => SetProperty(ref _selectedFuelCard, value);
        }

        public FuelCardListingViewModel(IHttpFuelCardService fuelCardService)
        {
            _fuelCards = new();
            _fuelCardService = fuelCardService;
            LoadFuelCard();
        }


        private async void LoadFuelCard()
        {
                var fuelCards = await _fuelCardService.GetAllAsync();
                foreach(var f in fuelCards) _fuelCards.Add(new FuelCardViewModel(f));
        }
    }
}
