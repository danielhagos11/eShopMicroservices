using Catalog.API.Data;
using Catalog.API.Products.Command;
using JasperFx.CodeGeneration.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Products.Handler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, Product>
    {
        private readonly ProductCatalogDbContext _context;
        public UpdateProductHandler(ProductCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FindAsync(request.Product.Id);
            if(request.Id != request.Product.Id)
            {
                return request.Product;
            }

            _context.Entry(request.Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (!ProductExist(request.Product.Id))
                {
                    return request.Product;
                }
            }
            return request.Product;
        }
        private bool ProductExist(Guid id)
        {
            var product = _context.Products.Find(id);
            if (product.Id != null) return true;
            return false;           
        }
    }
}
