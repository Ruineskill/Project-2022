using Domain.Models;
using Domain.Models.TypeConvertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EntityTypeConfigurations
{
    public class FuelCardEntityTypeConfiguration : IEntityTypeConfiguration<FuelCard>
    {
        public void Configure(EntityTypeBuilder<FuelCard> builder)
        {
            builder.HasIndex(u => u.CardNumber).IsUnique();
            builder.Property(c => c.UsableFuelTypes).HasConversion<EnumListConverter, EnumListComparer>();
            builder.Property(e=>e.ExpirationDate).HasConversion<DateOnlyConverter,DateOnlyComparer>();

            builder.HasOne<Person>(p=>p.Person).WithOne(p=>p.FuelCard).HasForeignKey<Person>("FuelCardId").IsRequired(false);
      
        }
    }
}
