using Microsoft.Extensions.DependencyInjection;
using PfsInfrastructure.Configurations.Mapper;

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
