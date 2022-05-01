#nullable disable
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.EntityTypeConfigurations;

namespace Repository.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FuelCard> FuelCards { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FuelCardEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);

        }

    }
}
