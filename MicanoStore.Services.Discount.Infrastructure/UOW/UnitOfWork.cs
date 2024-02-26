using MicanoStore.Services.Discount.Domain.IRepository;
using MicanoStore.Services.Discount.Domain.IUOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicanoStore.Services.Discount.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DiscountDbContext _context;

        public ICouponRepository CouponRepository { get; }

        public UnitOfWork(DiscountDbContext context, ICouponRepository couponRepository)
        {
            _context = context;
            CouponRepository = couponRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
