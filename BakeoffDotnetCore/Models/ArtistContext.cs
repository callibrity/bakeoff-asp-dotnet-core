namespace BakeoffDotnetCore.Models;

using Microsoft.EntityFrameworkCore;

public class ArtistContext : DbContext {
    protected IConfiguration Configuration { get; }

    public ArtistContext(IConfiguration configuration) {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "192.168.200.107";
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
        var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "postgres";
        var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
        var dbPass = Environment.GetEnvironmentVariable("DB_PASS") ?? "yep_clock";
        // connect to postgres with connection string from app settings
        var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPass};";
        Console.WriteLine("connection string: " + connectionString);
        options.UseNpgsql(connectionString);
    }

    public DbSet<Artist> Artists { get; set; } = null!;
}