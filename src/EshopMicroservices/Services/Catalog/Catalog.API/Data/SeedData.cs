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
        Name = "TechPhone 15 Pro",
        Description = "TechPhone 15 Pro with 256GB storage and triple camera setup.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "TechPhone15Pro.jpg",
        Price = 1099,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "TechPhone 15",
        Description = "TechPhone 15 with 128GB storage in Midnight Blue.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "TechPhone15.jpg",
        Price = 799,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Galaxy S24 Ultra Max",
        Description = "Galaxy S24 Ultra Max with titanium frame and stylus.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "GalaxyS24Ultra.jpg",
        Price = 1199,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Galaxy S24 Standard",
        Description = "Galaxy S24 Standard edition, 256GB, Phantom Black.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "GalaxyS24.jpg",
        Price = 899,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Pixel Pro 8",
        Description = "Pixel Pro 8 with advanced AI camera features.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "PixelPro8.jpg",
        Price = 999,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Pixel 8",
        Description = "Pixel 8 standard edition, 128GB, Hazel color.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "Pixel8.jpg",
        Price = 699,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "OnePlus 12",
        Description = "OnePlus 12 with 100W fast charging and 512GB storage.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "OnePlus12.jpg",
        Price = 899,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "OnePlus 12R",
        Description = "OnePlus 12R flagship killer, 256GB, Iron Gray.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "OnePlus12R.jpg",
        Price = 599,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Xiaomi 14 Pro",
        Description = "Xiaomi 14 Pro with Leica optics and 120Hz display.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "Xiaomi14Pro.jpg",
        Price = 949,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Moto Edge 50",
        Description = "Moto Edge 50 with curved OLED display.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "MotoEdge50.jpg",
        Price = 649,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Sony Xperia 1 V",
        Description = "Sony Xperia 1 V built for creators, 4K OLED.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "Xperia1V.jpg",
        Price = 1199,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Asus ROG Phone 8",
        Description = "Ultimate gaming smartphone with cooling fan accessory.",
        Category = new List<string> { "Electronics", "Mobiles", "Gaming" },
        ImageFile = "ROGPhone8.jpg",
        Price = 1099,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Nothing Phone (2)",
        Description = "Nothing Phone (2) with Glyph Interface.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "NothingPhone2.jpg",
        Price = 699,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Poco X6 Pro",
        Description = "Poco X6 Pro budget performance king.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "PocoX6Pro.jpg",
        Price = 349,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Realme GT 5",
        Description = "Realme GT 5 with blazing fast charging.",
        Category = new List<string> { "Electronics", "Mobiles", "Smartphones" },
        ImageFile = "RealmeGT5.jpg",
        Price = 499,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "MacBook Pro 16",
        Description = "MacBook Pro 16-inch with M3 Max chip, 32GB RAM, 1TB SSD.",
        Category = new List<string> { "Electronics", "Laptops", "Computers" },
        ImageFile = "MacBookPro16.jpg",
        Price = 3499,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "MacBook Air 15",
        Description = "MacBook Air 15-inch with M3 chip, Midnight color.",
        Category = new List<string> { "Electronics", "Laptops", "Computers" },
        ImageFile = "MacBookAir15.jpg",
        Price = 1299,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Dell XPS 15",
        Description = "Dell XPS 15 with OLED touch display and RTX 4060.",
        Category = new List<string> { "Electronics", "Laptops", "Computers" },
        ImageFile = "DellXPS15.jpg",
        Price = 1899,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "ThinkPad X1 Carbon",
        Description = "Lenovo ThinkPad X1 Carbon Gen 11, ultra-lightweight business laptop.",
        Category = new List<string> { "Electronics", "Laptops", "Business" },
        ImageFile = "ThinkPadX1.jpg",
        Price = 1699,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Asus ZenBook 14",
        Description = "Asus ZenBook 14 OLED, Intel Core Ultra 7.",
        Category = new List<string> { "Electronics", "Laptops", "Computers" },
        ImageFile = "ZenBook14.jpg",
        Price = 1099,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "HP Spectre x360",
        Description = "HP Spectre x360 2-in-1 laptop with included stylus pen.",
        Category = new List<string> { "Electronics", "Laptops", "2-in-1" },
        ImageFile = "HPSpectre.jpg",
        Price = 1499,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Razer Blade 16",
        Description = "Razer Blade 16 gaming laptop with RTX 4080.",
        Category = new List<string> { "Electronics", "Laptops", "Gaming" },
        ImageFile = "RazerBlade16.jpg",
        Price = 2899,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Acer Swift Go 14",
        Description = "Acer Swift Go 14 thin and light laptop for students.",
        Category = new List<string> { "Electronics", "Laptops", "Computers" },
        ImageFile = "AcerSwiftGo.jpg",
        Price = 799,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Lenovo Legion Pro 7",
        Description = "Lenovo Legion Pro 7 high-performance gaming rig.",
        Category = new List<string> { "Electronics", "Laptops", "Gaming" },
        ImageFile = "LegionPro7.jpg",
        Price = 2199,
    },
    new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Alienware m16 R2",
        Description = "Alienware m16 R2 redesigned chassis, Intel Core Ultra 9.",
        Category = new List<string> { "Electronics", "Laptops", "Gaming" },
        ImageFile = "AlienwareM16.jpg",
        Price = 2099,
    }
    };   
    }
}
