﻿using System.Globalization;
using System.Windows.Controls;

namespace Presentation.Validation
{
    public class NotEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return new ValidationResult(false, "Required field");
            }
            return ValidationResult.ValidResult;
        }

       
    }
}
