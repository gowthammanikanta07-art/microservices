namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Product Product) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(Product Product);
    public class UpdateProductHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updateProduct = await session.LoadAsync<Product>(request.Product.Id);
            updateProduct = request.Product;

            session.Update(updateProduct);
            await session.SaveChangesAsync(cancellationToken);
            return new UpdateProductResult(updateProduct);
        }
    }
}
