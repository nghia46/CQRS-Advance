using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventStore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=EventStoreDb; Username=postgres; Password=Abcd1234");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasKey(o => o.EventId);
        }
    }
}
