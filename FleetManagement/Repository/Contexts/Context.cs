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
        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Fuel> Fuel { get; set; }
        public DbSet<FuelCardFuel> FuelCardFuel { get; set; }
        public DbSet<FuelCard> FuelCard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User Relations & Requirements
            modelBuilder.Entity<User>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.NationRegistrationNumber)
                .IsUnique();

            modelBuilder.Entity<User>(builder =>
            {
                // DateOfBirth is a DateOnly property and Date on database
                builder.Property(x => x.DayOfBirth)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });

            modelBuilder.Entity<User>()
                .HasOne<FuelCard>(s => s.FuelCard)
                .WithOne(ad => ad.User)
                .HasForeignKey<FuelCard>(ad => ad.Id);

            modelBuilder.Entity<User>()
                .HasOne<Vehicle>(s => s.Vehicle)
                .WithOne(ad => ad.User)
                .HasForeignKey<Vehicle>(ad => ad.Id);


            //Vehicle Relations & Requirements
            modelBuilder.Entity<Vehicle>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Vehicle>()
                .HasIndex(u => new { u.ChassisNumber, u.LicensePlate })
                .IsUnique();

            //FuelCard Requirements
            modelBuilder.Entity<FuelCard>()
                .HasIndex(u => u.CardNumber)
                .IsUnique();

            //Many to Many Relation
            modelBuilder.Entity<FuelCardFuel>()
                .HasKey(bc => new { bc.FuelId, bc.FuelCardId });
            modelBuilder.Entity<FuelCardFuel>()
                .HasOne(bc => bc.Fuel)
                .WithMany(b => b.FuelCards)
                .HasForeignKey(bc => bc.FuelId);
            modelBuilder.Entity<FuelCardFuel>()
                .HasOne(bc => bc.FuelCard)
                .WithMany(c => c.Fuels)
                .HasForeignKey(bc => bc.FuelCardId);
        }

        //Connection Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=sql5103.site4now.net;Initial Catalog=db_a83a71_fm;User Id=db_a83a71_fm_admin;Password=Connect2022;");
        }
    }
}
