using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplicationProject.Data;
using WebApplicationProject.Models;

namespace WebApplicationProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebApplicationProjectContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(WebApplicationProjectContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var albums = await _context.Albums.Include(x => x.Band).Where(x => x.ReleaseDate > DateTime.Now)
                .ToListAsync();
            return View(albums);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
