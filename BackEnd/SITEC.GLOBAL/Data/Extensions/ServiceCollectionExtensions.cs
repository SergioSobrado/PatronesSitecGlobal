using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SITEC.GLOBAL.Data.Context;

namespace SITEC.GLOBAL.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayerDependencies(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<SitecDBContext>(options => options.UseSqlServer(connectionString))
                .AddUnitOfWork<SitecDBContext>();
            return services;
        }
    }
}
