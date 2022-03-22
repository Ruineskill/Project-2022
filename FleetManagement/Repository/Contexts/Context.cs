using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FuelCard> FuelCards { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            //User Relations & Requirements
            modelBuilder.Entity<Person>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Person>()
                .HasIndex(u => u.NationalRegistrationNumber)
                .IsUnique();

            modelBuilder.Entity<Person>(builder =>
            {
                // DateOfBirth is a DateOnly property and Date on database
                builder.Property(x => x.DateOfBirth)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });

            //modelBuilder.Entity<Person>()
            //    .HasOne<FuelCard>(s => s.FuelCard)
            //    .WithOne(ad => ad.User)
            //    .HasForeignKey<FuelCard>(ad => ad.Id);

            modelBuilder.Entity<Person>()
                .HasOne<Car>(s => s.Car)
                .WithOne(ad => ad.Person)
                .HasForeignKey<Car>(ad => ad.Id);

            //Address Relations & Requirements
            modelBuilder.Entity<Address>().HasKey(k => k.Id);


            //Vehicle Relations & Requirements
            modelBuilder.Entity<Car>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Car>()
                .HasIndex(u => new { u.ChassisNumber, u.LicensePlate })
                .IsUnique();

            //FuelCard Requirements
            modelBuilder.Entity<FuelCard>()
                .HasIndex(u => u.CardNumber)
                .IsUnique();

            //Many to Many Relation
            //modelBuilder.Entity<FuelCardFuel>()
            //    .HasKey(bc => new { bc.FuelId, bc.FuelCardId });
            //modelBuilder.Entity<FuelCardFuel>()
            //    .HasOne(bc => bc.Fuel)
            //    .WithMany(b => b.FuelCards)
            //    .HasForeignKey(bc => bc.FuelId);
            //modelBuilder.Entity<FuelCardFuel>()
            //    .HasOne(bc => bc.FuelCard)
            //    .WithMany(c => c.Fuels)
            //    .HasForeignKey(bc => bc.FuelCardId);
        }

        //Connection Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=sql5103.site4now.net;Initial Catalog=db_a83a71_fm;User Id=db_a83a71_fm_admin;Password=Connect2022;");
        }
    }
}
