namespace Catalog.API.Services
{
    public interface IProductCatalogRepository
    {
        Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken);
        Task<Product> GetProduct(int productId);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
