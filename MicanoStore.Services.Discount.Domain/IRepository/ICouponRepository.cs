﻿using MicanoStore.Services.Discount.Domain.Entities;

namespace MicanoStore.Services.Discount.Domain.IRepository
{
    public interface ICouponRepository
    {
        Task<Coupon?> GetByIdAsync(Guid id);
        Task<IEnumerable<Coupon>> GetAllAsync();
        Task<IEnumerable<Coupon>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task AddAsync(Coupon entity);
        void Update(Coupon entity);
        Task DeleteAsync(Guid id);
    }
}
