using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaritasWYN.Data;
using CaritasWYN.Models;

namespace CaritasWYN.Controllers
{
    public class ReferrersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReferrersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Referrers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Referrers.ToListAsync());
        }

        // GET: Referrers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referrer = await _context.Referrers
                .FirstOrDefaultAsync(m => m.ReferrerId == id);
            if (referrer == null)
            {
                return NotFound();
            }

            return View(referrer);
        }

        // GET: Referrers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Referrers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReferrerId,Name,Type,Phone,Office")] Referrer referrer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referrer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(referrer);
        }

        // GET: Referrers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referrer = await _context.Referrers.FindAsync(id);
            if (referrer == null)
            {
                return NotFound();
            }
            return View(referrer);
        }

        // POST: Referrers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReferrerId,Name,Type,Phone,Office")] Referrer referrer)
        {
            if (id != referrer.ReferrerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referrer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferrerExists(referrer.ReferrerId))
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
            return View(referrer);
        }

        // GET: Referrers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referrer = await _context.Referrers
                .FirstOrDefaultAsync(m => m.ReferrerId == id);
            if (referrer == null)
            {
                return NotFound();
            }

            return View(referrer);
        }

        // POST: Referrers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referrer = await _context.Referrers.FindAsync(id);
            _context.Referrers.Remove(referrer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferrerExists(int id)
        {
            return _context.Referrers.Any(e => e.ReferrerId == id);
        }
    }
}
