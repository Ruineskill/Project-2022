#nullable disable
using Domain.Models.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.TypeConvertors
{
    /// <summary>
    /// Converter for EF core to convert ENUM flags to collection and collection to ENUM flags
    /// </summary>
    public class EnumListConverter : ValueConverter<ICollection<FuelType>, int>
    {
        public EnumListConverter() : base(
            licenseTypes => ToBiteFlag(licenseTypes),
            values => Enum.GetValues(typeof(FuelType)).Cast<FuelType>().ToList())
        { }

        private static int ToBiteFlag(ICollection<FuelType> licenseTypes)
        {
            int result = 0;
            foreach (var lt in licenseTypes)
            {
                result |= ((int)lt);
            }
            return result;
        }
    }

    /// <summary>
    /// Comparer for EF Core to compare for Enum Collection
    /// </summary>
    public class EnumListComparer : ValueComparer<ICollection<FuelType>>
    {
        public EnumListComparer() : base(
          (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList())
        {
        }
    }
}
