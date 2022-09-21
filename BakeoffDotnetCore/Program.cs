using BakeoffDotnetCore.Models;
using BakeoffDotnetCore.Service;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction()) {
    builder.WebHost.UseUrls("http://0.0.0.0:8080");
}

// Add services to the container.

IServiceCollection services = builder.Services;
services.AddControllers();
services.AddDbContext<ArtistContext>();

services.AddEndpointsApiExplorer();
services.AddScoped<IArtistService, ArtistService>();

var app = builder.Build();
app.MapControllers();

app.Run();