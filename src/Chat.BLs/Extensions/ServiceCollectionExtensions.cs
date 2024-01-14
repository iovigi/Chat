using Chat.BLs.Configurations;
using Chat.BLs.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.BLs.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddModelHandler(this IServiceCollection services, IConfigurationManager configurationManager)
        {
            services.Configure<ModelSettings>(configurationManager.GetSection(nameof(ModelSettings)));
            services.AddSingleton<IModelStorage, ModelStorage>();
            services.AddSingleton<IChatManagement, ChatManagement>();
            services.AddMemoryCache();

            return services;
        }
    }
}
