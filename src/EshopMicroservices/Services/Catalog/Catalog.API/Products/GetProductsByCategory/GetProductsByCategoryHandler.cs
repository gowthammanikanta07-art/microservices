namespace Catalog.API.Products.GetProductsByCategory
{
    public record GetProductsByCategoryQuery(string category) : IQuery<GetProductsByCategoryResult>;
    public record GetProductsByCategoryResult(IEnumerable<Product> Products);
    public class GetProductsByCategoryHandler(IQuerySession session, ILogger<GetProductsByCategoryQuery> logger) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
    {
        public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {

            logger.LogInformation(string.Format("Started fetching products by category : {0}",request.category));
            var result = await session.Query<Product>().Where(cat => cat.Category.Contains(request.category)).ToListAsync(cancellationToken);
            return new GetProductsByCategoryResult(result);
        }
    }
}
