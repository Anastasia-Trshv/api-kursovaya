using api_курсовая.model;
using Microsoft.EntityFrameworkCore;

namespace api_курсовая
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<SupplyEntity> Supplies { get; set; }
        public DbSet<SupplyTypeEntity> SupplyTypes { get; set; }
        public DbSet<ShoppingCartEntity> ShoppingCart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-OHI96F6C\\SQLEXPRESS;Database=Kursovaya4sem;" +
                "Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCartEntity>().HasKey(u => new { u.UserId, u.SupplyId });
            base.OnModelCreating(modelBuilder);
                
        }
    }
}
