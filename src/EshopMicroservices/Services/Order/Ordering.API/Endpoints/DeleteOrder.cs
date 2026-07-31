using Carter;
using Mapster;
using MediatR;
using Ordering.Application.Orders.Commands.DeleteOrder;
using Polly;

namespace Ordering.API.Endpoints
{
    public record DeleteOrderResponse(bool isSuccess);
    public class DeleteOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/order/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteOrderCommand(id));
                var response = result.Adapt<DeleteOrderResponse>();
                return Results.Ok(response);
            })
            .WithName("DeleteOrder")
            .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Order Summary")
            .WithDescription("Delete Order Description");
        }
    }
}
