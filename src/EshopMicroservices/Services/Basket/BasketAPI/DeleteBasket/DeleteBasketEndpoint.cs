using Carter;
using Mapster;
using MediatR;

namespace BasketAPI.DeleteBasket
{
    //public record DeleteBasketRequest(string Username);
    public record DeleteBasketResponse(bool IsSuccess);
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/DeleteCart/{username}", async (string username, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(username));
                return Results.Ok(result);
            });
        }
    }
}
