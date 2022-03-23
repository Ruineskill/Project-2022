using Domain.Models;
using Domain.Models.TypeConvertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EntityTypeConfigurations
{
    public class FuelCardEntityTypeConfiguration : IEntityTypeConfiguration<FuelCard>
    {
        public void Configure(EntityTypeBuilder<FuelCard> builder)
        {
            builder.HasIndex(u => u.CardNumber).IsUnique();
            builder.Property(c => c.UsableFuelTypes).HasConversion<EnumListConverter,EnumListComparer>();
            builder.Property(e => e.ExpirationDate).HasConversion<DateOnlyConverter, DateOnlyComparer>();
        }
    }
}