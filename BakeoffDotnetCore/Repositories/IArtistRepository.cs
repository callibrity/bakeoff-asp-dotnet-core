using BakeoffDotnetCore.Models;

namespace BakeoffDotnetCore.Repositories;

public interface IArtistRepository
{
    Task<IEnumerable<Artist>> GetArtists();
    Task<Artist> GetArtist(string id);
    Task<Artist> UpdateArtist(string id, string name, string genre);
    Task<Artist> CreateArtist(Artist artist);
    Task DeleteArtist(string id);
}