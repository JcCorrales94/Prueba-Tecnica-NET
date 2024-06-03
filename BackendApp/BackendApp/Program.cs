using BackendApp.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


ConfigureSwagger.AddSwagger(builder.Services);
ConfigureDBContext.AddDBContext(builder.Services, builder.Configuration);
ConfigureCustomService.AddCustomServices(builder.Services);
ConfigureCustomRepository.AddRepositories(builder.Services);
ConfigureAuthentication.AddAuthentication(builder.Services, builder.Configuration);

var app = builder.Build();

await InitDataBase.Init(app);
ConfigureApp.Configure(app);

app.Run();
