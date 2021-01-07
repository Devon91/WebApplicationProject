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
    public class ReviewController : Controller
    {
        private readonly WebApplicationProjectContext _context;

        public ReviewController(WebApplicationProjectContext context)
        {
            _context = context;
        }

        // GET: Review
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews
                .Include(x => x.Album)
                .ToListAsync());
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Review/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            CreateReviewViewModel viewModel = new CreateReviewViewModel();
            viewModel.Review = new Review();
            viewModel.Album = _context.Albums.FirstOrDefault(x => x.AlbumID == id);
            //viewModel.Review.Album = _context.Albums.FirstOrDefault(x => x.AlbumID == id);
            //viewModel.Review.Album.AlbumID = id;
            //viewModel.Albums = new SelectList(_context.Albums, "AlbumID", "Title");
            return View(viewModel);
        }

        // POST: Review/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(CreateReviewViewModel viewModel, int id)
        {
            viewModel.Review.Album = _context.Albums.FirstOrDefault(x => x.AlbumID == id);
            Gebruiker g = _context.Gebruikers.FirstOrDefault(x => x.Email == User.Identity.Name);
            if (ModelState.IsValid)
            {
                viewModel.Review.Gebruiker = g;
                _context.Add(viewModel.Review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Album", new { id });
                //return RedirectToAction(nameof(Index));
            }
            else
            {
                //var errors = ModelState.Select(x => x.Value.Errors)
                //                       .Where(y => y.Count > 0)
                //                       .ToList();
            }
            //viewModel.Albums = new SelectList(_context.Albums, "AlbumID", "Title", viewModel.Review.Album.AlbumID);
            return View(viewModel);
        }

        // GET: Review/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id, int albumID)
        {
            if (id == null)
            {
                return NotFound();
            }

            CreateReviewViewModel viewModel = new CreateReviewViewModel();

            viewModel.Review = await _context.Reviews.FindAsync(id);
            viewModel.Album = await _context.Albums.FindAsync(albumID);

            if (viewModel.Review == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, int albumID, CreateReviewViewModel viewModel)
        {
            if (id != viewModel.Review.ReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(viewModel.Review.ReviewID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), "Album", new { id = albumID });
                //return RedirectToAction(nameof(Index));
            }
            return View(viewModel.Review);
        }

        // GET: Review/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id, int albumID, string userName)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.Include(x => x.Gebruiker)
                .FirstOrDefaultAsync(m => m.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }
            if (User.Identity.Name == review.Gebruiker.Email)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Details), "Album", new { id = albumID });
        }

        //// POST: Review/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public async Task<IActionResult> DeleteConfirmed(int id, int albumID)
        //{
        //    var review = await _context.Reviews.FindAsync(id);
        //    _context.Reviews.Remove(review);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Details), "Album", new { id = albumID });
        //}

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewID == id);
        }
    }
}
