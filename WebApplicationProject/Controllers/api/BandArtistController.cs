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
    public class BandArtistController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public BandArtistController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/BandArtist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BandArtist>>> GetBandArtists()
        {
            return await _uow.BandArtistRepository.GetAll().ToListAsync();
        }

        // GET: api/BandArtist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BandArtist>> GetBandArtist(int id)
        {
            var bandArtist = await _uow.BandArtistRepository.GetById(id);

            if (bandArtist == null)
            {
                return NotFound();
            }

            return bandArtist;
        }

        // PUT: api/BandArtist/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBandArtist(int id, BandArtist bandArtist)
        {
            if (id != bandArtist.BandArtistID)
            {
                return BadRequest();
            }

            _uow.BandArtistRepository.Update(bandArtist);

                await _uow.Save();


            return NoContent();
        }

        // POST: api/BandArtist
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BandArtist>> PostBandArtist(BandArtist bandArtist)
        {
            _uow.BandArtistRepository.Create(bandArtist);
            await _uow.Save();

            return CreatedAtAction("GetBandArtist", new { id = bandArtist.BandArtistID }, bandArtist);
        }

        // DELETE: api/BandArtist/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BandArtist>> DeleteBandArtist(int id)
        {
            var bandArtist = await _uow.BandArtistRepository.GetById(id);
            if (bandArtist == null)
            {
                return NotFound();
            }

            _uow.BandArtistRepository.Delete(bandArtist);
            await _uow.Save();

            return bandArtist;
        }
    }
}
