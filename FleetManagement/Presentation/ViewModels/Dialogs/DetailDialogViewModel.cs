using Microsoft.Toolkit.Mvvm.Input;
using Presentation.Enums;
using Presentation.Interfaces.Listing;
using Presentation.Interfaces.Navigation;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels.Dialogs
{
    public class DetailDialogViewModel : ViewModelBase
    {
        private readonly ISelectorService _selectorService;

        public ViewModelBase? _content;
        public ViewModelBase? Content
        {
            get => _content; 
            set =>SetProperty(ref _content, value); 
        }

        public ICommand? SaveCommand { get; set; }

        public ICommand? CancelCommand { get; set; }

        public DetailDialogViewModel(ISelectorService selectorService)
        {
            _selectorService = selectorService;

            PickCommand = new AsyncRelayCommand<ModelType>(PickCommandHandler);

            RemoveCommand = new RelayCommand<ModelType>(RemoveHandler);
        }

        private void RemoveHandler(ModelType modelType)
        {
            switch(modelType)
            {
                case ModelType.Person:
                    AssignePerson(null);
                    break;
                case ModelType.FuelCard:
                    AssigneFuelCard(null);

                    break;
                case ModelType.Car:
                    AssigneCar(null);
                    break;
                default:
                    break;
            }
        }

        private async Task PickCommandHandler(ModelType modelType)
        {
            switch(modelType)
            {
                case ModelType.Person:
                    var person = await _selectorService.SelectPerson();
                    AssignePerson(person);
                    break;
                case ModelType.FuelCard:
                    var FuelCard = await _selectorService.SelectFuelCard();
                    AssigneFuelCard(FuelCard);

                    break;
                case ModelType.Car:
                    var car = await _selectorService.SelectCar();
                    AssigneCar(car);
                    break;
                default:
                    break;
            }
        }

        public ICommand? PickCommand { get; set; }

        public ICommand? RemoveCommand { get; set; }

        public void SetContent(ViewModelBase content)
        {
            Content = content;
        }

    
        private void AssignePerson(PersonViewModel? person)
        {
            if(_content is CarViewModel carView)
            {
                carView.Person = person;
            }
            else if(_content is FuelCardViewModel fuelCard)
            {
                fuelCard.Person = person;
            }
        }

        private void AssigneFuelCard(FuelCardViewModel? fuelCard)
        {
            if(_content is PersonViewModel person)
            {
                person.FuelCard = fuelCard;
            }
        }

        private void AssigneCar(CarViewModel? car)
        {
            if(_content is PersonViewModel person)
            {
                person.Car = car;
            }
        }



    }
}
