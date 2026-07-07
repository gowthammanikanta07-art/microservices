using Catalog.API.Products.Exceptions;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductsByIdQuery(Guid id) : IQuery<GetProductsByIdResponse>;

    public record GetProductsByIdResponse(Product product);
    public class GetProductByIdHandler(IQuerySession session) : IQueryHandler<GetProductsByIdQuery, GetProductsByIdResponse>
    {
        public async Task<GetProductsByIdResponse> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var id = request.id;
            var result = await session.LoadAsync<Product>(id,cancellationToken);

            if (result != null)
                return new GetProductsByIdResponse(result);
            else
                throw new ProductNotFoundException(request.id);
        }
    }
}
