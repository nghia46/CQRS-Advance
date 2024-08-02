using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ReadDbInfastructure
{
    public class ReadDbContext : DbContext
    {
        public DbSet<OrderView> OrderViews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=OrderReadDb; Username=postgres; Password=Abcd1234");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderView>().HasKey(o => o.OrderID);
        }
    }
}
