using BakeoffDotnetCore.Models;
using BakeoffDotnetCore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    builder.WebHost.UseUrls("http://*:8080");
}

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ArtistContext>(opt =>
{
    if (builder.Environment.IsDevelopment())
    {
        opt.UseInMemoryDatabase("ArtistList");
    }
    else
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPass = Environment.GetEnvironmentVariable("DB_PASS");
        opt.UseNpgsql($"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPass};Maximum Pool Size=20;Minimum Pool Size=20");
    }
});

builder.Services.AddSingleton<IArtistRepository, ArtistRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();