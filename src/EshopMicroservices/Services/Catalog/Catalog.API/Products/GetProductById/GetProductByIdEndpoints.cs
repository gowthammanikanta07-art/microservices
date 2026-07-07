using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductsByIdRequest();
    public record GetProductsByIdResult(Product Product);
    public class GetProductByIdEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductsByIdQuery(id));
                var response = result.Adapt<GetProductsByIdResult>();

                return Results.Ok(response);
            });
        }
    }
}
