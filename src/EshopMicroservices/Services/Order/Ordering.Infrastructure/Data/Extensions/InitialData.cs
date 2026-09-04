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
                Customer.Create(CustomerId.Of(new Guid("c4d7e8b6-1f9a-4c12-9b8a-3f4e5d6c7b8a")),"John","john.doe@example.com"),
                //Customer.Create(CustomerId.Of(new Guid("064A20E5-82AE-4385-A4E5-C0EDDC245808")),"Reddy","reddy_test@gmail.com")
            };

        public static IEnumerable<Product> Products =>
           new List<Product>
           {
               // Product.Create(ProductId.Of(new Guid("27031658-61eb-47c7-be1a-4ea199957867")),"MacBook", 500),
               // Product.Create(ProductId.Of(new Guid("73B704AC-813E-4CCE-B834-F9370DF41534")),"Iphone",620)
                Product.Create(ProductId.Of(new Guid("01a029e0-34f8-42c0-811c-79d40fc7b2c9")), "techphone 15 pro", 1099),
                Product.Create(ProductId.Of(new Guid("01a029e2-8654-48de-b78e-ed8cfd3e28ff")), "techphone 15", 799),
                Product.Create(ProductId.Of(new Guid("01a029e2-b306-4b03-9586-12604c999f15")), "galaxy s24 ultra max", 1199),
                Product.Create(ProductId.Of(new Guid("01a029e3-8071-46df-aa03-aa8bf36be73c")), "galaxy s24 standard", 899),
                Product.Create(ProductId.Of(new Guid("01a029e3-a3ea-4ded-ba51-806bab9187db")), "pixel pro 8", 999),
                Product.Create(ProductId.Of(new Guid("01a029e3-ccde-4b4d-8341-ad204298d83b")), "pixel 8", 699),
                Product.Create(ProductId.Of(new Guid("01a029e4-54d8-4b5e-87f8-d71eca4216d7")), "oneplus 12", 899),
                Product.Create(ProductId.Of(new Guid("01a029e4-76dc-43df-8a1d-6c100a019622")), "oneplus 12r", 599),
                Product.Create(ProductId.Of(new Guid("01a029e4-a429-48e6-8da0-f27798bb0ef8")), "xiaomi 14 pro", 949),
                Product.Create(ProductId.Of(new Guid("01a029e4-c4cb-49d1-9641-32926e3e21ad")), "moto edge 50", 649),
                Product.Create(ProductId.Of(new Guid("01a029e5-0af5-483b-b581-1fc27143c28a")), "sony xperia 1 v", 1199),
                Product.Create(ProductId.Of(new Guid("01a029e5-3259-4764-8f64-a92c294e8898")), "asus rog phone 8", 1099),
                Product.Create(ProductId.Of(new Guid("01a029e5-5aa6-4297-b690-05f44bb0b997")), "nothing phone (2)", 699),
                Product.Create(ProductId.Of(new Guid("01a029e5-93cb-41ea-a41e-4ed8ed88a7d1")), "poco x6 pro", 349),
                Product.Create(ProductId.Of(new Guid("01a029e5-c743-4203-92c1-aed3c11a9403")), "realme gt 5", 499),
                Product.Create(ProductId.Of(new Guid("01a029e5-ef62-43cc-9e13-25831584fed6")), "macbook pro 16", 3499),
                Product.Create(ProductId.Of(new Guid("01a029e6-12a9-480d-91bf-fdab0eecd004")), "macbook air 15", 1299),
                Product.Create(ProductId.Of(new Guid("01a029e6-4b9e-458b-877e-19a38bf9e139")), "dell xps 15", 1899),
                Product.Create(ProductId.Of(new Guid("01a029e6-6c68-43c5-a10e-ba8a91e136c0")), "thinkpad x1 carbon", 1699),
                Product.Create(ProductId.Of(new Guid("01a029e6-9755-4433-9292-d29a9572922d")), "asus zenbook 14", 1099),
                Product.Create(ProductId.Of(new Guid("01a029e6-c089-45eb-9b14-849199016d87")), "hp spectre x360", 1499),
                Product.Create(ProductId.Of(new Guid("01a029e6-e945-4ceb-b8c7-cc2c6573bbc6")), "razer blade 16", 2899),
                Product.Create(ProductId.Of(new Guid("01a029e7-1233-4f7a-8c3e-4e460ab217d0")), "acer swift go 14", 799),
                Product.Create(ProductId.Of(new Guid("01a029e7-3c59-412c-83a6-04865b3fddef")), "lenovo legion pro 7", 2199),
                Product.Create(ProductId.Of(new Guid("01a029e7-629e-4269-a8b7-7c910f5ed15f")), "alienware m16 r2", 2099)
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
