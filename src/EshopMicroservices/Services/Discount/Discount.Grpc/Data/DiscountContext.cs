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
                new Coupons() { Id=1,ProductName="Iphone", Description="Expensive Mobile", Amount=120},
                new Coupons() { Id=2,ProductName="MacBook", Description="Expensive Laptop", Amount=100}
            );
        }
    }

    
}
