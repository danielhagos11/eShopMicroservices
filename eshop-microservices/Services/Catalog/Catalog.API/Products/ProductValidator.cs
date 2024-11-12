namespace Catalog.API.Products
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(p => p.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(p => p.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
