using Domain.Models;
using Domain.Models.Enums;
using Domain.Models.TypeConvertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EntityTypeConfigurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.HasIndex(u => u.NationalRegistrationNumber).IsUnique();

            builder.Property(x => x.DateOfBirth).HasConversion<DateOnlyConverter, DateOnlyComparer>();

            // car
            builder.HasOne<Car>(b => b.Car).WithOne(b => b.Person).HasForeignKey<Car>("PersonId").IsRequired(false);

            //fuelcard
            builder.HasOne<FuelCard>(b => b.FuelCard).WithOne(b => b.Person).HasForeignKey<FuelCard>("PersonId").IsRequired(false);

            builder.OwnsOne(d => d.Address);


        }
    }
}
