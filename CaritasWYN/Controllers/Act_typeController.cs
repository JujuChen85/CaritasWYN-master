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
    public class Act_typeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Act_typeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Act_type
        public async Task<IActionResult> Index()
        {
            return View(await _context.Act_Types.ToListAsync());
        }

        // GET: Act_type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var act_type = await _context.Act_Types
                .FirstOrDefaultAsync(m => m.Act_typeId == id);
            if (act_type == null)
            {
                return NotFound();
            }

            return View(act_type);
        }

        // GET: Act_type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Act_type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Act_typeId,ActivityName")] Act_type act_type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(act_type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(act_type);
        }

        // GET: Act_type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var act_type = await _context.Act_Types.FindAsync(id);
            if (act_type == null)
            {
                return NotFound();
            }
            return View(act_type);
        }

        // POST: Act_type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Act_typeId,ActivityName")] Act_type act_type)
        {
            if (id != act_type.Act_typeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(act_type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Act_typeExists(act_type.Act_typeId))
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
            return View(act_type);
        }

        // GET: Act_type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var act_type = await _context.Act_Types
                .FirstOrDefaultAsync(m => m.Act_typeId == id);
            if (act_type == null)
            {
                return NotFound();
            }

            return View(act_type);
        }

        // POST: Act_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var act_type = await _context.Act_Types.FindAsync(id);
            _context.Act_Types.Remove(act_type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Act_typeExists(int id)
        {
            return _context.Act_Types.Any(e => e.Act_typeId == id);
        }
    }
}
