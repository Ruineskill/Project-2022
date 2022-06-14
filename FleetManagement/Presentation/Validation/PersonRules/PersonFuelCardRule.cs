using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;
using Presentation.ViewModels;

namespace Presentation.Validation.PersonRules
{
    public class PersonFuelCardRule : ValidationRule
    {
        public CarViewModel? Car { get; set; }
        public FuelCardViewModel? FuelCard { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if(Car != null && FuelCard != null)
            {
                if(!FuelCard.UsableFuelTypes.Contains(Car.FuelType))
                {
                    return new ValidationResult(false, "Fuel card not support");
                }

            }
            return ValidationResult.ValidResult;
        }
    }
}
