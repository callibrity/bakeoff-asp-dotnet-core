using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BakeoffDotnetCore.Models;
using Npgsql.Internal.TypeHandlers;

namespace BakeoffDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistContext _context;

        public ArtistsController(ArtistContext context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(string id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Artist>> PutArtist(string id, Artist artist)
        {
            var persisted = await _context.Artists.FindAsync(id);
            if (persisted == null)
            {
                return NotFound();
            }
            persisted.Name = artist.Genre;
            persisted.Genre = artist.Genre;
            await _context.SaveChangesAsync();

            return Ok(persisted);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            artist.Id = System.Guid.NewGuid().ToString();
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return Ok(artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(string id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ArtistExists(string id)
        {
            return (_context.Artists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
