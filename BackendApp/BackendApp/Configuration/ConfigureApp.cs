using BackendApp.Middlewares;

namespace BackendApp.Configuration
{
    internal static class ConfigureApp
    {
        internal static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
