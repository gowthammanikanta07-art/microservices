using BasketAPI.Model;
using Carter;
using Mapster;
using MediatR;

namespace BasketAPI.GetBasketById
{
    //public record GetBasketRequest(string userName);
    public record GetBasketResponse(ShoppingCart cart);

    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{username}",async(string username,ISender sender) =>
            {
                var response = await sender.Send(new GetBasketQuery(username));
                var result = response.Adapt<GetBasketResponse>();
                return Results.Ok(result);
            });
        }
    }
}
