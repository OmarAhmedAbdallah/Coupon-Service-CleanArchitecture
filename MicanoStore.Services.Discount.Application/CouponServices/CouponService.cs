using MicanoStore.Services.Discount.Application.CouponDTOs;
using MicanoStore.Services.Discount.Application.CouponFactories;
using MicanoStore.Services.Discount.Application.CouponVMs;
using MicanoStore.Services.Discount.Application.ICouponServices;
using MicanoStore.Services.Discount.Application.Models;
using MicanoStore.Services.Discount.Domain.Entities;
using MicanoStore.Services.Discount.Domain.IRepository;
using MicanoStore.Services.Discount.Domain.IUOW;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicanoStore.Services.Discount.Application.CouponServices 
{
    public class CouponService : ICouponService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CouponService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CouponVM>> GetAllCoupons()
        {
                var coupons = await _unitOfWork.CouponRepository.GetAllAsync();
            return coupons.Select(CouponFactory.ToVM);
        }

        public async Task<CouponVM> GetCouponById(Guid id)
        {
            var coupon = await _unitOfWork.CouponRepository.GetByIdAsync(id);
            return coupon != null ? CouponFactory.ToVM(coupon) : null;
        }

        public async Task<IEnumerable<CouponVM>> GetPaginatedCoupons(int pageNumber, int pageSize)
        {
            var coupons = await _unitOfWork.CouponRepository.GetPaginatedAsync(pageNumber, pageSize);
            return coupons.Select(CouponFactory.ToVM);
        }

        public async Task AddCoupon(CouponDTO couponDTO)
        {
            var coupon = CouponFactory.FromDTO(couponDTO);
            await _unitOfWork.CouponRepository.AddAsync(coupon);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCoupon(Guid couponId, CouponDTO updatedCouponDTO)
        {
            var existingCoupon = await _unitOfWork.CouponRepository.GetByIdAsync(couponId);
            if (existingCoupon == null)
            {
                // Handle not found scenario
                return;
            }

            var updatedCoupon = CouponFactory.FromDTO(updatedCouponDTO);
            existingCoupon.CouponCode = updatedCoupon.CouponCode;
            existingCoupon.DiscountAmount = updatedCoupon.DiscountAmount;
            existingCoupon.MinAmount = updatedCoupon.MinAmount;
            await _unitOfWork.CouponRepository.UpdateAsync(existingCoupon);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCoupon(Guid id)
        {
            var existingCoupon = await _unitOfWork.CouponRepository.GetByIdAsync(id);
            if (existingCoupon == null)
            {
                // Handle not found scenario
                return;
            }

            await _unitOfWork.CouponRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
