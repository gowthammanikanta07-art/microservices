using BasketAPI.Model;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BasketAPI.Data
{
    public class CachedBasketRepository(IBasketRepository repo , IDistributedCache cache) : IBasketRepository
    {
        
        public async Task<ShoppingCart> GetBasketDetails(string username, CancellationToken token)
        {
            var cachedBasket = await cache.GetStringAsync(username, token);
            if (cachedBasket is not null)
                return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;

            var basket = await repo.GetBasketDetails(username, token);
            await cache.SetStringAsync(username, JsonSerializer.Serialize(basket),token);
            return basket; 
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart cart, CancellationToken token)
        {
            await repo.StoreBasket(cart, token);
            await cache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart),token);
            return cart;

        }

        public async Task<bool> DeleteBasket(string username, CancellationToken token)
        {
            await repo.DeleteBasket(username, token);
            await cache.RemoveAsync(username, token);
            return true;
        }

    }
}
