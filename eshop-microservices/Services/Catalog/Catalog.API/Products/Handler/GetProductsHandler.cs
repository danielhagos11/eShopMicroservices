using Catalog.API.Data;
using Catalog.API.Products.Queries;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Products.Handler
{

    public class GetProductsHandler : IRequestHandler<GetProductsQueries, IEnumerable<Product>>
    {
        private readonly ProductCatalogDbContext _context;
        public GetProductsHandler(ProductCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQueries request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.ToListAsync(cancellationToken);
            return result;
        }
    }
}
