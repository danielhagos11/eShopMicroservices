using Catalog.API.Data;
using Catalog.API.Products.Command;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Products.Handler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, bool>
    {
        private readonly ProductCatalogDbContext _context;
        public DeleteProductHandler(ProductCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Productss.FindAsync(request.Id);
            if (product != null) 
            { 
                _context.Productss.Remove(product);
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
