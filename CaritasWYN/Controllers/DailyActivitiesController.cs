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
    public class DailyActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DailyActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DailyActivities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DailyActivities.Include(d => d.Act_Type).Include(d => d.Staff);
            return View(await applicationDbContext.ToListAsync());
        }

       
        // GET: DailyActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyActivity = await _context.DailyActivities
                .Include(d => d.Act_Type)
                .Include(d => d.Staff)
                .FirstOrDefaultAsync(m => m.DailyActivityId == id);
            if (dailyActivity == null)
            {
                return NotFound();
            }

            return View(dailyActivity);
        }

        // GET: DailyActivities/Create
        public IActionResult Create()
        {
            ViewData["Act_typeId"] = new SelectList(_context.Act_Types, "Act_typeId", "ActivityName");
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "FirstName");
            return View();
        }

        // POST: DailyActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailyActivityId,DateStart,DateEnd,Act_typeId,StaffId")] DailyActivity dailyActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Act_typeId"] = new SelectList(_context.Act_Types, "Act_typeId", "ActivityName", dailyActivity.Act_typeId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "FirstName", dailyActivity.StaffId);
            return View(dailyActivity);
        }

        // GET: DailyActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyActivity = await _context.DailyActivities.FindAsync(id);
            if (dailyActivity == null)
            {
                return NotFound();
            }
            ViewData["Act_typeId"] = new SelectList(_context.Act_Types, "Act_typeId", "ActivityName", dailyActivity.Act_typeId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "FirstName", dailyActivity.StaffId);
            return View(dailyActivity);
        }

        // POST: DailyActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DailyActivityId,DateStart,DateEnd,Act_typeId,StaffId")] DailyActivity dailyActivity)
        {
            if (id != dailyActivity.DailyActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyActivityExists(dailyActivity.DailyActivityId))
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
            ViewData["Act_typeId"] = new SelectList(_context.Act_Types, "Act_typeId", "ActivityName", dailyActivity.Act_typeId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "FirstName", dailyActivity.StaffId);
            return View(dailyActivity);
        }

        // GET: DailyActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyActivity = await _context.DailyActivities
                .Include(d => d.Act_Type)
                .Include(d => d.Staff)
                .FirstOrDefaultAsync(m => m.DailyActivityId == id);
            if (dailyActivity == null)
            {
                return NotFound();
            }

            return View(dailyActivity);
        }

        // POST: DailyActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyActivity = await _context.DailyActivities.FindAsync(id);
            _context.DailyActivities.Remove(dailyActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyActivityExists(int id)
        {
            return _context.DailyActivities.Any(e => e.DailyActivityId == id);
        }
    }
}
