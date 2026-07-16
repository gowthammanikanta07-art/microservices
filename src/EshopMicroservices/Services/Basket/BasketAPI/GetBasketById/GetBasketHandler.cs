using BasketAPI.Data;
using BasketAPI.Exceptions;
using BasketAPI.Model;
using BuildingBlocks.CQRS;
using Marten;
using MediatR;

namespace BasketAPI.GetBasketById
{
    public record GetBasketQuery(string username):IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart cart);
    public class GetBasketQueryHandler(IBasketRepository basketRepo): IQueryHandler<GetBasketQuery, GetBasketResult>        
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var result = await basketRepo.GetBasketDetails(request.username, cancellationToken);
            return new GetBasketResult(result);
        }
    }
}
