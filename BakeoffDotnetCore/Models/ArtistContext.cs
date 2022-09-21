using Microsoft.EntityFrameworkCore;

namespace BakeoffDotnetCore.Models;

public class ArtistContext : DbContext
{
    // public ArtistContext(DbContextOptions<ArtistContext> options) : base(options)
    // {
    //     
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPass = Environment.GetEnvironmentVariable("DB_PASS");
        var connectionString =
            $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPass};Maximum Pool Size=20;Minimum Pool Size=20;Pooling=true";
        builder.UseNpgsql(connectionString);
    }

    public DbSet<Artist> Artists { get; set; } = null!;
}