using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationProject.Data;
using WebApplicationProject.Models;
using WebApplicationProject.ViewModels;

namespace WebApplicationProject.Controllers
{
    public class AlbumController : Controller
    {
        private readonly WebApplicationProjectContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AlbumController(WebApplicationProjectContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Album
        public async Task<IActionResult> Index()
        {
            return View(await _context.Albums.ToListAsync());
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                //.Include(x => x.Band)
                //.Include(x => x.Songs)
                .Include(x => x.Reviews).ThenInclude(y => y.Gebruiker)
                .Include(x => x.Genre)
                .Include(x => x.Band.BandArtists).ThenInclude(y => y.Artist)
                .Include(x => x.Band.BandArtists).ThenInclude(y => y.Role)
                .FirstOrDefaultAsync(m => m.AlbumID == id);

            album.Songs = _context.Songs.Where(x => x.AlbumID == id).OrderBy(x => x.TrackNumber).ToList();

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Album/Create
        [Authorize]
        public IActionResult Create(int? id)
        {
            CreateAlbumViewModel viewModel = new CreateAlbumViewModel();

            viewModel.Band = _context.Bands.FirstOrDefault(x => x.BandID == id);
            

            viewModel.Album = new Album();
            viewModel.Album.ReleaseDate = DateTime.Now;
            viewModel.Genres = new SelectList(_context.Genres, "GenreID", "Name");
            viewModel.Bands = new SelectList(_context.Bands, "BandID", "Name", viewModel.Band.BandID);

            return View(viewModel);
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(CreateAlbumViewModel viewModel, int id)
        {
            if (id > 0)
            {
                if (ModelState.IsValid)
                {
                    List<Album> albums = _context.Albums.Where(x => x.BandID == id).ToList();

                    string uniqueFileName = UploadedFile(viewModel);
                    viewModel.Album.CoverArt = uniqueFileName;
                    viewModel.Album.BandID = id;

                    if (!albums.Contains(viewModel.Album))
                    {
                        _context.Add(viewModel.Album);

                        //_context.Add(album);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Details), "Band", new { id });
                        //return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction(nameof(Create), "Album", new { id });
                    }
                }
            }

            viewModel.Genres = new SelectList(_context.Genres, "GenreID", "Name", viewModel.Album.GenreID);
            //viewModel.Bands = new SelectList(_context.Bands, "BandID", "Name", viewModel.Album.BandID);
            return View(viewModel);
        }

        // GET: Album/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CreateAlbumViewModel viewModel = new CreateAlbumViewModel();
            viewModel.Album = await _context.Albums.FindAsync(id);
            

            //var album = await _context.Albums.FindAsync(id);
            if (viewModel.Album == null)
            {
                return NotFound();
            }
            viewModel.Genres = new SelectList(_context.Genres, "GenreID", "Name", viewModel.Album.GenreID);
            viewModel.Bands = new SelectList(_context.Bands, "BandID", "Name", viewModel.Album.BandID);
            //viewModel.Album.CoverArt = viewModel.Album.CoverArt;
            return View(viewModel);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, CreateAlbumViewModel viewModel)
        {
            if (id != viewModel.Album.AlbumID)
            {
                return NotFound();
            }

            //viewModel.Album.CoverArt = _context.Albums.SingleOrDefault(x => x.AlbumID == id).CoverArt;

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = UploadedFile(viewModel);

                    if (uniqueFileName == null)
                    {
                        _context.Entry(viewModel.Album).State = EntityState.Modified;

                        _context.Update(viewModel.Album);

                        _context.Entry(viewModel.Album).Property(x => x.CoverArt).IsModified = false;
                    }
                    else
                    {
                        viewModel.Album.CoverArt = uniqueFileName;
                        _context.Update(viewModel.Album);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(viewModel.Album.AlbumID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), "Album", new { id });
                //return RedirectToAction(nameof(Index));
            }
            viewModel.Genres = new SelectList(_context.Genres, "GenreID", "Name", viewModel.Album.GenreID);
            viewModel.Bands = new SelectList(_context.Bands, "BandID", "Name", viewModel.Album.BandID);
            return View(viewModel);
        }

        // GET: Album/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LatestReleases));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumID == id);
        }

        private string UploadedFile(CreateAlbumViewModel model)
        {
            string uniqueFileName = null;

            if (model.CoverArtImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CoverArtImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CoverArtImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task<IActionResult> Upcomming()
        {
            var albums = await _context.Albums.Include(x => x.Band).Where(x => x.ReleaseDate > DateTime.Now)
                .ToListAsync();
            return View(albums);
        }

        public async Task<IActionResult> LatestReleases()
        {
            var albums = await _context.Albums.Include(x => x.Band).Where(x => x.ReleaseDate < DateTime.Now).OrderByDescending(x => x.ReleaseDate)
                .ToListAsync();
            return View(albums);
        }

    }
}
