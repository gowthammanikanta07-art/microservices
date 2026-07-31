using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderDto Order) :
        ICommand<CreateOrderResult>;

     public record CreateOrderResult(Guid Id);

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Order name must be provided");
            RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId must not be null");
            RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems Should not be empty");
        }
    }

}
