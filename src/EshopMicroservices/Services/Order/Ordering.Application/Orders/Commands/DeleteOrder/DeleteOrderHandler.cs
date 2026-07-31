using BuildingBlocks.CQRS;
using Microsoft.AspNetCore.Builder;
using Ordering.Application.Data;
using Ordering.Application.Exceptions;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderHandler(IApplicationDbContext context) :
        ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public  async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var orderId = OrderId.Of(command.id);
            var order = await context.Orders.FindAsync([orderId], cancellationToken);
            if (order is null)
            {
                throw new OrderNotFoundException(orderId.Value);
            }

            context.Orders.Remove(order);
            await context.SaveChangesAsync(cancellationToken);

            return new DeleteOrderResult(true);
        }
    }
}
