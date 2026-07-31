using Carter;
using Mapster;
using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.API.Endpoints
{
    //public record GetOrdersByNameRequest(string orderName);
    public record GetOrdersByNameResponse(IEnumerable<OrderDto> orders);
    public class GetOrdersByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{ordername}", async(string ordername, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByNameQuery(ordername));
                var response = result.Adapt<GetOrdersByNameResponse>();
                return Results.Ok(response);
            })
            .WithName("GetOrdersByName")
            .Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Order By Name Summary")
            .WithDescription("Get Order By Name Description");
        }
    }
}
