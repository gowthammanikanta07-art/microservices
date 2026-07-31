using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(OrderDto Order)
                    : ICommand<UpdateOrderResult>;

    public record UpdateOrderResult(bool isIsuccess);

    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Order.Id).NotNull().WithMessage("Id Cannot be null");
            RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId must not be null");
            RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name Should not be empty");
        }
    }
}
