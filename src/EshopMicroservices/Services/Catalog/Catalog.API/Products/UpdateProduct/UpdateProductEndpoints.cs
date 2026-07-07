namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Product Product);
    public record UpdateProductResponse(Product Product);
    public class UpdateProductEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products/", async(UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var response = await sender.Send(command);
                var result = response.Adapt<UpdateProductResponse>();
                return Results.Ok(result);
            });

        }
    }
}
