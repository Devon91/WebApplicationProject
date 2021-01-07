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

namespace WebApplicationProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly WebApplicationProjectContext _context;

        public RoleController(WebApplicationProjectContext context)
        {
            _context = context;
        }

        // GET: Role
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArtistRoles.ToListAsync());
        }

        // GET: Role/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.ArtistRoles
                .FirstOrDefaultAsync(m => m.RoleID == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Role/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("RoleID,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                List<Role> roles = _context.ArtistRoles.ToList();

                if (!roles.Contains(role))
                {
                    _context.Add(role);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(nameof(role.Name),
                    $"This {nameof(role.Name)} already exists.");
                }

            }
            return View(role);
        }

        // GET: Role/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.ArtistRoles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("RoleID,Name")] Role role)
        {
            if (id != role.RoleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    List<Role> roles = _context.ArtistRoles.AsNoTracking().ToList();

                    if (!roles.Contains(role))
                    {
                        _context.Update(role);
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(role.Name),
                        $"This {nameof(role.Name)} already exists.");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.RoleID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(role);
        }

        // GET: Role/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.ArtistRoles
                .FirstOrDefaultAsync(m => m.RoleID == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var role = await _context.ArtistRoles.FindAsync(id);
            _context.ArtistRoles.Remove(role);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            return _context.ArtistRoles.Any(e => e.RoleID == id);
        }
    }
}
