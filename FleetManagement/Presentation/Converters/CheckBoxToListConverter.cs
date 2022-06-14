#nullable disable warnings
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Presentation.Converters
{
    internal class CheckBoxToListConverter : IValueConverter
    {
        ICollection<FuelType>? _fuelList;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fuel = (FuelType)parameter;
            _fuelList = (ICollection<FuelType>)value;
            
            return _fuelList.Contains(fuel);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isChecked = (bool)value;
            var fuel = (FuelType)parameter;
            if(isChecked)
            {
                _fuelList?.Add(fuel);
            }
            else
            {
                _fuelList?.Remove(fuel);
            }
            return _fuelList;
        }
    }
}
