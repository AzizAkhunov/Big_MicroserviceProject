using Microsoft.EntityFrameworkCore;
using OLX.Domain.Entities;

namespace OLX.Infastructure.DbContexts
{
    public class OLXDbContext : DbContext
    {
        public OLXDbContext(DbContextOptions<OLXDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Buys)
                .WithOne(x => x.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(x => x.Cards)
                .WithOne(x => x.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
               .HasMany(x => x.Products)
               .WithOne(x => x.User)
               .HasForeignKey(e => e.UserId)
               .IsRequired();

            modelBuilder.Entity<Product>()
               .HasOne(x => x.Sell)
               .WithOne(x => x.Product)
               .HasForeignKey<Sell>(e => e.ProductId)
               .IsRequired();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Buy> Buys { get; set; }
        public DbSet<Sell> Sells { get; set; }
    }
}