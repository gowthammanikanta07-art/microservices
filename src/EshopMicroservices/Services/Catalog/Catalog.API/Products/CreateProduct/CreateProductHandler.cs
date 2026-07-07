namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category,
                    string description, string imagefile, decimal price) :
        ICommand<CreateProductResult>;
    public record CreateProductResult(Guid id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.description).NotEmpty().WithMessage("descriptio is required");
            RuleFor(x => x.imagefile).NotEmpty().WithMessage("imagefile is required");
            RuleFor(x => x.price).GreaterThan(0).WithMessage("price must be greater than 0");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        }
    }
    public class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {

        public async  Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = command.Name.ToLower(),
                Category = command.Category.Select(c => c.ToLower()).ToList(),
                Description = command.description.ToLower(),
                ImageFile = command.imagefile.ToLower(),
                Price = command.price
            };

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);      
        }
    }
}
