namespace Catalog.API.Products.Queries
{
    public class GetProductByCategoryQuery : IRequest<IEnumerable<Product>>
    {
        public string productCategory { get; }
        public GetProductByCategoryQuery(string category)
        {
            productCategory = category;
        }
    }
}
