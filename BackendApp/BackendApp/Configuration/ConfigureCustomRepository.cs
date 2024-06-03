using BackendApp_Domain.Interfaces.Repository;
using BackendApp_Infrastructure.Repository;

namespace BackendApp.Configuration
{
    internal static class ConfigureCustomRepository
    {
        internal static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IBookingsRepository, BookingsRepository>();
            services.AddScoped<IFloatRepository, FloatRepository>();
        }
    }
}
