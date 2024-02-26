using MicanoStore.Services.Discount.Domain.IUOW;
using Microsoft.Extensions.DependencyInjection;
using MicanoStore.Services.Discount.Infrastructure.UOW;
using MicanoStore.Services.Discount.Infrastructure.Repository;
using MicanoStore.Services.Discount.Domain.IRepository;
using MicanoStore.Services.Discount.Application.CouponServices;
using MicanoStore.Services.Discount.Application.ICouponServices;

namespace MicanoStore.Services.Discount.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICouponRepository, CouponRepository>();
            services.AddScoped<ICouponService, CouponService>();
        }
    }
}
