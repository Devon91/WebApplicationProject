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
            return View(await _context.BandArtists.ToListAsync());
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
        public IActionResult Create()
        {
            CreateBandArtistViewModel viewModel = new CreateBandArtistViewModel();
            viewModel.Artists = new SelectList(_context.Artists, "ArtistID", "FirstName");
            viewModel.Bands = new SelectList(_context.Bands, "BandID", "Name");
            viewModel.Roles = new SelectList(_context.ArtistRoles, "RoleID", "Name");
            return View(viewModel);
        }

        // POST: BandArtist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBandArtistViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.BandArtist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var bandArtist = await _context.BandArtists.FindAsync(id);
            if (bandArtist == null)
            {
                return NotFound();
            }
            return View(bandArtist);
        }

        // POST: BandArtist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BandArtistID,JoinDate,LeaveDate")] BandArtist bandArtist)
        {
            if (id != bandArtist.BandArtistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bandArtist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandArtistExists(bandArtist.BandArtistID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bandArtist);
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
