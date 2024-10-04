namespace Catalog.API.Products.Command
{
    public class UpdateProductRequest : IRequest<Product>
    {
        public Product Product { get; }
        public Guid Id { get; }

        public UpdateProductRequest(Guid id, Product product)
        {
            Id = id;
            Product = product;
        }
    }
}
