using BuildingBlocks.Messaging.Events;
using MassTransit;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Commands.CreateOrder;
using Ordering.Domain.Models;

namespace Ordering.Application.Orders.EventHandlers.Integration
{
    public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger) :
        IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            logger.LogInformation("Integration Event Handled: {IntegrationEvent}", context.Message.GetType);

            var command = MapToCreateOrderCommand(context.Message);
            await sender.Send(command);
        }

        private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
        {
            var addressDto = new AddressDto(message.FirstName,message.LastName,message.EmailAddress,message.AddressLine,message.Country,message.State,message.ZipCode);
            var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.Cvv, message.PaymentMethod);
            var orderId =  Guid.NewGuid();

            var orderDto = new OrderDto(
                Id: orderId,
                CustomerId: message.CustomerId,
                OrderName: message.UserName,
                ShippingAddress: addressDto,
                BillingAddress: addressDto,
                Payment: paymentDto,
                Status: Ordering.Domain.Enums.OrderStatus.Pending,
                OrderItems: message.cartItems.
                        Select(oi =>
                        new OrderItemDto
                        (orderId, oi.ProductId, oi.Quantity, oi.Price)
                        ).ToList()
                );
               
            
            return new CreateOrderCommand(orderDto);
        }
    }
}
