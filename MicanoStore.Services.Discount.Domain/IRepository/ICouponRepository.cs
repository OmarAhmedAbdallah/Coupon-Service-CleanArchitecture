using MicanoStore.Services.Discount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicanoStore.Services.Discount.Domain.IRepository
{
    public interface ICouponRepository
    {
        Task<Coupon> GetByIdAsync(Guid id);
        Task<IEnumerable<Coupon>> GetAllAsync();
        Task<IEnumerable<Coupon>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task AddAsync(Coupon entity);
        Task UpdateAsync(Coupon entity);
        Task DeleteAsync(Guid id);
    }
}
