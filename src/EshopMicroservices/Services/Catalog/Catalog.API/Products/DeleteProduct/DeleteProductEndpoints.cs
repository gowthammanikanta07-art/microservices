namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid Id);
    public record DeleteProductResponse(bool status);
    public class DeleteProductEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/Products/{id}", async (Guid Id, ISender send) =>
            {
                var result = await send.Send(new DeleteProductCommand(Id));
                return Results.Ok(result);
            
            });
        }
    }
}
