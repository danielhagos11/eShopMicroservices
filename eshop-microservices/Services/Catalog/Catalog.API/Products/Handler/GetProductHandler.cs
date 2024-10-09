using Catalog.API.Data;
using Catalog.API.Exceptions;
using Catalog.API.Products.Queries;

namespace Catalog.API.Products.Handler
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly ILogger _logger;
        private readonly ProductCatalogDbContext _context;
        public GetProductHandler(ProductCatalogDbContext context /*ILogger logger*/)
        {
            _context = context;
            //_logger = logger;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            //_logger.LogInformation(ProductLogEvent.GetItem, "Getting item {Id}", request.productId);
            var result = await _context.Products.FindAsync(request.productId);
            if (result is null) 
            {
                //_logger.LogWarning(ProductLogEvent.GetItemNotFound, "Get({Id}) NOT FOUND", request.productId);
                throw new ProductNotFoundException(request.productId);
            }        
            return result;
        }
    }
}
