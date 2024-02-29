using MicanoStore.Services.Discount.Application.CouponDTOs;
using MicanoStore.Services.Discount.Application.CouponVMs;

namespace MicanoStore.Services.Discount.Application.ICouponServices
{
    public interface ICouponService
    {
        Task<IEnumerable<CouponVM>> GetAllCoupons();
        Task<CouponVM> GetCouponById(Guid id);
        Task<IEnumerable<CouponVM>> GetPaginatedCoupons(int pageNumber, int pageSize);
        Task AddCoupon(CouponDTO coupon);
        Task UpdateCoupon(Guid couponId, CouponDTO updatedCouponDTO);
        Task DeleteCoupon(Guid id);
    }
}
