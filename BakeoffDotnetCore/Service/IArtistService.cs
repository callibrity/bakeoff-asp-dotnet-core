namespace BakeoffDotnetCore.Service;

using BakeoffDotnetCore.Controllers;
using BakeoffDotnetCore.Models;

public interface IArtistService {
    Task<IList<Artist>> GetAllArtistsAsync();


    Task<Artist?> FindAsync(string id);
    Task<Artist?> UpdateAsync(string id, UpdateArtistRequest request);
    Task<Artist> CreateNewArtistAsync(CreateArtistRequest request);
    Task<Artist?> DeleteAsync(string id);
}