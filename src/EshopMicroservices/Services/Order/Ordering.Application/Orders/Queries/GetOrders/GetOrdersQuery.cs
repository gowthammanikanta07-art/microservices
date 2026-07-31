using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Ordering.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Queries.GetOrders
{
    public record GetOrdersQuery(PaginationRequest PaginationRequest)
        : IQuery<GetOrdersResult>;

    public record GetOrdersResult(PaginatedResult<OrderDto> orders);
}
