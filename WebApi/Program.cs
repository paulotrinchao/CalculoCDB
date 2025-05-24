var builder = WebApplication.CreateBuilder(args);

var startup = new WebApi.Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

builder.Logging.AddConsole();
var app = builder.Build();
startup.Configure(app);

app.Run();
