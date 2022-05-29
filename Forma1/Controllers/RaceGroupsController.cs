using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forma1.Data;
using Forma1.Models;

namespace Forma1.Controllers
{
    public class RaceGroupsController : Controller
    {
        private readonly Forma1Context _context;

        public RaceGroupsController(Forma1Context context)
        {
            _context = context;
        }

        // GET: RaceGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.RaceGroup.ToListAsync());
        }

        // GET: RaceGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceGroup = await _context.RaceGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceGroup == null)
            {
                return NotFound();
            }

            return View(raceGroup);
        }

        // GET: RaceGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RaceGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,YoF,WonRaces,Payed")] RaceGroup raceGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raceGroup);
        }

        // GET: RaceGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceGroup = await _context.RaceGroup.FindAsync(id);
            if (raceGroup == null)
            {
                return NotFound();
            }
            return View(raceGroup);
        }

        // POST: RaceGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,YoF,WonRaces,Payed")] RaceGroup raceGroup)
        {
            if (id != raceGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceGroupExists(raceGroup.Id))
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
            return View(raceGroup);
        }

        // GET: RaceGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceGroup = await _context.RaceGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceGroup == null)
            {
                return NotFound();
            }

            return View(raceGroup);
        }

        // POST: RaceGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceGroup = await _context.RaceGroup.FindAsync(id);
            _context.RaceGroup.Remove(raceGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceGroupExists(int id)
        {
            return _context.RaceGroup.Any(e => e.Id == id);
        }
    }
}
