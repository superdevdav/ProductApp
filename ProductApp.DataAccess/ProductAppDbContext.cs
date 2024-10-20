using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess.Entities;

namespace ProductApp.DataAccess
{
    public class ProductAppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

        public ProductAppDbContext(DbContextOptions<ProductAppDbContext> options) 
            : base(options) 
        {
        }

    }
}
