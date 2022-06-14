#nullable disable warnings
using System;
using System.Globalization;
using System.Windows.Controls;

namespace Presentation.Validation.PersonRules
{
    public class DateOfBirthRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value == null) return new ValidationResult(false, "Required field");

            var birthDay = DateTime.Now.Year - ((DateTime)value).Year;

            if(birthDay < 18)
            {
                return new ValidationResult(false, "Person must be at leas 18 year");
            }

            return ValidationResult.ValidResult;
        }
    }
}
