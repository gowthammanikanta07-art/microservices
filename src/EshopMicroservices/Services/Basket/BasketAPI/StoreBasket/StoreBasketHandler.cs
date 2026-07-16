using BasketAPI.Data;
using BasketAPI.Model;
using BuildingBlocks.CQRS;
using FluentValidation;
using Marten;

namespace BasketAPI.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) :
        ICommand<StoreBasketResult>;
    public record StoreBasketResult(ShoppingCart Cart);

    public class StoreBasketValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart cant be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Username is must");
            RuleFor(x => x.Cart.CartItems).NotEmpty().WithMessage("atleast one item is required");
        }
    }
    public class StoreBasketHandler(IBasketRepository basketRepo) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await basketRepo.StoreBasket(request.Cart, cancellationToken);
            return new StoreBasketResult(result);

        }
    }
}

