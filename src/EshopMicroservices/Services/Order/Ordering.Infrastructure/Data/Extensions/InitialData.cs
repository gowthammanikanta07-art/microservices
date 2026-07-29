using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ordering.Infrastructure.Data.Extensions
{
    public class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
            {
                Customer.Create(CustomerId.Of(new Guid("064A20E5-82AE-4385-A4E5-C0EDDC245807")),"Gowtham","gowtham_test@gmail.com"),
                Customer.Create(CustomerId.Of(new Guid("064A20E5-82AE-4385-A4E5-C0EDDC245808")),"Reddy","reddy_test@gmail.com")
            };

        public static IEnumerable<Product> Products =>
           new List<Product>
           {
                Product.Create(ProductId.Of(new Guid("164A20E5-82AE-4385-A4E5-C0EDDC245807")),"Iphone", 125),
                Product.Create(ProductId.Of(new Guid("164A20E5-82AE-4385-A4E5-C0EDDC245808")),"MacBook",250)
           };

        public static IEnumerable<Order> OrderwithItems
        {
            get
            {
                var address1 = Address.Of("Gowtham", "Pala", "gowtham_test@gmail.com", "1216", "Ireland", "Athlone", "N37VF79");
                var address2 = Address.Of("Reddy", "Pala", "reddy_test@gmail.com", "1216", "Ireland", "Athlone", "N37VF79");

                var payment1 = Payment.Of("Gowtham", "123456789", "020225", "123", 1);
                var payment2 = Payment.Of("Reddy", "987654321", "030326", "321", 2);

                var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("064A20E5-82AE-4385-A4E5-C0EDDC245807")),
                    OrderName.Of("ORD_1"),
                    shipping: address1,
                    billing: address1,
                    payment1
                );

                order1.Add(ProductId.Of(new Guid("164A20E5-82AE-4385-A4E5-C0EDDC245807")), 2, 125);
                order1.Add(ProductId.Of(new Guid("164A20E5-82AE-4385-A4E5-C0EDDC245808")), 3, 250);


                var order2 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("064A20E5-82AE-4385-A4E5-C0EDDC245808")),
                    OrderName.Of("ORD_2"),
                    shipping: address2,
                    billing: address2,
                    payment2
                    );

                order2.Add(ProductId.Of(new Guid("164A20E5-82AE-4385-A4E5-C0EDDC245807")), 10, 125);
                order2.Add(ProductId.Of(new Guid("164A20E5-82AE-4385-A4E5-C0EDDC245808")), 5, 250);

                return new List<Order> { order1, order2 };
            }
        }
    } 
}
