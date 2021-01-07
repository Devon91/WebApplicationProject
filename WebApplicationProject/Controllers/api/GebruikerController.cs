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
    public class GebruikerController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public GebruikerController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Gebruiker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gebruiker>>> GetGebruikers()
        {
            return await _uow.GebruikerRepository.GetAll().ToListAsync();
        }

        // GET: api/Gebruiker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gebruiker>> GetGebruiker(int id)
        {
            var gebruiker = await _uow.GebruikerRepository.GetById(id);

            if (gebruiker == null)
            {
                return NotFound();
            }

            return gebruiker;
        }

        // PUT: api/Gebruiker/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGebruiker(int id, Gebruiker gebruiker)
        {
            if (id != gebruiker.GebruikerID)
            {
                return BadRequest();
            }

            _uow.GebruikerRepository.Update(gebruiker);


            await _uow.Save();

            return NoContent();
        }

        // POST: api/Gebruiker
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Gebruiker>> PostGebruiker(Gebruiker gebruiker)
        {
            _uow.GebruikerRepository.Create(gebruiker);
            await _uow.Save();

            return CreatedAtAction("GetGebruiker", new { id = gebruiker.GebruikerID }, gebruiker);
        }

        // DELETE: api/Gebruiker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gebruiker>> DeleteGebruiker(int id)
        {
            var gebruiker = await _uow.GebruikerRepository.GetById(id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            _uow.GebruikerRepository.Delete(gebruiker);
            await _uow.Save();

            return gebruiker;
        }
    }
}
