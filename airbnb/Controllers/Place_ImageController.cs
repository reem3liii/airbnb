using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using airbnb.Models;

namespace airbnb.Controllers
{
    public class Place_ImageController : Controller
    {
        private readonly AirbnbDbContext _context;

        public Place_ImageController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: Place_Image
        public async Task<IActionResult> Index()
        {
            var airbnbDbContext = _context.Place_Image.Include(p => p.Place);
            return View(await airbnbDbContext.ToListAsync());
        }

        // GET: Place_Image/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Place_Image == null)
            {
                return NotFound();
            }

            var place_Image = await _context.Place_Image
                .Include(p => p.Place)
                .FirstOrDefaultAsync(m => m.PlaceId == id);
            if (place_Image == null)
            {
                return NotFound();
            }

            return View(place_Image);
        }

        // GET: Place_Image/Create
        public IActionResult Create()
        {
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Location");
            return View();
        }

        // POST: Place_Image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceId,ImageName")] Place_Image place_Image)
        {
            if (ModelState.IsValid)
            {
                _context.Add(place_Image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Location", place_Image.PlaceId);
            return View(place_Image);
        }

        // GET: Place_Image/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Place_Image == null)
            {
                return NotFound();
            }

            var place_Image = await _context.Place_Image.FindAsync(id);
            if (place_Image == null)
            {
                return NotFound();
            }
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Location", place_Image.PlaceId);
            return View(place_Image);
        }

        // POST: Place_Image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaceId,ImageName")] Place_Image place_Image)
        {
            if (id != place_Image.PlaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(place_Image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Place_ImageExists(place_Image.PlaceId))
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
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Location", place_Image.PlaceId);
            return View(place_Image);
        }

        // GET: Place_Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Place_Image == null)
            {
                return NotFound();
            }

            var place_Image = await _context.Place_Image
                .Include(p => p.Place)
                .FirstOrDefaultAsync(m => m.PlaceId == id);
            if (place_Image == null)
            {
                return NotFound();
            }

            return View(place_Image);
        }

        // POST: Place_Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Place_Image == null)
            {
                return Problem("Entity set 'AirbnbDbContext.Place_Image'  is null.");
            }
            var place_Image = await _context.Place_Image.FindAsync(id);
            if (place_Image != null)
            {
                _context.Place_Image.Remove(place_Image);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Place_ImageExists(int id)
        {
          return _context.Place_Image.Any(e => e.PlaceId == id);
        }
    }
}
