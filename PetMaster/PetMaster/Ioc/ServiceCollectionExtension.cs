using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetMaster.Config;
using PetMasterGroupingProvider.Repository;
using PetMasterGroupingProvider.Service;

namespace PetMaster.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterConfigs(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ApiConfigs>(config.GetSection("ApiConfigs"));
        }

        public static void RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionHandler));
            });
            services.AddScoped<IPetMasterRepository, PetMasterRepository>();
            services.AddScoped<IPetMasterService, PetMasterService>();
        }
    }
}
