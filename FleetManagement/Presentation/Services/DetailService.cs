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

namespace Presentation.Services
{
    public class DetailService : IDetailService
    {
        private const string _mainHost = "FleetHost";

        private DetailDialog _detailDialog;
        private DetailDialogViewModel _ctx;
        private readonly IFleetMediator _fleetMediator;
        private readonly IMessageService _msgService;

        private ViewModelBase? _item;
        private bool _isNewItem = false;

        public DetailService(IFleetMediator fleetMediator, IMessageService messageService)
        {
            _detailDialog = new DetailDialog();
            _fleetMediator = fleetMediator;
            _msgService = messageService;

            _ctx = _detailDialog.Context;
            _ctx.CancelCommand = new RelayCommand(CancleHandler);
            _ctx.SaveCommand = new RelayCommand(SaveHandler);
        }

        private void SaveHandler()
        {

            if(_detailDialog.HasErrors()) return;

            if(_isNewItem)
            {

                _fleetMediator.Create(_item);
            }
            else if(_ctx.Content != null)
            {
                if(!IsSame(_item, _ctx.Content))
                {
                    _fleetMediator.Update(_item);
                }
            }
            _detailDialog.Close();
        }

        private void CancleHandler()
        {
            _detailDialog.Close();
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

        public async Task Delete(ViewModelBase item)
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

        public async Task Open(ViewModelBase item)
        {
            _detailDialog.SetContent(CreateShallowCopy(item));
            await _detailDialog.Show(_mainHost);
        }

        public async Task CreatePerson()
        {
            _isNewItem = true;
            _item = new PersonViewModel();
            _detailDialog.SetContent(_item);
            await _detailDialog.Show(_mainHost);

            _isNewItem = false;
        }

        public async Task CreateCar()
        {
            _isNewItem = true;
            var _item = new CarViewModel();
            _detailDialog.SetContent(_item);
            await _detailDialog.Show(_mainHost);

            _isNewItem = false;
        }

        public async Task CreateFuelCard()
        {
            _isNewItem = true;
            _item = new FuelCardViewModel();
            _detailDialog.SetContent(_item);
            await _detailDialog.Show(_mainHost);

            _isNewItem = false;
        }

        private ViewModelBase CreateShallowCopy(ViewModelBase item)
        {
            _item = item;

            if(item is CarViewModel car)
            {
                return car.ShallowCopy();
            }
            else if(item is PersonViewModel person)
            {
                return person.ShallowCopy();
            }
            else
            {
                var fuelCard = (FuelCardViewModel)item;

                var copy = ((FuelCardViewModel)item).ShallowCopy();
                copy.UsableFuelTypes = new List<FuelType>(fuelCard.UsableFuelTypes);

                return copy;
            }


        }
        private static bool IsSame(ViewModelBase item1, ViewModelBase item2)
        {
            if(item1 is CarViewModel lcar && item2 is CarViewModel rcar)
            {
                return lcar.Id == rcar.Id &&
                lcar.Brand == rcar.Brand &&
                lcar.Model == rcar.Model &&
                lcar.ChassisNumber == rcar.ChassisNumber &&
                lcar.LicensePlate == rcar.LicensePlate &&
                lcar.FuelType == rcar.FuelType &&
                lcar.Type == rcar.Type &&
                lcar.Person == rcar.Person &&
                lcar.Color == rcar.Color &&
                lcar.NumberOfDoors == rcar.NumberOfDoors &&
                lcar.RequiredLicence == rcar.RequiredLicence;
            }
            else if(item1 is PersonViewModel lperson && item2 is PersonViewModel rperson)
            {
                return lperson.Id == rperson.Id &&
                       lperson.FirstName == rperson.FirstName &&
                       lperson.LastName == rperson.LastName &&
                       lperson.DateOfBirth == rperson.DateOfBirth &&
                       lperson.NationalID == rperson.NationalID &&
                       lperson.DrivingLicenseType == rperson.DrivingLicenseType &&
                       lperson.Address == rperson.Address &&
                       lperson.Car == rperson.Car &&
                       lperson.FuelCard == rperson.FuelCard;
            }
            else if(item1 is FuelCardViewModel lfuelCard && item2 is FuelCardViewModel rfuelCard)
            {
                return lfuelCard.Id == rfuelCard.Id &&
                   lfuelCard.CardNumber == rfuelCard.CardNumber &&
                   lfuelCard.ExpirationDate == rfuelCard.ExpirationDate &&
                   lfuelCard.PinCode == rfuelCard.PinCode &&
                   lfuelCard.UsableFuelTypes == rfuelCard.UsableFuelTypes &&
                   lfuelCard.Person == rfuelCard.Person &&
                    lfuelCard.Blocked == rfuelCard.Blocked;
            }

            return false;
        }
    }
}
