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
    }
}