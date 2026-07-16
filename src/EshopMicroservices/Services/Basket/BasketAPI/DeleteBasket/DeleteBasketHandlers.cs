using BasketAPI.Data;
using BuildingBlocks.CQRS;

namespace BasketAPI.DeleteBasket
{
    public record DeleteBasketCommand(string username):
        ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);
    public class DeleteBasketHandlers(IBasketRepository basketRepo) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await basketRepo.DeleteBasket(request.username, cancellationToken);
            return new DeleteBasketResult(result);
        }
    }
}
