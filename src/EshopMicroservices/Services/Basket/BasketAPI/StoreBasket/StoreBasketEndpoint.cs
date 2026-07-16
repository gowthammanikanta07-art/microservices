using BasketAPI.Model;
using Carter;
using Mapster;
using MediatR;

namespace BasketAPI.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart);
    public record StoreBasketResponse(ShoppingCart Cart);
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/CreateCart", async (StoreBasketRequest req, ISender sender) =>
            {
                var request = req.Adapt<StoreBasketCommand>();
                var result = await sender.Send(request);
                var response = result.Adapt<StoreBasketResponse>();
                return Results.Created($"{response.Cart}", response); ;
            });
        }
    }
}
