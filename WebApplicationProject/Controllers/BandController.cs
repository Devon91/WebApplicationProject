﻿using System;
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
    public class BandController : Controller
    {
        private readonly WebApplicationProjectContext _context;

        public BandController(WebApplicationProjectContext context)
        {
            _context = context;
        }

        // GET: Band
        public async Task<IActionResult> Index(DetailBandViewModel viewModel)
        {
            viewModel.Bands = await _context.Bands.OrderBy(x => x.Name).ToListAsync();

            foreach (var item in viewModel.Bands)
            {
                item.Name = item.Name.ToUpper();
            }

            viewModel.BandArtists = await _context.BandArtists.Include(x => x.Artist).ToListAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> Search(DetailBandViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.BandSearch))
            {
                viewModel.Bands = await _context.Bands
                    .Where(b => b.Name.Contains(viewModel.BandSearch)).ToListAsync();
            }
            else
            {
                viewModel.Bands = await _context.Bands.ToListAsync();
            }

            return View("Index", viewModel);
        }

        // GET: Band/Details/5
        public async Task<IActionResult> Details(int? id, DetailBandViewModel viewModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            viewModel.Band = await _context.Bands
                .Include(x => x.Albums)
                .FirstOrDefaultAsync(m => m.BandID == id);

            viewModel.BandArtists = _context.BandArtists.Where(x => x.BandID == viewModel.Band.BandID)
                .Include(x => x.Artist)
                .Include(x => x.Role);

            if (viewModel.Band == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Band/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Band/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Band band)
        {
            if (ModelState.IsValid)
            {
                List<Band> bands = _context.Bands.ToList();

                if (!bands.Contains(band))
                {
                    _context.Add(band);
                    await _context.SaveChangesAsync();

                    Band b = _context.Bands.FirstOrDefault(x => x.Name == band.Name);

                    return RedirectToAction(nameof(Details), "Band", new { id = b.BandID });
                }
                else
                {
                    ModelState.AddModelError(nameof(band.Name),
                    $"This {nameof(band.Name)} already exists.");
                }
            }
            return View(band);
        }

        // GET: Band/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var band = await _context.Bands.FindAsync(id);
            if (band == null)
            {
                return NotFound();
            }
            return View(band);
        }

        // POST: Band/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("BandID,Name,Background")] Band band)
        {
            if (id != band.BandID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    List<Band> bands = _context.Bands.AsNoTracking().ToList();

                    if (!bands.Contains(band))
                    {
                        _context.Update(band);
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Details), "Band", new { id });
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(band.Name),
                        $"This {nameof(band.Name)} already exists.");

                        return View(band);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandExists(band.BandID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(band);
        }

        // GET: Band/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var band = await _context.Bands
                .FirstOrDefaultAsync(m => m.BandID == id);
            if (band == null)
            {
                return NotFound();
            }

            return View(band);
        }

        // POST: Band/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var band = await _context.Bands.FindAsync(id);
            _context.Bands.Remove(band);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandExists(int id)
        {
            return _context.Bands.Any(e => e.BandID == id);
        }
    }
}
