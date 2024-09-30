
using Catalog.API.Data;

namespace Catalog.API.Services
{
    public class ProductRepository : IProductCatalogRepository
    {
        private readonly ProductCatalogDbContext _context;
        public ProductRepository(ProductCatalogDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var result = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
