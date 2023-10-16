using Microsoft.EntityFrameworkCore;
using E_Healthcare;

namespace E_Healthcare
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            // Define DbSet properties for your entities
            public DbSet<User> Users { get; set; }
            public DbSet<Medicine> Medicines { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Cart> Carts { get; set; }
            public DbSet<CartItem> CartItems { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Define entity relationships and constraints
                modelBuilder.Entity<User>()
                    .HasOne(u => u.Cart)
                    .WithOne(c => c.User)
                    .HasForeignKey<Cart>(c => c.UserId);

                modelBuilder.Entity<CartItem>()
                    .HasOne(ci => ci.Medicine)
                    .WithMany(m => m.CartItems)
                    .HasForeignKey(ci => ci.MedicineId);

                modelBuilder.Entity<CartItem>()
                    .HasOne(ci => ci.Cart)
                    .WithMany(c => c.CartItems)
                    .HasForeignKey(ci => ci.CartId);

                modelBuilder.Entity<Medicine>()
                    .HasOne(m => m.Category)
                    .WithMany(c => c.Medicines)
                    .HasForeignKey(m => m.CategoryId);

            }
    }
}
