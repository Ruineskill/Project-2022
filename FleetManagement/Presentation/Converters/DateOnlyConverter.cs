using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Presentation.Converters
{
    public class DateOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null) return DateTime.Now;

            var dateOnly = (DateOnly)value;

            DateTime? datetime = dateOnly.ToDateTime(TimeOnly.MinValue, DateTimeKind.Local);

            return datetime;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {



            if(value == null) return DateOnly.FromDateTime(DateTime.Now);

            var date = (DateTime)value;

            return DateOnly.FromDateTime(date);
        }
    }
}
