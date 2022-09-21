namespace BakeoffDotnetCore.Service;

using BakeoffDotnetCore.Controllers;
using BakeoffDotnetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class ArtistService : IArtistService {
    private ArtistContext ArtistContext { get; }

    public ArtistService(ArtistContext artistContext) {
        ArtistContext = artistContext;
    }

    /// <inheritdoc />
    public async Task<IList<Artist>> GetAllArtistsAsync() {
        return await ArtistContext.Artists.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Artist?> FindAsync(string id) {
        return await ArtistContext.Artists.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task<Artist?> UpdateAsync(string id, UpdateArtistRequest request) {
        var artist = await FindAsync(id);
        if (artist != null) {
            artist.Name = request.Name;
            artist.Genre = request.Genre;
            var updatedArtistEntry = ArtistContext.Update(artist);
            await ArtistContext.SaveChangesAsync();
            return updatedArtistEntry.Entity;
        }

        return artist;
    }

    /// <inheritdoc />
    public async Task<Artist> CreateNewArtistAsync(CreateArtistRequest request) {
        Artist artist = new() {
            Name = request.Name,
            Genre = request.Genre
        };

        EntityEntry<Artist> entityEntry = await ArtistContext.AddAsync(artist);
        await ArtistContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    /// <inheritdoc />
    public async Task<Artist?> DeleteAsync(string id) {
        var artist = await FindAsync(id);
        if (artist != null) {
            ArtistContext.Artists.Remove(artist);
            await ArtistContext.SaveChangesAsync();
        }

        return artist;
    }
}