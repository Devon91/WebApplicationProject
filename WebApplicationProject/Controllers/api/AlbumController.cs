using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    public class AlbumController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public AlbumController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _uow.AlbumRepository.GetAll()
                .Include(x => x.Genre)
                .Include(x => x.Band)
                .Include(x => x.Songs)
                .Include(x => x.Reviews)
                .ToListAsync();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _uow.AlbumRepository.GetById(id);

            album.Genre = await _uow.GenreRepository.GetById(album.GenreID);
            album.Band = await _uow.BandRepository.GetById(album.BandID);
            album.Songs = await _uow.SongRepository.GetAll().Where(x => x.AlbumID == album.AlbumID).ToListAsync();
            album.Reviews = await _uow.ReviewRepository.GetAll().Where(x => x.ReviewID == album.AlbumID).ToListAsync();
            album.Band.BandArtists = await _uow.BandArtistRepository.GetAll().Where(x => x.BandID == album.BandID).ToListAsync();

            foreach (var item in album.Band.BandArtists)
            {
                item.Artist = await _uow.ArtistRepository.GetById(item.ArtistID);
            }

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Album/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (id != album.AlbumID)
            {
                return BadRequest();
            }

            _uow.AlbumRepository.Update(album);

            await _uow.Save();


            return NoContent();
        }

        // POST: api/Album
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            album.Band = await _uow.BandRepository.GetById(album.BandID);
            album.Band.BandArtists = await _uow.BandArtistRepository.GetAll().Where(x => x.BandID == album.BandID).ToListAsync();
            album.Genre = await _uow.GenreRepository.GetById(album.GenreID);

            _uow.AlbumRepository.Create(album);
            await _uow.Save();

            return CreatedAtAction("GetAlbum", new { id = album.AlbumID }, album);
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> DeleteAlbum(int id)
        {
            var album = await _uow.AlbumRepository.GetById(id);
            if (album == null)
            {
                return NotFound();
            }

            _uow.AlbumRepository.Delete(album);
            await _uow.Save();

            return album;
        }
    }
}
