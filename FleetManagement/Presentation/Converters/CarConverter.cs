#nullable disable warnings
using Presentation.ViewModels;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Presentation.Converters
{
    internal class CarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null) return "None";

            var car = value as CarViewModel;
            return car.Brand + " " + car.Model;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
