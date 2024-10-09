using Catalog.API.Data;
using Catalog.API.Products.Queries;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Products.Handler
{

    public class GetProductsHandler : IRequestHandler<GetProductsQueries, IEnumerable<Product>>
    {
        private readonly ProductCatalogDbContext _context;
        private readonly ILogger _logger;
        public GetProductsHandler(ProductCatalogDbContext context/*, ILogger logger*/)
        {
            _context = context;
            //_logger = logger;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQueries request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.ToListAsync(cancellationToken);
            //_logger.LogInformation(ProductLogEvent.GetItem, "Getting List of products");
            return result;
        }
    }
}
