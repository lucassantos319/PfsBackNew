using Microsoft.Extensions.DependencyInjection;

namespace PfsInfrastructure.Configurations
{
    public static class DIConfiguration
    {
        public static void ConfigureMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperConfiguration));
        }
    }
}
