using Catalog.API.Data;
using Catalog.API.Products.Command;

namespace Catalog.API.Products.Handler
{
    
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Product>
    {
        private readonly ProductCatalogDbContext _context;
        public CreateProductHandler(ProductCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = request.ProductRequest;
            if (_context.Products == null) 
            {
                return null;
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
