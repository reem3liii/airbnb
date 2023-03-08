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
    public class Place_ServiceController : Controller
    {
        private readonly AirbnbDbContext _context;

        public Place_ServiceController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: Place_Service
        public async Task<IActionResult> Index()
        {
            var airbnbDbContext = _context.Place_Service.Include(p => p.Place);
            return View(await airbnbDbContext.ToListAsync());
        }

        // GET: Place_Service/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Place_Service == null)
            {
                return NotFound();
            }

            var place_Service = await _context.Place_Service
                .Include(p => p.Place)
                .FirstOrDefaultAsync(m => m.PlaceId == id);
            if (place_Service == null)
            {
                return NotFound();
            }

            return View(place_Service);
        }

        // GET: Place_Service/Create
        public IActionResult Create()
        {
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Location");
            return View();
        }

        // POST: Place_Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceId,Service,Price")] Place_Service place_Service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(place_Service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Location", place_Service.PlaceId);
            return View(place_Service);
        }

        // GET: Place_Service/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Place_Service == null)
            {
                return NotFound();
            }

            var place_Service = await _context.Place_Service.FindAsync(id);
            if (place_Service == null)
            {
                return NotFound();
            }
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Location", place_Service.PlaceId);
            return View(place_Service);
        }

        // POST: Place_Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaceId,Service,Price")] Place_Service place_Service)
        {
            if (id != place_Service.PlaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(place_Service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Place_ServiceExists(place_Service.PlaceId))
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
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Location", place_Service.PlaceId);
            return View(place_Service);
        }

        // GET: Place_Service/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Place_Service == null)
            {
                return NotFound();
            }

            var place_Service = await _context.Place_Service
                .Include(p => p.Place)
                .FirstOrDefaultAsync(m => m.PlaceId == id);
            if (place_Service == null)
            {
                return NotFound();
            }

            return View(place_Service);
        }

        // POST: Place_Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Place_Service == null)
            {
                return Problem("Entity set 'AirbnbDbContext.Place_Service'  is null.");
            }
            var place_Service = await _context.Place_Service.FindAsync(id);
            if (place_Service != null)
            {
                _context.Place_Service.Remove(place_Service);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Place_ServiceExists(int id)
        {
          return _context.Place_Service.Any(e => e.PlaceId == id);
        }
    }
}
