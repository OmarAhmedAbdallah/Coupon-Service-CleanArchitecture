using MicanoStore.Services.Discount.Domain.IRepository;

namespace MicanoStore.Services.Discount.Domain.IUOW
{
    public interface IUnitOfWork : IDisposable
    {
        ICouponRepository CouponRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
