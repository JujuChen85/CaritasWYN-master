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
    public class JobDutiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobDutiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobDuties
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobDuties.ToListAsync());
        }

        // GET: JobDuties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDuty = await _context.JobDuties
                .FirstOrDefaultAsync(m => m.JobDutyId == id);
            if (jobDuty == null)
            {
                return NotFound();
            }

            return View(jobDuty);
        }

        // GET: JobDuties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobDuties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobDutyId,JobType")] JobDuty jobDuty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobDuty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobDuty);
        }

        // GET: JobDuties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDuty = await _context.JobDuties.FindAsync(id);
            if (jobDuty == null)
            {
                return NotFound();
            }
            return View(jobDuty);
        }

        // POST: JobDuties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobDutyId,JobType")] JobDuty jobDuty)
        {
            if (id != jobDuty.JobDutyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobDuty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobDutyExists(jobDuty.JobDutyId))
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
            return View(jobDuty);
        }

        // GET: JobDuties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDuty = await _context.JobDuties
                .FirstOrDefaultAsync(m => m.JobDutyId == id);
            if (jobDuty == null)
            {
                return NotFound();
            }

            return View(jobDuty);
        }

        // POST: JobDuties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobDuty = await _context.JobDuties.FindAsync(id);
            _context.JobDuties.Remove(jobDuty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobDutyExists(int id)
        {
            return _context.JobDuties.Any(e => e.JobDutyId == id);
        }
    }
}
