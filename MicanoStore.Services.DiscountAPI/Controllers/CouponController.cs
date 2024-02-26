
using MicanoStore.Services.Discount.Application.CouponDTOs;
using MicanoStore.Services.Discount.Application.CouponServices;
using MicanoStore.Services.Discount.Application.CouponVMs;
using MicanoStore.Services.Discount.Application.ICouponServices;
using Microsoft.AspNetCore.Mvc;

namespace MicanoStore.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/coupons")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet("{couponId}")]
        public async Task<ActionResult<CouponVM>> GetCouponByIdAsync(Guid couponId)
        {
            var couponVM = await _couponService.GetCouponById(couponId);
            if (couponVM == null)
            {
                // Handle not found scenario
                return NotFound();
            }

            return Ok(couponVM);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CouponVM>>> GetAllCouponsAsync()
        {
            var couponsVM = await _couponService.GetAllCoupons();
            return Ok(couponsVM);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCouponAsync([FromBody] CouponDTO couponDTO)
        {
            await _couponService.AddCoupon(couponDTO);
            return Ok();
        }

        [HttpPut("{couponId}")]
        public async Task<ActionResult> UpdateCouponAsync(Guid couponId, [FromBody] CouponDTO updatedCouponDTO)
        {
            await _couponService.UpdateCoupon(couponId, updatedCouponDTO);
            return Ok();
        }

        [HttpDelete("{couponId}")]
        public async Task<ActionResult> DeleteCouponAsync(Guid couponId)
        {
            await _couponService.DeleteCoupon(couponId);
            return Ok();
        }
    }
}
