using Catalog.API.Data;
using Catalog.API.Exceptions;
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
           var product = await _context.Products.FindAsync(request.Product.Id);
           if(product is null)
            {
                throw new ProductNotFoundException(request.Id);
            }

            _context.Entry(request.Product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
                 
            return request.Product;
        }
       
    }
}
