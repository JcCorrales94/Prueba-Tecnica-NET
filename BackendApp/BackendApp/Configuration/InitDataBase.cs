using BackendApp_Domain.DTO;
using BackendApp_Domain.Interfaces.Service;
using BackendApp_Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Configuration
{
    internal static class InitDataBase
    {
        internal static async Task Init(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var dbContext = service.GetRequiredService<DataBaseContext>();

                dbContext.Database.Migrate();

                var encryptionService = service.GetRequiredService<IEncryptionService>();

                var existingUsers = await dbContext.Users.ToListAsync();

                if (!existingUsers.Any())
                {
                    await dbContext.Users.AddAsync(new UserDTO
                    {
                        Name = "admin",
                        Email = "admin@GTMotive.com",
                        Password = encryptionService.EncryptString("123456Aa.")
                    });
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
