using Ordering.Domain.Events;
using System.Collections.Concurrent;

namespace Ordering.Domain.Models
{
    //Order is Aggregate Root
    public class Order : Aggregate<OrderId>
    {
        private readonly List<OrderItems> _orderItems = new();
        public IReadOnlyList<OrderItems> orderItems => _orderItems.AsReadOnly();

        public CustomerId CustomerId { get; private set; }
        public OrderName OrderName { get; private set; }
        public Address ShippingAddress { get; private set; }
        public Address BillingAddress { get; private set; }
        public Payment Payment { get; private set; }
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;

        public decimal TotalPrice
        {
            get => orderItems.Sum(x => x.Price * x.Quantity);
            private set { }
        }

        public static Order Create(OrderId id, CustomerId customerId, OrderName orderName,
            Address shipping, Address billing, Payment payment)
        {
            var order = new Order()
            {
                Id = id,
                CustomerId = customerId,
                OrderName = orderName,
                ShippingAddress = shipping,
                BillingAddress = billing,
                Payment = payment,
                Status = OrderStatus.Pending
            };

            order.AddDomainEvents(new OrderCreatedEvent(order));
            return order;
        }

        public void  Update(OrderName name, Address shipping, Address billing, Payment payment, OrderStatus status)
        {
            OrderName = name;
            ShippingAddress = shipping;
            BillingAddress = billing;
            Payment = payment;
            Status = status;

            AddDomainEvents(new OrderUpdatedEvent(this));
        }

        public void Add(ProductId productId, int quantity, decimal price)
        {
            var orderItem = new OrderItems(Id, productId, quantity, price);
            _orderItems.Add(orderItem);
        }

        public void Remove(ProductId productId)
        {
            var orderItem = _orderItems.FirstOrDefault(x => x.ProductId == productId);
            if(orderItem != null)
            {
                _orderItems.Remove(orderItem);
            }
        }
    }   
}
