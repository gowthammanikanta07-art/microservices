using BasketAPI.Data;
using BasketAPI.Model;
using BuildingBlocks.CQRS;
using Discount.Grpc.Protos;
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
    public class StoreBasketHandler(IBasketRepository basketRepo,
        DiscountProtoService.DiscountProtoServiceClient discount ) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            await GetDiscountedPrice(request, cancellationToken);

            var result = await basketRepo.StoreBasket(request.Cart, cancellationToken);
            return new StoreBasketResult(result);

            async Task GetDiscountedPrice(StoreBasketCommand request, CancellationToken cancellationToken)
            {
                foreach (var item in request.Cart.CartItems)
                {
                    var discountPrice = await discount.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
                    item.Price -= discountPrice.Amount;
                }
            }
        }
    }
}

