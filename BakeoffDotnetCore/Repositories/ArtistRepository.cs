using BakeoffDotnetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeoffDotnetCore.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly ArtistContext _context;

    public ArtistRepository(ArtistContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Artist>> GetArtists()
    {
        return await _context.Artists.ToListAsync();
    }

    public async Task<Artist> GetArtist(string id)
    {
        return await _context.Artists.FindAsync(id);
    }

    public async Task<Artist> UpdateArtist(string id, string name, string genre)
    {
        var artist = await _context.Artists.FindAsync(id);
        if (artist == null)
        {
            return null!;
        }
        artist.Name = name;
        artist.Genre = genre;
        _context.Artists.Update(artist);
        await _context.SaveChangesAsync();
        return artist;
    }

    public async Task<Artist> CreateArtist(Artist artist)
    {
        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();
        return artist;
    }

    public async Task DeleteArtist(string id)
    {
        var artist = await _context.Artists.FindAsync(id);
        if (artist == null)
        {
            return;
        }

        _context.Artists.Remove(artist);
        await _context.SaveChangesAsync();    
    }
}