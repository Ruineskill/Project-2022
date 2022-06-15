#nullable disable warnings
using Presentation.Interfaces;
using Presentation.ViewModels.Bases;
using Presentation.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using Presentation.Views.Dialogs;
using Microsoft.Toolkit.Mvvm.Input;
using Presentation.ViewModels;
using Domain.Models.Enums;
using Presentation.Validation;

namespace Presentation.Services
{
    public class DetailService : IDetailService
    {
        private const string _mainHost = "FleetHost";

        private DetailDialog _detailDialog;

        private readonly IFleetMediator _fleetMediator;
        private readonly IMessageService _msgService;


        public DetailService(IFleetMediator fleetMediator, IMessageService messageService)
        {
            _detailDialog = new DetailDialog();
            _fleetMediator = fleetMediator;
            _msgService = messageService;

        }


        public async Task Create()
        {
            var result = await new CreateSelectionDialog().Show(_mainHost);
            switch(result)
            {
                case Enums.ModelType.Person:
                    await CreatePerson();
                    break;
                case Enums.ModelType.FuelCard:
                    await CreateFuelCard();
                    break;
                case Enums.ModelType.Car:
                    await CreateCar();
                    break;
                default:
                    break;
            }
        }

        public async Task Delete(ValidatedViewModelBase item)
        {
            string msg = string.Empty;
            switch(item)
            {
                case CarViewModel car:
                    msg = "Are you sure you want to delete Car: " + car.ToString();
                    break;
                case FuelCardViewModel fuelCard:
                    msg = "Are you sure you want to delete FuelCard: " + fuelCard.ToString();
                    break;
                case PersonViewModel person:
                    msg = "Are you sure you want to delete Person: " + person.ToString();
                    break;
                default:
                    break;
            }

            if(await _msgService.DisplayWarningAsync(msg, _mainHost))
            {
                _fleetMediator.Delete(item);
            }
        }

        public async Task Open(ValidatedViewModelBase item)
        {

            _detailDialog.SetContent(item, GetValidatorFor(item));
            var result = await _detailDialog.Show(_mainHost);
            if(result == Enums.DetailDialogResult.Save)
            {
                _fleetMediator.Update(_detailDialog.GetContent());
            }

        }

        public async Task CreatePerson()
        {
            var item = new PersonViewModel();
            _detailDialog.SetContent(item, GetValidatorFor(item));
            var result = await _detailDialog.Show(_mainHost);
            if(result == Enums.DetailDialogResult.Save)
            {
                _fleetMediator.Create(_detailDialog.GetContent());
            }

        }

        public async Task CreateCar()
        {
            var item = new CarViewModel();
            _detailDialog.SetContent(item, GetValidatorFor(item));
            var result = await _detailDialog.Show(_mainHost);
            if(result == Enums.DetailDialogResult.Save)
            {
                _fleetMediator.Create(_detailDialog.GetContent());
            }
        }

        public async Task CreateFuelCard()
        {
            var item = new FuelCardViewModel();
            _detailDialog.SetContent(item, GetValidatorFor(item));
            var result = await _detailDialog.Show(_mainHost);
            if(result == Enums.DetailDialogResult.Save)
            {
                _fleetMediator.Create(_detailDialog.GetContent());
            }
        }

        private static ValidatorBase? GetValidatorFor(ValidatedViewModelBase vm)
        {
            return vm switch
            {
                CarViewModel => new CarValidator(),
                FuelCardViewModel => new FuelCardValidator(),
                PersonViewModel => new PersonValidator(),
                _ => null,
            };
        }

    }
}
