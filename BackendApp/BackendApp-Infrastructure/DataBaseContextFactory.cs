using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace BackendApp_Infrastructure
{
    public class DataBaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BackendApp"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            var connectionString = configuration.GetConnectionString("connectionString");

            optionsBuilder.UseSqlServer(connectionString);

            return new DataBaseContext(optionsBuilder.Options);
        }
    }
}
