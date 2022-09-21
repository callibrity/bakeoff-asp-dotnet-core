using Microsoft.AspNetCore.Mvc;
using BakeoffDotnetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeoffDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        
        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            await using var ctx = new ArtistContext();
            return await ctx.Artists.ToListAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(string id)
        {
            await using var ctx = new ArtistContext();
            var artist = await ctx.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Artist>> PutArtist(string id, UpdateArtistRequest request)
        {
            await using var ctx = new ArtistContext();
            var artist =  await ctx.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            artist.Name = request.Name;
            artist.Genre = request.Genre;
            ctx.Artists.Update(artist);
            await ctx.SaveChangesAsync();
            return Ok(artist);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(CreateArtistRequest request)
        {
            await using var ctx = new ArtistContext();
            Artist artist = new Artist
            {
                Name = request.Name,
                Genre = request.Genre
            };
            ctx.Artists.Add(artist);
            await ctx.SaveChangesAsync();
            return Ok(artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtist(string id)
        {
            await using var ctx = new ArtistContext();
            var artist = await ctx.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            ctx.Artists.Remove(artist);
            await ctx.SaveChangesAsync();

            return Ok();
        }
    }
}
