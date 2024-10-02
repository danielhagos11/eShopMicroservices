
using Catalog.API.Data;
using JasperFx.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;

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

        public async Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken)
        {
            var results = await _context.Products.ToListAsync(cancellationToken);
            return results;
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
