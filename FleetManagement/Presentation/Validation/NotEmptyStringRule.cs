#nullable disable warnings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace Presentation.Validation
{
    class NotEmptyStringRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var result = value?.ToString();
            if(string.IsNullOrWhiteSpace(result))
            {
                return new ValidationResult(false, "Required field");
            }

            if(result.Any(char.IsDigit))
            {
                return new ValidationResult(false, "Numbers are not allowed");
            }

            return ValidationResult.ValidResult;
        }
    }
}
