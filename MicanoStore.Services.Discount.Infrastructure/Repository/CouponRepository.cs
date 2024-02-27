using MicanoStore.Services.Discount.Domain.Entities;
using MicanoStore.Services.Discount.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicanoStore.Services.Discount.Infrastructure.Repository
{

    public class CouponRepository : ICouponRepository
    {
        private readonly DiscountDbContext _context;

        public CouponRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task<Coupon?> GetByIdAsync(Guid id)
        {
            return await _context.Coupons.FindAsync(id);
        }

        public async Task<IEnumerable<Coupon>> GetAllAsync()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task<IEnumerable<Coupon>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _context.Coupons
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(Coupon entity)
        {
            await _context.Coupons.AddAsync(entity);
        }

        public void Update(Coupon entity)
        {
            _context.Coupons.Update(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Coupons.FindAsync(id);
            if (entity != null)
            {
                _context.Coupons.Remove(entity);
            }
        }
    }
}
