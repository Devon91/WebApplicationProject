using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationProject.Data;
using WebApplicationProject.Data.UnitOfWork;
using WebApplicationProject.Models;

namespace WebApplicationProject.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ArtistController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Artist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _uow.ArtistRepository.GetAll().ToListAsync();
        }

        // GET: api/Artist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _uow.ArtistRepository.GetById(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        // PUT: api/Artist/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.ArtistID)
            {
                return BadRequest();
            }

            _uow.ArtistRepository.Update(artist);


            await _uow.Save();

            return NoContent();
        }

        // POST: api/Artist
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            _uow.ArtistRepository.Create(artist);
            await _uow.Save();

            return CreatedAtAction("GetArtist", new { id = artist.ArtistID }, artist);
        }

        // DELETE: api/Artist/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(int id)
        {
            var artist = await _uow.ArtistRepository.GetById(id);
            if (artist == null)
            {
                return NotFound();
            }

            _uow.ArtistRepository.Delete(artist);
            await _uow.Save();

            return artist;
        }
    }
}
