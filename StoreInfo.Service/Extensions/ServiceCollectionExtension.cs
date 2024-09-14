using Microsoft.Extensions.DependencyInjection;
using StoreInfo.Repository;
using StoreInfo.Repository.Interface;
using StoreInfo.Service.Interface;

namespace StoreInfo.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void DependencyInjectionComponents(this IServiceCollection services)
        {
            services.AddScoped<IStoreInfoRepository, StoreInfoRepository>();
            services.AddScoped<IStoreInfoService, StoreInfoService>();
        }
    }
}
