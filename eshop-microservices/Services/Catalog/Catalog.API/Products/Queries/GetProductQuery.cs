namespace Catalog.API.Products.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public Guid productId { get; }
        public GetProductQuery(Guid id)
        {
            productId = id;
        }
    }
}
