using Microsoft.AspNetCore.Mvc;
using BakeoffDotnetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeoffDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase, IDisposable
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

            return Ok(artist);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Artist>> PutArtist(string id, UpdateArtistRequest request)
        {
            var artist =  await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            artist.Name = request.Name;
            artist.Genre = request.Genre;
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
            return Ok(artist);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(CreateArtistRequest request)
        {
            Artist artist = new Artist
            {
                Name = request.Name,
                Genre = request.Genre
            };
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return Ok(artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtist(string id)
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

        /**
         * Implementing IDisposable to force synchronous disposal of DbContext.
         */
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
