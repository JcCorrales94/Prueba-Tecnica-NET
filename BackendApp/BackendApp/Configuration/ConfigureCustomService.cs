using BackendApp_Domain.Interfaces.Service;
using BackendApp_Infrastructure.Service;

namespace BackendApp.Configuration
{
    internal static class ConfigureCustomService
    {
        internal static void AddCustomServices(IServiceCollection services)
        {
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IBookingsService, BookingsService>();
            services.AddScoped<IFloatService, FloatService>();
        }
    }
}
