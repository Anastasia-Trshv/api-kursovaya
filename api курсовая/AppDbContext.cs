using api_курсовая.model;
using Microsoft.EntityFrameworkCore;

namespace api_курсовая
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyType> SupplyTypes { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-OHI96F6C\\SQLEXPRESS;Database=Kursovaya4sem;" +
                "Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>().HasKey(u => new { u.UserId, u.SupplyId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
