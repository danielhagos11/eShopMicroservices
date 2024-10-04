namespace Catalog.API.Data.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ProductCatalogDbContext _context;
        public DbInitializer(ProductCatalogDbContext context)
        {
            _context = context;
        }
        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex) { }

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "William",
                Category = ["equip"],
                ImageFile = "www/images",
                Description = "lorem ipsum",
                Price = 211
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
