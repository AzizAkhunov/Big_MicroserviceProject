using Microsoft.EntityFrameworkCore;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Infastructure.DbContexts
{
    public class YandexTaxiDbContext : DbContext 
    {
        public YandexTaxiDbContext(DbContextOptions<YandexTaxiDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Driver)
                .HasForeignKey(x => x.DriverId)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .HasOne(x => x.Car)
                .WithOne(x => x.Driver)
                .HasForeignKey<Car>(x => x.DriverId)
                .IsRequired();

            modelBuilder.Entity<Client>()
               .HasMany(x => x.Cards)
               .WithOne(x => x.Client)
               .HasForeignKey(x => x.ClientId)
               .IsRequired();

            modelBuilder.Entity<Client>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .IsRequired();
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Scrin> Scrins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
