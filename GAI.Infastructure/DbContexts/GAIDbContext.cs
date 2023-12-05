using GAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GAI.Infastructure.DbContexts
{
    public class GAIDbContext : DbContext
    {
        public GAIDbContext(DbContextOptions<GAIDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<YPX> GAies { get; set; }
        public DbSet<Punishment> Punishments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .HasMany(x => x.Punishments)
                .WithOne(x => x.Driver)
                .HasForeignKey(e => e.DriverId)
                .IsRequired();

            modelBuilder.Entity<YPX>()
                .HasMany(x => x.Punishments)
                .WithOne(x => x.YPX)
                .HasForeignKey(e => e.YPX_Id)
                .IsRequired();
        }
    }
}
