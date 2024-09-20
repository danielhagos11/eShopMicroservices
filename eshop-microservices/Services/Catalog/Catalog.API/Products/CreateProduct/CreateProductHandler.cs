﻿namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,
        List<string> Category, string description, string ImageFile, decimal Price
        ) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Business logic to create a product
            // create product entity from command object           
            
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };
            // TODO
            // save to database
            session.Store( product );
            await session.SaveChangesAsync(cancellationToken);
            // return CreateProductResult result
            return new CreateProductResult(product.Id);
        }
    }
}
