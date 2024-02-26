using MicanoStore.Services.Discount.Application.CouponDTOs;
using MicanoStore.Services.Discount.Application.CouponVMs;
using MicanoStore.Services.Discount.Domain.Entities;

namespace MicanoStore.Services.Discount.Application.CouponFactories
{
    public static class CouponFactory
    {
        public static CouponDTO ToDTO(Coupon coupon)
        {
            return new CouponDTO
            {
                CouponCode = coupon.CouponCode,
                DiscountAmount = coupon.DiscountAmount,
                MinAmount = coupon.MinAmount
            };
        }

        public static Coupon FromDTO(CouponDTO dto)
        {
            return new Coupon
            {
                CouponCode = dto.CouponCode,
                DiscountAmount = dto.DiscountAmount,
                MinAmount = dto.MinAmount
            };
        }

        public static CouponVM ToVM(Coupon coupon)
        {
            return new CouponVM
            {
                Id = coupon.Id,
                CouponCode = coupon.CouponCode,
                DiscountAmount = coupon.DiscountAmount,
                MinAmount = coupon.MinAmount
            };
        }

        public static Coupon FromVM(CouponVM vm)
        {
            return new Coupon
            {
                Id = vm.Id,
                CouponCode = vm.CouponCode,
                DiscountAmount = vm.DiscountAmount,
                MinAmount = vm.MinAmount
            };
        }
    }
}
