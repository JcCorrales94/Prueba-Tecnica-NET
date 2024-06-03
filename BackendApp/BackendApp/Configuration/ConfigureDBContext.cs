using BackendApp_Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace BackendApp.Configuration
{
    internal static class ConfigureDBContext
    {
        internal static void AddDBContext(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("connectionString")));
        }
    }
}
