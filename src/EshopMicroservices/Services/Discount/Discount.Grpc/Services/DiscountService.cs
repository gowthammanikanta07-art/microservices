using Discount.gRPC.Data;
using Discount.gRPC.Models;
using Discount.Grpc.Protos;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Services
{
    public class DiscountService(DiscountContext dbcontext, ILogger<DiscountService> logger)
         : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbcontext
                .Coupons
                .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            
            if(coupon is null)
                coupon = new Coupons { Amount = 0 , Description ="No desc", ProductName = "No discount"};

            logger.LogInformation("Discount retrieved for Product : {productName}", request.ProductName);
            var couponModel = coupon.Adapt<CouponModel>();

            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupons = request.Coupon.Adapt<Coupons>();
            if (coupons is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid object"));
            
            await dbcontext.Coupons.AddAsync(coupons);
            await dbcontext.SaveChangesAsync();

            logger.LogInformation("Save Succesful for Product : {productName}", coupons.ProductName);

            return coupons.Adapt<CouponModel>();

        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupons>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Product NotFound"));

            dbcontext.Coupons.Update(coupon);
            await dbcontext.SaveChangesAsync();

            logger.LogInformation("Updated values for product : {productname}", request.Coupon.ProductName);

            return request.Coupon.Adapt<CouponModel>();

        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbcontext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupon is null)
                coupon = new Coupons() { ProductName = "No Item", Amount = 0, Description = "No Item Description" };

            dbcontext.Coupons.Remove(coupon);
            await dbcontext.SaveChangesAsync();

            logger.LogInformation("Coupon deleted for product : {productname}", request.ProductName);

            return new DeleteDiscountResponse { Success = true};
        }
    }
}
