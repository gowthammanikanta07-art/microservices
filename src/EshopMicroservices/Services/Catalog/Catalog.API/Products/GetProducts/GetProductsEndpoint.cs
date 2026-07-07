namespace Catalog.API.Products.GetProducts
{
    
    public record GetProductsResponse(List<Product> product);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResult>();

                return Results.Ok(response);
            });
        }
    }
}
