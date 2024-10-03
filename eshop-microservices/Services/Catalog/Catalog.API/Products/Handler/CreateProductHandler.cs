using Catalog.API.Data;
using Catalog.API.Extensions;
using Catalog.API.Products.Command;
using OpenTelemetry.Trace;

namespace Catalog.API.Products.Handler
{
    
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Product>
    {
        private readonly ProductCatalogDbContext _context;
        private readonly ProductValidator _validator;
        public CreateProductHandler(ProductCatalogDbContext context, ProductValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<Product> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
          
            var product = request.ProductRequest;
            var validateResult = _validator.Validate(product);
            if (validateResult.IsValid)
            {
                await _context.AddAsync(product);
            }
           
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
