namespace Catalog.API.Products.Command
{
    public class DeleteProductRequest : IRequest<bool>
    {
        public Guid Id { get; }
        public DeleteProductRequest(Guid prodoctId)
        {
            Id = prodoctId;
        }
    }
}
