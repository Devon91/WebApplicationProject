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
    public class BandController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public BandController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Band
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Band>>> GetBands()
        {
            return await _uow.BandRepository.GetAll().ToListAsync();
        }

        // GET: api/Band/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Band>> GetBand(int id)
        {
            var band = await _uow.BandRepository.GetById(id);

            if (band == null)
            {
                return NotFound();
            }

            return band;
        }

        // PUT: api/Band/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBand(int id, Band band)
        {
            if (id != band.BandID)
            {
                return BadRequest();
            }

            _uow.BandRepository.Update(band);


                await _uow.Save();
            

            return NoContent();
        }

        // POST: api/Band
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Band>> PostBand(Band band)
        {
            _uow.BandRepository.Create(band);
            await _uow.Save();

            return CreatedAtAction("GetBand", new { id = band.BandID }, band);
        }

        // DELETE: api/Band/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Band>> DeleteBand(int id)
        {
            var band = await _uow.BandRepository.GetById(id);
            if (band == null)
            {
                return NotFound();
            }

            _uow.BandRepository.Delete(band);
            await _uow.Save();

            return band;
        }
    }
}
