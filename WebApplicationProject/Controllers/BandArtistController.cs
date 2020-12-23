using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationProject.Data;
using WebApplicationProject.Models;
using WebApplicationProject.ViewModels;

namespace WebApplicationProject.Controllers
{
    public class BandArtistController : Controller
    {
        private readonly WebApplicationProjectContext _context;

        public BandArtistController(WebApplicationProjectContext context)
        {
            _context = context;
        }

        // GET: BandArtist
        public async Task<IActionResult> Index()
        {
            return View(await _context.BandArtists
                .Include(x => x.Band)
                .Include(x => x.Artist)
                .Include(x => x.Role)
                .ToListAsync());
        }

        // GET: BandArtist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandArtist = await _context.BandArtists
                .FirstOrDefaultAsync(m => m.BandArtistID == id);
            if (bandArtist == null)
            {
                return NotFound();
            }

            return View(bandArtist);
        }

        // GET: BandArtist/Create
        public IActionResult Create(int id)
        {
            CreateBandArtistViewModel viewModel = new CreateBandArtistViewModel();
            viewModel.Band = _context.Bands.FirstOrDefault(x => x.BandID == id);
            //var fullName = _context.Artists.Select(x => new { V = x.FirstName = x.FirstName + " " + x.LastName})
            //viewModel.FullName = _context.Artists.Select(x => x.FirstName) + _context.Artists.Select(x => x.LastName).ToList();
            viewModel.Artists = new SelectList(_context.Artists, "ArtistID", "FullName");
            viewModel.Bands = new SelectList(_context.Bands, "BandID", "Name");
            viewModel.Roles = new SelectList(_context.ArtistRoles, "RoleID", "Name");
            return View(viewModel);
        }

        // POST: BandArtist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBandArtistViewModel viewModel, int id)
        {
            if (ModelState.IsValid)
            {
                //int existsID = _context.Artists.FirstOrDefault(x => x.FirstName == viewModel.BandArtist.Artist.FirstName && x.LastName == viewModel.BandArtist.Artist.LastName).ArtistID;
                List<Artist> artists = _context.Artists.ToList();
                List<BandArtist> bandArtists = _context.BandArtists.Where(x => x.BandID == id).ToList();
                //if (existsID > 0)
                //{
                //    viewModel.BandArtist.Artist = _context.Artists.FirstOrDefault(x => x.ArtistID == existsID);
                //}
                if (artists.Contains(viewModel.BandArtist.Artist))
                {
                    int existsID = _context.Artists.FirstOrDefault(x => x.FirstName == viewModel.BandArtist.Artist.FirstName && x.LastName == viewModel.BandArtist.Artist.LastName).ArtistID;
                    viewModel.BandArtist.Artist = _context.Artists.FirstOrDefault(x => x.ArtistID == existsID);
                }

                viewModel.BandArtist.BandID = id;

                if (!bandArtists.Contains(viewModel.BandArtist))
                {
                    _context.Add(viewModel.BandArtist);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), "Band", new { id });
                }
                else
                {
                    //viewModel.Band.BandID = id;
                    return RedirectToAction(nameof(Create), "BandArtist", new { id });
                    //return View(viewModel);
                }


                //Artist a = _context.Artists.FirstOrDefault(x => x.FirstName == viewModel.)

                //return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: BandArtist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CreateBandArtistViewModel viewModel = new CreateBandArtistViewModel();
            viewModel.BandArtist = await _context.BandArtists.FindAsync(id);
            

            if (viewModel.BandArtist == null)
            {
                return NotFound();
            }

            viewModel.Bands = new SelectList(_context.Bands, "BandID", "Name");
            viewModel.Roles = new SelectList(_context.ArtistRoles, "RoleID", "Name", viewModel.BandArtist.RoleID);
            viewModel.Artists = new SelectList(_context.Artists, "ArtistID", "FirstName", viewModel.BandArtist.ArtistID);

            return View(viewModel);
        }

        // POST: BandArtist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int artistID, int bandID, CreateBandArtistViewModel viewModel)
        {
            //viewModel.BandArtist = _context.BandArtists
            //    .SingleOrDefault(x => x.ArtistID == id);
            if (id != viewModel.BandArtist.BandArtistID)
            {
                return NotFound();
            }

            viewModel.BandArtist.ArtistID = artistID;
            viewModel.BandArtist.BandID = bandID;

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(viewModel.BandArtist.Artist);
                    _context.Update(viewModel.BandArtist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandArtistExists(viewModel.BandArtist.BandArtistID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), "Band", new { id = bandID });


                //return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: BandArtist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandArtist = await _context.BandArtists
                .FirstOrDefaultAsync(m => m.BandArtistID == id);
            if (bandArtist == null)
            {
                return NotFound();
            }

            return View(bandArtist);
        }

        // POST: BandArtist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bandArtist = await _context.BandArtists.FindAsync(id);
            _context.BandArtists.Remove(bandArtist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandArtistExists(int id)
        {
            return _context.BandArtists.Any(e => e.BandArtistID == id);
        }
    }
}
