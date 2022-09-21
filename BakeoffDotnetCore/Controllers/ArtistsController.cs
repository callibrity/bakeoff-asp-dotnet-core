namespace BakeoffDotnetCore.Controllers {
    using BakeoffDotnetCore.Models;
    using BakeoffDotnetCore.Service;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase {
        private IArtistService ArtistService { get; }

        public ArtistsController(IArtistService artistService) {
            ArtistService = artistService;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<IActionResult> GetArtists() {
            return Ok(await ArtistService.GetAllArtistsAsync());
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(string id) {
            var artist = await ArtistService.FindAsync(id);

            if (artist == null) {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(string id, UpdateArtistRequest request) {
            var artist = await ArtistService.UpdateAsync(id, request);
            if (artist == null) {
                return NotFound();
            }

            return Ok(artist);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(CreateArtistRequest request) {
            Artist artist = await ArtistService.CreateNewArtistAsync(request);
            return Ok(artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(string id) {
            var artist = await ArtistService.DeleteAsync(id);

            if (artist == null) {
                return NotFound();
            }

            return Ok();
        }
    }
}