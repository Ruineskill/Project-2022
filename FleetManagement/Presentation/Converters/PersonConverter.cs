#nullable disable warnings
using Presentation.ViewModels;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Presentation.Converters
{
    internal class PersonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null) return "None";
            var person = value as PersonViewModel;

            return person.FirstName + " " + person.LastName;
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
