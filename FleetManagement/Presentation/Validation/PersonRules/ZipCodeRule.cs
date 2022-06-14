#nullable disable warnings
using System;
using System.Globalization;
using System.Windows.Controls;

namespace Presentation.Validation.PersonRules
{
    public class ZipCodeRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(string.IsNullOrEmpty(value?.ToString())) return new ValidationResult(false, "Required field");

            try
            {
                var code = int.Parse(value.ToString());
                if(code < 1000 || code > 9992)
                {
                    return new ValidationResult(false, "Invalid zip code");
                }
            }
            catch(Exception)
            {
                return new ValidationResult(false, "Invalid zip code");
            }



            return ValidationResult.ValidResult;
        }
    }
}
