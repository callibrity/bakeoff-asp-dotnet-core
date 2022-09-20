using Microsoft.AspNetCore.Mvc;
using BakeoffDotnetCore.Models;
using BakeoffDotnetCore.Repositories;

namespace BakeoffDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistsController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return Ok(await _artistRepository.GetArtists());
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(string id)
        {
            var artist = await _artistRepository.GetArtist(id);
            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Artist>> PutArtist(string id, UpdateArtistRequest request)
        {
            return Ok(await _artistRepository.UpdateArtist(id, request.Name, request.Genre));
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(CreateArtistRequest request)
        {
            return Ok(await _artistRepository.CreateArtist(new Artist()
            {
                Name = request.Name,
                Genre = request.Genre
            }));
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(string id)
        {
            await _artistRepository.DeleteArtist(id);
            return Ok();
        }
    }
}
