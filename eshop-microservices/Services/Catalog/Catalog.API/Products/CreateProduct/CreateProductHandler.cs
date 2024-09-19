﻿using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,
        List<string> Category, string description, string ImageFile, decimal Price
        ) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
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
            // return CreateProductResult result
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
