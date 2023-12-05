using GAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
    }
}
