#nullable disable warnings
using Presentation.ViewModels;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Presentation.Converters
{
    internal class FuelCardConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null) return "None";

            var fuelCard = value as FuelCardViewModel;
            return fuelCard.CardNumber.ToString();
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

     
    }
}
