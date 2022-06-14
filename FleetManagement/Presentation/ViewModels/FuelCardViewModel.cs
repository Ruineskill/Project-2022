#nullable disable warnings
using Domain.Models.Enums;
using Presentation.DTO;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;

namespace Presentation.ViewModels
{
    public class FuelCardViewModel : ViewModelBase
    {

        public int Id { get; private set; }
        public long CardNumber { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int PinCode { get; set; }
        public bool Blocked { get; set; } = false;
        public ICollection<FuelType> UsableFuelTypes { get; set; } = new List<FuelType>();
        private PersonViewModel _person;
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
                Blocked = from.Blocked,
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
