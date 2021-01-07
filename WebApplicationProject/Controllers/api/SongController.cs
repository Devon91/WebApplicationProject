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
    public class SongController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public SongController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _uow.SongRepository.GetAll().ToListAsync();
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _uow.SongRepository.GetById(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/Song/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.SongID)
            {
                return BadRequest();
            }

            _uow.SongRepository.Update(song);

            await _uow.Save();


            return NoContent();
        }

        // POST: api/Song
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            _uow.SongRepository.Create(song);
            await _uow.Save();

            return CreatedAtAction("GetSong", new { id = song.SongID }, song);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Song>> DeleteSong(int id)
        {
            var song = await _uow.SongRepository.GetById(id);
            if (song == null)
            {
                return NotFound();
            }

            _uow.SongRepository.Delete(song);
            await _uow.Save();

            return song;
        }
    }
}
