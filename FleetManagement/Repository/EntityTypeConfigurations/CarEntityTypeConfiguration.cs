using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityTypeConfigurations
{
    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        /// <summary>
        /// EntityType configuration for a car
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            //builder.HasIndex(u => new { u.ChassisNumber, u.LicensePlate }).IsUnique(); // this is for joint index only
            builder.HasIndex(b => b.ChassisNumber).IsUnique();
            builder.HasIndex(b => b.LicensePlate).IsUnique();

            builder.HasOne<Person>(p=>p.Person).WithOne(p =>p.Car).HasForeignKey<Person>("CarId").IsRequired(false);

        }
    }
}
