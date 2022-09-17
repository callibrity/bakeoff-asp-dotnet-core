using Microsoft.EntityFrameworkCore;

namespace BakeoffDotnetCore.Models;

public class ArtistContext : DbContext
{
    public ArtistContext(DbContextOptions<ArtistContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Artist> Artists { get; set; } = null!;
}