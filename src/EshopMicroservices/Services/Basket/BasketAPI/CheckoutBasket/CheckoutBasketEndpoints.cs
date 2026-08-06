using BasketAPI.Dtos;
using Carter;
using Mapster;
using MediatR;

namespace BasketAPI.CheckoutBasket
{
    public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);
    public record CheckoutBasketResponse(bool isSuccess);
    public class CheckoutBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<CheckoutBasketCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CheckoutBasketResponse>();

                return Results.Ok(response);
            });
        }
    }
}
