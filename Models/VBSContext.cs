using Microsoft.EntityFrameworkCore;

namespace VBSApi.Models
{
    public class VBSContext : DbContext
    {
        public VBSContext(DbContextOptions<VBSContext> options)
            : base(options)
        {
        }

        public DbSet<BookItem> BookItems { get; set; }
        public DbSet<ReviewItem> ReviewItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryItem> DeliveryItems { get; set; }
    }
}