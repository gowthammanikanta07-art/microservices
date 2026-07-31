using Ordering.Domain.Enums;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Dtos
{
    public record OrderDto(
        Guid Id,
        Guid CustomerId,
        string OrderName,
        AddressDto ShippingAddress,
        AddressDto BillingAddress,
        PaymentDto Payment,
        OrderStatus Status,
        List<OrderItemDto> OrderItems);
}
