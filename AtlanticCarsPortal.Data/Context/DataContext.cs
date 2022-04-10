using AtlanticCarsPortal.Data.Seed;
using AtlanticCarsPortal.Domain;
using Microsoft.EntityFrameworkCore;

namespace AtlanticCarsPortal.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedModel();
        }

    }
}