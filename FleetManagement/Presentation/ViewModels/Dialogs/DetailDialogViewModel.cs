#nullable disable warnings
using Microsoft.Toolkit.Mvvm.Input;
using Presentation.Enums;
using Presentation.Interfaces.Listing;
using Presentation.Interfaces.Navigation;
using Presentation.Validation;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels.Dialogs
{
    public class DetailDialogViewModel : ViewModelBase
    {
        public event Action<int> ErrorChanged;

        private readonly ISelectorService _selectorService;

        public ValidatorBase? Validator { get; set; }

        public int ErrorCount { get; private set; }

        public ValidatedViewModelBase? _content;
        public ValidatedViewModelBase? Content
        {
            get => _content;
            set
            {
                SetProperty(ref _content, value);
                if(Validator != null)
                {
                    _content.PropertyChanged += _content_PropertyChanged;

                    ValidateProperties();
                }
            }
        }



        private void _content_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {


            ValidateProperty(e.PropertyName);


            while(Validator.ReValidation.TryDequeue(out string property))
            {
                ValidateProperty(property);
            }

        }

        private void ValidateProperty(string propertyName)
        {
            var validator = Validator.GetType();
            var valid = validator.GetMethod(propertyName, BindingFlags.Instance | BindingFlags.Public);

            if(valid != null)
            {
                if(!(bool)valid.Invoke(Validator, new[] { Content }))
                {
                    Content.AddError(propertyName, Validator.Message);
                    SetErrorCount();

                }
                else
                {
                    if(_content.ContainsErrorFor(propertyName))
                    {
                        _content.ClearErrors(propertyName);

                        SetErrorCount(false);
                    }
                }
            }
           
        }

        private void SetErrorCount(bool increment = true)
        {
            ErrorCount = increment ? ++ErrorCount : --ErrorCount;
            ErrorChanged?.Invoke(ErrorCount);
        }

        private void ValidateProperties()
        {

            var properties = _content.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var validator = Validator.GetType();

            try
            {
                foreach(var property in properties)
                {
                    var methode = validator.GetMethod(property.Name, BindingFlags.Instance | BindingFlags.Public);
                    if(methode != null)
                    {
                        if(!(bool)methode.Invoke(Validator, new[] { Content }))
                        {
                            Content.AddError(property.Name, Validator.Message);
                            ErrorCount++;
                        }
                    }


                }
            }
            catch(Exception ex)
            {

                var msg = ex.Message;
            }


        }



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
