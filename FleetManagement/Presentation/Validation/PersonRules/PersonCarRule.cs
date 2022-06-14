using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;
using Presentation.ViewModels;
using Domain.Models.Enums;

namespace Presentation.Validation.PersonRules
{
    public class PersonCarRule : ValidationRule
    {
        public CarViewModel? Car { get; set; }
        public FuelCardViewModel? FuelCard { get; set; }
        public DrivingLicenseType LicenseType { get; set; }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(Car != null)
            {
                if(FuelCard != null)
                {
                    if(!FuelCard.UsableFuelTypes.Contains(Car.FuelType))
                        return new ValidationResult(false, "Does not support car's fuel type");
                }        

                if(Car.RequiredLicence < LicenseType)
                    return new ValidationResult(false, "Does not meet person's license type requirement");

            }
            return ValidationResult.ValidResult;
        }
    }
}
