using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Extensions;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerHandler(IApplicationDbContext context)
        : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
    {
        public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
        {
            var orders = await context.Orders
                .Include(o => o.orderItems)
                .AsNoTracking()
                .Where(o => o.CustomerId == CustomerId.Of(query.customerId))
                .OrderBy(o => o.OrderName.Value)
                .ToListAsync();

            return new GetOrdersByCustomerResult(orders.ToOrderDtoList());
                
        }
    }
}
