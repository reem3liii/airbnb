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
    public class Customer_PhoneController : Controller
    {
        private readonly AirbnbDbContext _context;

        public Customer_PhoneController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: Customer_Phone
        public async Task<IActionResult> Index()
        {
            var airbnbDbContext = _context.Customer_Phone.Include(c => c.Customer);
            return View(await airbnbDbContext.ToListAsync());
        }

        // GET: Customer_Phone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customer_Phone == null)
            {
                return NotFound();
            }

            var customer_Phone = await _context.Customer_Phone
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer_Phone == null)
            {
                return NotFound();
            }

            return View(customer_Phone);
        }

        // GET: Customer_Phone/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email");
            return View();
        }

        // POST: Customer_Phone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,PhoneNumber")] Customer_Phone customer_Phone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer_Phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", customer_Phone.CustomerId);
            return View(customer_Phone);
        }

        // GET: Customer_Phone/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customer_Phone == null)
            {
                return NotFound();
            }

            var customer_Phone = await _context.Customer_Phone.FindAsync(id);
            if (customer_Phone == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", customer_Phone.CustomerId);
            return View(customer_Phone);
        }

        // POST: Customer_Phone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,PhoneNumber")] Customer_Phone customer_Phone)
        {
            if (id != customer_Phone.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer_Phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Customer_PhoneExists(customer_Phone.CustomerId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", customer_Phone.CustomerId);
            return View(customer_Phone);
        }

        // GET: Customer_Phone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customer_Phone == null)
            {
                return NotFound();
            }

            var customer_Phone = await _context.Customer_Phone
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer_Phone == null)
            {
                return NotFound();
            }

            return View(customer_Phone);
        }

        // POST: Customer_Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customer_Phone == null)
            {
                return Problem("Entity set 'AirbnbDbContext.Customer_Phone'  is null.");
            }
            var customer_Phone = await _context.Customer_Phone.FindAsync(id);
            if (customer_Phone != null)
            {
                _context.Customer_Phone.Remove(customer_Phone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Customer_PhoneExists(int id)
        {
          return _context.Customer_Phone.Any(e => e.CustomerId == id);
        }
    }
}
