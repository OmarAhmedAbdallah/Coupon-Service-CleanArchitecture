using MicanoStore.Services.Discount.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicanoStore.Services.Discount.Domain.IUOW
{
    public interface IUnitOfWork : IDisposable
    {
        ICouponRepository CouponRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
