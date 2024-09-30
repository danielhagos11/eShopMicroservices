using Catalog.API.Data;
using Catalog.API.Services;

namespace Catalog.API.Products.CreateProduct 
{
   
    public record CreateProductCommand(Guid Id, string Name,
        List<string> Category, string Description, string ImageFile, decimal Price
        ) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductHandler
        (IProductCatalogRepository context)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
{
       
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //create Product entity from command object
        //save to database
        //return CreateProductResult result               
        //var Id = Guid.NewGuid();
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        //save to database
        await context.AddProduct(product);
        //await context.SaveChangesAsync(cancellationToken);

        //return result
        //return new CreateProductResult(//product.Id);
        return new CreateProductResult(product.Id);
    }
}
}
