namespace Catalog.API.Products.Command
{
    public class CreateProductRequest : IRequest<Product>
    {
        public Product ProductRequest { get; }
        public CreateProductRequest(Product product)
        {
            ProductRequest = product;
        }
    }
}
