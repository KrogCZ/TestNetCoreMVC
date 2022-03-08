using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<City>().HasKey(x => x.Id);
            base.OnModelCreating(builder);
        }
    }
}
