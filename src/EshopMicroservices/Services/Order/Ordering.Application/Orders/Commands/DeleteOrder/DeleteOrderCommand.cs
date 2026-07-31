using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public record DeleteOrderCommand(Guid id)
            : ICommand<DeleteOrderResult>;

    public record DeleteOrderResult(bool isSuccess);

    public class DeleteOrderCommandValidator :
        AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.id).NotNull().WithMessage("Id Cant be null");
        }
    }
}
