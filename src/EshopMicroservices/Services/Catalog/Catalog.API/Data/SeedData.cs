namespace Catalog.API.Data
{
    public class SeedData(ILogger<SeedData> logger) : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
            {
                logger.LogInformation("Found Product table, not seeding data");
                return;
            }
              
            session.Store<Product>(GetData());
            logger.LogInformation("Seeding data");
            await session.SaveChangesAsync(cancellation);

        }

        private IEnumerable<Product> GetData() => new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "SmartBulb Yellow",
                Description = "SmartBulb Yellow Color",
                Category = new List<string> {"Electricals","Electronics"},
                ImageFile = "SmartBY.jpg",
                Price = 199,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "SmartBulb Blue",
                Description = "SmartBulb Blue Color",
                Category = new List<string> {"Electricals","Electronics"},
                ImageFile = "SmartBB.jpg",
                Price = 199,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "SmartBulb Green",
                Description = "SmartBulb Green Color",
                Category = new List<string> {"Electricals","Electronics"},
                ImageFile = "SmartBG.jpg",
                Price = 199,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Washing Machine 3",
                Description = "Washing Machine 3 Star",
                Category = new List<string> {"Electricals"},
                ImageFile = "Washing Machine3.jpg",
                Price = 699,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Washing Machine 4",
                Description = "Washing Machine 4 Star",
                Category = new List<string> {"Electricals"},
                ImageFile = "Washing Machine4.jpg",
                Price = 799,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Washing Machine 5",
                Description = "Washing Machine 5 Star",
                Category = new List<string> {"Electricals"},
                ImageFile = "Washing Machine5.jpg",
                Price = 899,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Laptop M14",
                Description = "Lightweight Laptop M14",
                Category = new List<string> {"Electronics"},
                ImageFile = "Laptop M14.jpg",
                Price = 1499,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Laptop M13",
                Description = "Lightweight Laptop M13",
                Category = new List<string> {"Electronics"},
                ImageFile = "Laptop M13.jpg",
                Price = 1399,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Laptop M12",
                Description = "Lightweight Laptop M12",
                Category = new List<string> {"Electronics"},
                ImageFile = "Laptop M12.jpg",
                Price = 1299,
            },

        };   
    }
}
