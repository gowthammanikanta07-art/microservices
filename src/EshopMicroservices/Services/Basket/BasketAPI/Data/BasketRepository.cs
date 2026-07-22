using BasketAPI.DeleteBasket;
using BasketAPI.Exceptions;
using BasketAPI.GetBasketById;
using BasketAPI.Model;
using BasketAPI.StoreBasket;
using Marten;

namespace BasketAPI.Data
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasketDetails(string username, CancellationToken token)
        {
            var basket = await session.LoadAsync<ShoppingCart>(username,token);
            return basket is null ? throw new BasketNotFoundException(username) : basket; ;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart cart,CancellationToken token)
        {
            session.Store(cart);
            await session.SaveChangesAsync(token);
            return cart;
        }
        public async Task<bool> DeleteBasket(string username, CancellationToken token)
        {
            session.Delete<ShoppingCart>(username);
            await session.SaveChangesAsync(token);
            return true;
        }
    }
}
