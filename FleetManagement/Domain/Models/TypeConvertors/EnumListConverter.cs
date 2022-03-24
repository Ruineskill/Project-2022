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
