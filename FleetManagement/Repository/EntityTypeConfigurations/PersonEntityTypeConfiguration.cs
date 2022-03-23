using Domain;
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
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(u => u.NationalRegistrationNumber).IsUnique();

            builder.Property(x => x.DateOfBirth).HasConversion<DateOnlyConverter, DateOnlyComparer>();

            builder.HasOne(s => s.FuelCard).WithOne(ad => ad.Person).HasForeignKey<FuelCard>(ad => ad.Id); ;

            builder.HasOne(s => s.Car).WithOne(ad => ad.Person).HasForeignKey<Car>(ad => ad.Id);

            builder.OwnsOne(d => d.Address);
        }
    }
}
