using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class FuelCardViewModel
    {
        private readonly FuelCard _fuelCard;

        public long CardNumber { get=> _fuelCard.CardNumber; set => _fuelCard.CardNumber =value; }
        public DateOnly ExpirationDate { get => _fuelCard.ExpirationDate; set => _fuelCard.ExpirationDate=value; }
        public int PinCode { get => _fuelCard.PinCode; set => _fuelCard.PinCode=value; }
        public ICollection<FuelType> UsableFuelTypes { get => _fuelCard.UsableFuelTypes; set => _fuelCard.UsableFuelTypes=value; }


        public FuelCardViewModel(FuelCard fuelCard)
        {
            _fuelCard = fuelCard;
        }
    }
}
