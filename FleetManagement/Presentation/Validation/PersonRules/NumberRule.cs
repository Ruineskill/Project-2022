using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace Presentation.Validation.PersonRules
{
    public class NumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int number;
            if(string.IsNullOrWhiteSpace(value?.ToString()) || !int.TryParse(value.ToString(), out number))
            {
                return new ValidationResult(false, "Required field");
            }

            if(number<=0)
            {
                return new ValidationResult(false, "Value must be greater than 0");
            }


            return ValidationResult.ValidResult;
        }
    }
}
