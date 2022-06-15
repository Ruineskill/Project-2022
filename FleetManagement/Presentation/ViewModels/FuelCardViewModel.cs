#nullable disable warnings
using Domain.Models.Enums;
using Presentation.DTO;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;

namespace Presentation.ViewModels
{
    public class FuelCardViewModel : ValidatedViewModelBase
    {
        private PersonViewModel _person;
        private ICollection<FuelType> _usableFuelTypes = new List<FuelType>();
        private int _pinCode;
        private DateOnly _expirationDate;
        private long _cardNumber;
        private bool _blocked = false;

        public int Id { get; private set; }

        public long CardNumber { get => _cardNumber; set => SetProperty(ref _cardNumber, value); }

        public DateOnly ExpirationDate { get => _expirationDate; set => SetProperty(ref _expirationDate, value); }

        public int PinCode { get => _pinCode; set => SetProperty(ref _pinCode, value); }

        public ICollection<FuelType> UsableFuelTypes 
        { 
            get => _usableFuelTypes; 
            set
            {
                //SetProperty(ref _usableFuelTypes, value);
                _usableFuelTypes = value;
                OnPropertyChanged(nameof(UsableFuelTypes));
            }
        }

        public bool Blocked { get => _blocked; set => SetProperty(ref _blocked, value); }

        public PersonViewModel? Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }



        public static implicit operator FuelCardDto(FuelCardViewModel from)
        {
            if(from == null) return null;
            return new FuelCardDto
            {
                Id = from.Id,
                CardNumber = from.CardNumber,
                ExpirationDate = from.ExpirationDate,
                PinCode = from.PinCode,
                UsableFuelTypes = from.UsableFuelTypes,
                Person = from.Person
            };
        }
        public static implicit operator FuelCardViewModel(FuelCardDto from)
        {
            if(from == null) return null;
            return new FuelCardViewModel
            {
                Id = from.Id,
                CardNumber = from.CardNumber,
                ExpirationDate = from.ExpirationDate,
                PinCode = from.PinCode,
                UsableFuelTypes = from.UsableFuelTypes,
                Person = from.Person,
                Blocked = from.Blocked
            };
        }

        public override string ToString()
        {
            return CardNumber.ToString();
        }


        public FuelCardViewModel ShallowCopy()
        {
            return (FuelCardViewModel)this.MemberwiseClone();
        }


    }
}
