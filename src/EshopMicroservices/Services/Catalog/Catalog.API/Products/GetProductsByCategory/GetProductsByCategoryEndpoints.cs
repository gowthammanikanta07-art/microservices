using JasperFx.Core.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.GetProductsByCategory
{
    //public record GetProductsByCategoryRequest();
    public record GetProductsByCategoryResponse(IEnumerable<Product> Products);

    public class GetProductsByCategoryEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category", async ([FromQuery]string Category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductsByCategoryQuery(Category));
                var response = result.Adapt<GetProductsByCategoryResponse>();

                return Results.Ok(response);
            });
        }
    }
}
