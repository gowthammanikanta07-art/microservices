using Discount.gRPC.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupons> Coupons { get; set; } = default!;

        public DiscountContext(DbContextOptions<DiscountContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupons>().HasData(
            new Coupons() { Id = 1, ProductName = "techphone 15 pro", Description = "No discount on latest Pro model", Amount = 0 },
            new Coupons() { Id = 2, ProductName = "techphone 15", Description = "Standard model discount", Amount = 50 },
            new Coupons() { Id = 3, ProductName = "galaxy s24 ultra max", Description = "No discount on premium flagship", Amount = 0 },
            new Coupons() { Id = 4, ProductName = "galaxy s24 standard", Description = "Spring sale offer", Amount = 75 },
            new Coupons() { Id = 5, ProductName = "pixel pro 8", Description = "AI camera special", Amount = 100 },
            new Coupons() { Id = 6, ProductName = "pixel 8", Description = "Clearance discount", Amount = 80 },
            new Coupons() { Id = 7, ProductName = "oneplus 12", Description = "Flagship killer deal", Amount = 60 },
            new Coupons() { Id = 8, ProductName = "oneplus 12r", Description = "Mid-range special", Amount = 40 },
            new Coupons() { Id = 9, ProductName = "xiaomi 14 pro", Description = "Global release promo", Amount = 90 },
            new Coupons() { Id = 10, ProductName = "moto edge 50", Description = "Edge series discount", Amount = 45 },
            new Coupons() { Id = 11, ProductName = "sony xperia 1 v", Description = "Creator bundle discount", Amount = 150 },
            new Coupons() { Id = 12, ProductName = "asus rog phone 8", Description = "Gamer mobile special", Amount = 120 },
            new Coupons() { Id = 13, ProductName = "nothing phone (2)", Description = "No discount on limited edition", Amount = 0 },
            new Coupons() { Id = 14, ProductName = "poco x6 pro", Description = "Budget king offer", Amount = 20 },
            new Coupons() { Id = 15, ProductName = "realme gt 5", Description = "Speedster discount", Amount = 30 },
            new Coupons() { Id = 16, ProductName = "macbook pro 16", Description = "No discount on premium Mac", Amount = 0 },
            new Coupons() { Id = 17, ProductName = "macbook air 15", Description = "Student back-to-school discount", Amount = 100 },
            new Coupons() { Id = 18, ProductName = "dell xps 15", Description = "Creator laptop sale", Amount = 150 },
            new Coupons() { Id = 19, ProductName = "thinkpad x1 carbon", Description = "Business fleet promo", Amount = 200 },
            new Coupons() { Id = 20, ProductName = "asus zenbook 14", Description = "Ultrabook deal", Amount = 80 },
            new Coupons() { Id = 21, ProductName = "hp spectre x360", Description = "Convertible laptop offer", Amount = 120 },
            new Coupons() { Id = 22, ProductName = "razer blade 16", Description = "No discount on premium gaming", Amount = 0 },
            new Coupons() { Id = 23, ProductName = "acer swift go 14", Description = "Holiday special discount", Amount = 50 },
            new Coupons() { Id = 24, ProductName = "lenovo legion pro 7", Description = "Esports gaming discount", Amount = 180 },
            new Coupons() { Id = 25, ProductName = "alienware m16 r2", Description = "No discount on new release", Amount = 0 }
            );
        }
    }
}
