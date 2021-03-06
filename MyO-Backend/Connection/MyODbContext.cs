using Microsoft.EntityFrameworkCore;
using MyO_Backend.Models;

namespace MyO_Backend.Connection
{
    public class MyODbContext : DbContext
    {
        public MyODbContext(DbContextOptions<MyODbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
