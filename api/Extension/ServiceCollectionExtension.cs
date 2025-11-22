using api.Interfaces;
using api.Repositories;

namespace api.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IRoleRepository, RoleRepository>();
            return services;
        }
    }
}