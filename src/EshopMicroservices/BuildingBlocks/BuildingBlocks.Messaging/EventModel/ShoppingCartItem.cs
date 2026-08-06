using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Messaging.EventModel
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; } = default!;
        public string Color { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
    }
}

        
    
