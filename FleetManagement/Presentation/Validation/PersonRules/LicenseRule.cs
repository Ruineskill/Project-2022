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
    public class LicenseRule : ValidationRule
    {
        public CarViewModel? Car { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var result = (DrivingLicenseType)value;
            if(Car != null)
            {
                if(Car.RequiredLicence > result) return new ValidationResult(false, "Does not meet license requirement for car");
            }
            return ValidationResult.ValidResult;
        }


    }
}
