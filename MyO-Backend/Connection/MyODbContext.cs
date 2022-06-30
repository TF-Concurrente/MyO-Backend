using Microsoft.EntityFrameworkCore;

namespace MyO_Backend.Connection
{
    public class MyODbContext : DbContext
    {
        public MyODbContext(DbContextOptions<MyODbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
        }
    }
}
