using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Models.TypeConvertors
{
    /// <summary>
    /// Converter for EF Core to convert DateOnly to DateTime and DateTime to DateOnly
    /// </summary>
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime))
        {
        }
    }

    /// <summary>
    /// Comparer for EF Core to compare DateOnly
    /// </summary>
    public class DateOnlyComparer : ValueComparer<DateOnly>
    {
        public DateOnlyComparer() : base(
            (d1, d2) => d1.DayNumber == d2.DayNumber,
            d => d.GetHashCode())
        {
        }
    }
}
