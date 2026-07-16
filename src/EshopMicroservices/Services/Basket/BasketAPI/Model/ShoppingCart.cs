using JasperFx;

namespace BasketAPI.Model
{
    public class ShoppingCart
    {
        [Identity]
        public string UserName { get; set; }
        public List<ShoppingCartItem> CartItems { get; set; } = new();
        public decimal TotalPrice => CartItems.Sum(i => i.Quantity * i.Price);

        public ShoppingCart(string username)
        {
            UserName = username;
        }

        public ShoppingCart()
        {
            
        }
    }

}
