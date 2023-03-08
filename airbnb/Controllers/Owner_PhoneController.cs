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
    public class Owner_PhoneController : Controller
    {
        private readonly AirbnbDbContext _context;

        public Owner_PhoneController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: Owner_Phone
        public async Task<IActionResult> Index()
        {
            var airbnbDbContext = _context.Owner_Phone.Include(o => o.Owner);
            return View(await airbnbDbContext.ToListAsync());
        }

        // GET: Owner_Phone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Owner_Phone == null)
            {
                return NotFound();
            }

            var owner_Phone = await _context.Owner_Phone
                .Include(o => o.Owner)
                .FirstOrDefaultAsync(m => m.OwnerId == id);
            if (owner_Phone == null)
            {
                return NotFound();
            }

            return View(owner_Phone);
        }

        // GET: Owner_Phone/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "FirstName");
            return View();
        }

        // POST: Owner_Phone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OwnerId,PhoneNumber")] Owner_Phone owner_Phone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(owner_Phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "FirstName", owner_Phone.OwnerId);
            return View(owner_Phone);
        }

        // GET: Owner_Phone/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Owner_Phone == null)
            {
                return NotFound();
            }

            var owner_Phone = await _context.Owner_Phone.FindAsync(id);
            if (owner_Phone == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "FirstName", owner_Phone.OwnerId);
            return View(owner_Phone);
        }

        // POST: Owner_Phone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OwnerId,PhoneNumber")] Owner_Phone owner_Phone)
        {
            if (id != owner_Phone.OwnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(owner_Phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Owner_PhoneExists(owner_Phone.OwnerId))
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
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "FirstName", owner_Phone.OwnerId);
            return View(owner_Phone);
        }

        // GET: Owner_Phone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Owner_Phone == null)
            {
                return NotFound();
            }

            var owner_Phone = await _context.Owner_Phone
                .Include(o => o.Owner)
                .FirstOrDefaultAsync(m => m.OwnerId == id);
            if (owner_Phone == null)
            {
                return NotFound();
            }

            return View(owner_Phone);
        }

        // POST: Owner_Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Owner_Phone == null)
            {
                return Problem("Entity set 'AirbnbDbContext.Owner_Phone'  is null.");
            }
            var owner_Phone = await _context.Owner_Phone.FindAsync(id);
            if (owner_Phone != null)
            {
                _context.Owner_Phone.Remove(owner_Phone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Owner_PhoneExists(int id)
        {
          return _context.Owner_Phone.Any(e => e.OwnerId == id);
        }
    }
}
