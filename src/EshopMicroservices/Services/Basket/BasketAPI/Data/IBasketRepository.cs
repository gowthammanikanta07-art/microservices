using BasketAPI.DeleteBasket;
using BasketAPI.GetBasketById;
using BasketAPI.Model;
using BasketAPI.StoreBasket;
using System.Reflection.PortableExecutable;

namespace BasketAPI.Data
{
    public interface IBasketRepository
    {
        public Task<ShoppingCart> GetBasketDetails(string username,CancellationToken token);

        public Task<ShoppingCart> StoreBasket(ShoppingCart cart, CancellationToken token);

        public Task<bool> DeleteBasket(string username, CancellationToken token);
    }
}
