using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using Presentation.Mediators;
using Presentation.ViewModels.Bases;
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

        private readonly FuelCardMediator _fuelCardMediator;

        private readonly IDetailDialogService _detailDialogService;

        private ObservableCollection<FuelCardViewModel> _fuelCards;

        public ObservableCollection<FuelCardViewModel> FuelCards { get => _fuelCards; set => _fuelCards = value; }

        private FuelCardViewModel? _selectedFuelCard;
        public FuelCardViewModel? SelectedFuelCard
        {
            get => _selectedFuelCard;
            set => SetProperty(ref _selectedFuelCard, value);
        }

        public FuelCardListingViewModel(IHttpFuelCardService fuelCardService, FuelCardMediator fuelCardMediator, IDetailDialogService detailDialogService)
        {
            _fuelCards = new();
            _fuelCardService = fuelCardService;
            _fuelCardMediator = fuelCardMediator;
            _detailDialogService = detailDialogService;
            _ = LoadFuelCards();

            _fuelCardMediator.Created += OnFuelCardCreated;
        }


        private async Task LoadFuelCards()
        {
           
            await foreach(var fuelCard in _fuelCardService.GetAllStream())
            {
                _fuelCards.Add(new FuelCardViewModel(fuelCard));
            }

        }

        private async void OnFuelCardCreated(FuelCard obj)
        {
            if(await _fuelCardService.CreateAsync(obj))
            {
                _fuelCards.Add(new FuelCardViewModel(obj));
            }
        }

        public override void ReadItemHandler()
        {
            if(_selectedFuelCard != null)
            {
                _detailDialogService.SetContent(_selectedFuelCard);
                _detailDialogService.Show();
            }
        }

        public override void EditItemHandler()
        {
            throw new NotImplementedException();
        }

        public override void DeleteItemHandler()
        {
            throw new NotImplementedException();
        }
    }
}
