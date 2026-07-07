
namespace Catalog.API.Products.CreateProduct
{
    record CreateProductRequest(string name, List<string> category,
                    string description, string imagefile, decimal price);
    record CreateProductResponse(Guid id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            { 
                var command = request.Adapt<CreateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.id}", response);
            }
            );
        }
    }
}
