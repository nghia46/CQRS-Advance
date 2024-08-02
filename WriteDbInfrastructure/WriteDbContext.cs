using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WriteDbInfrastructure
{
    public class WriteDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=OrderWriteDb; Username=postgres; Password=Abcd1234");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => o.OrderID);
        }
    }
}
