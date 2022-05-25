using Domain.Models;
using Domain.Models.Enums;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Interfaces;

namespace Presentation.ViewModels
{
    public class FuelCardViewModel: DetailViewModelBase
    {
        public readonly FuelCard FuelCard;

        IHttpFuelCardService _httpFuelCardService;

        public long CardNumber { get=> FuelCard.CardNumber; set => FuelCard.CardNumber =value; }

        public DateOnly ExpirationDate { get => FuelCard.ExpirationDate; set => FuelCard.ExpirationDate=value; }

        public DateTime ExpDate { get => ExpirationDate.ToDateTime(TimeOnly.MinValue); set => ExpirationDate = DateOnly.FromDateTime(value); }

        public int PinCode { get => FuelCard.PinCode; set => FuelCard.PinCode=value; }

        public ICollection<FuelType> UsableFuelTypes { get => FuelCard.UsableFuelTypes; set => FuelCard.UsableFuelTypes=value; }

        public ICollection<FuelValue> FuelValues { get; set; } = new List<FuelValue>();

        public FuelCardViewModel(FuelCard fuelCard, IHttpFuelCardService httpFuelCardService)
        {
            FuelCard = fuelCard;
            _httpFuelCardService = httpFuelCardService;


            foreach (var fuelType in Enum.GetValues<FuelType>())
            {
                FuelValues.Add(new FuelValue(fuelType, UsableFuelTypes.Contains(fuelType)));
            }
        }

        public override async void Save()
        {
            UsableFuelTypes = new List<FuelType>();

            foreach (var fuel in FuelValues)
            {
                if (fuel.IsSelected)
                    UsableFuelTypes.Add(fuel.FuelType);
            }

            FuelCard.UsableFuelTypes = UsableFuelTypes;

           await _httpFuelCardService.UpdateAsync(FuelCard);
        }
    }

    public class FuelValue
    {
        public FuelType FuelType { get; }

        public String Label => FuelType.ToString();
        public bool IsSelected { get; set; }

        public FuelValue(FuelType fuelType, bool isSelected)
        {
            FuelType = fuelType;
            IsSelected = isSelected;
        }
    }
}
