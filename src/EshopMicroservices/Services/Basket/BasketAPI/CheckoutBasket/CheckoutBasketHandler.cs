using BasketAPI.Data;
using BasketAPI.Dtos;
using BuildingBlocks.CQRS;
using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Messaging.EventModel;
using Mapster;
using MassTransit;
using MassTransit.Testing;
using MediatR.NotificationPublishers;
using System.Windows.Input;

namespace BasketAPI.CheckoutBasket
{
    public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto)
        : ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResult(bool isSuccess);
    public class CheckoutBasketHandler(IBasketRepository repo , IPublishEndpoint endpoint) : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await repo.GetBasketDetails(request.BasketCheckoutDto.UserName, cancellationToken);
            if (basket == null)
            {
                return new CheckoutBasketResult(false);
            }

            var eventMessage = request.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
            eventMessage.TotalPrice = basket.TotalPrice;
            foreach(var item in basket.CartItems)
            {
                eventMessage.cartItems.Add(
                    new ShoppingCartItem()
                    {
                        Quantity = item.Quantity,
                        Price = item.Price,
                        ProductId = item.ProductId,
                        ProductName = item.ProductName
                    });
            }

            await endpoint.Publish(eventMessage, cancellationToken);

            await repo.DeleteBasket(request.BasketCheckoutDto.UserName, cancellationToken);

            return new CheckoutBasketResult(true);
        }
    }
}
