using Catalog.API.Data;
using Catalog.API.Products.Queries;

namespace Catalog.API.Products.Handler
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly ProductCatalogDbContext _context;
        public GetProductHandler(ProductCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.FindAsync(request.productId);
            if (result == null) return null;
            return result;
        }
    }
}
