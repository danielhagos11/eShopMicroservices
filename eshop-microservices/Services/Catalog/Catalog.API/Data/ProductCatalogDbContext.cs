using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    public class ProductCatalogDbContext : DbContext
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options)
            :base(options) { }

        public DbSet<Product> Products { get; set; } = default!;

    }
}
