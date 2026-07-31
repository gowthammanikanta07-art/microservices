using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Queries.GetOrders;

namespace Ordering.API.Endpoints
{
    //public record GetOrdersRequest(PaginationRequest PaginationRequest);
    public record GetOrdersResponse(PaginatedResult<OrderDto> Result);
    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async([AsParameters] PaginationRequest PaginationRequest, ISender sender) =>
            {
                
                var result = await sender.Send(new GetOrdersQuery(PaginationRequest));
                var response = result.Adapt<GetOrdersResponse>();
                return Results.Ok(response);
            })
            .WithName("GetOrders")
            .Produces<GetOrdersResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get All Order Summary")
            .WithDescription("Get All Order Description");
        }
    }
}
