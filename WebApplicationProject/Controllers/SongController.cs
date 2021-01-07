using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationProject.Data;
using WebApplicationProject.Models;
using WebApplicationProject.ViewModels;

namespace WebApplicationProject.Controllers
{
    public class SongController : Controller
    {
        private readonly WebApplicationProjectContext _context;

        public SongController(WebApplicationProjectContext context)
        {
            _context = context;
        }

        // GET: Song
        public async Task<IActionResult> Index()
        {
            return View(await _context.Songs.ToListAsync());
        }

        // GET: Song/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Song/Create
        public IActionResult Create(int id)
        {
            CreateSongViewModel viewModel = new CreateSongViewModel();
            viewModel.Song = new Song();
            viewModel.AlbumID = id;
            return View(viewModel);
        }

        // POST: Song/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(CreateSongViewModel viewModel, int id)
        {
            viewModel.Song.Album = _context.Albums.FirstOrDefault(x => x.AlbumID == id);
            Album album = viewModel.Song.Album;

            if (ModelState.IsValid)
            {

                _context.Add(viewModel.Song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Album", new { id });
                //return RedirectToAction(nameof(Index));

            }
            viewModel.Albums = new SelectList(_context.Albums, "AlbumID", "Title", viewModel.Song.AlbumID);
            return View(viewModel);
        }

        // GET: Song/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CreateSongViewModel viewModel = new CreateSongViewModel();
            viewModel.Song = await _context.Songs.FindAsync(id);
            viewModel.AlbumID = viewModel.Song.AlbumID;

            if (viewModel.Song == null)
            {
                return NotFound();
            }

            //viewModel.Albums = new SelectList(_context.Albums, "AlbumID", "Title", viewModel.Song.AlbumID);

            return View(viewModel);
        }

        // POST: Song/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, CreateSongViewModel viewModel, int albumID)
        {
            viewModel.Song.AlbumID = albumID;

            if (id != viewModel.Song.SongID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(viewModel.Song.SongID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), "Album", new { id = viewModel.Song.AlbumID });
                //return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Song/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), "Album", new { id = song.AlbumID});
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongID == id);
        }
    }
}
