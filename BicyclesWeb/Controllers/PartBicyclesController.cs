using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domains.Models;
using Repositories.Context;

namespace BicyclesWeb.Controllers
{
    public class PartBicyclesController : Controller
    {
        private readonly BicyclesContext _context;

        public PartBicyclesController(BicyclesContext context)
        {
            _context = context;
        }

        // GET: PartBicycles
        public async Task<IActionResult> Index()
        {
            var bicyclesContext = _context.PartBicycles.Include(p => p.Bicycle).Include(p => p.Part);
            return View(await bicyclesContext.ToListAsync());
        }

        // GET: PartBicycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partBicycle = await _context.PartBicycles
                .Include(p => p.Bicycle)
                .Include(p => p.Part)
                .FirstOrDefaultAsync(m => m.PartBicycleId == id);
            if (partBicycle == null)
            {
                return NotFound();
            }

            return View(partBicycle);
        }

        // GET: PartBicycles/Create
        public IActionResult Create()
        {
            ViewData["BicycleId"] = new SelectList(_context.Bicycles, "BicycleId", "BicycleId");
            ViewData["PartId"] = new SelectList(_context.Parts, "PartId", "PartId");
            return View();
        }

        // POST: PartBicycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartBicycleId,PartId,BicycleId,QuantityRequired")] PartBicycle partBicycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partBicycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BicycleId"] = new SelectList(_context.Bicycles, "BicycleId", "BicycleId", partBicycle.BicycleId);
            ViewData["PartId"] = new SelectList(_context.Parts, "PartId", "PartId", partBicycle.PartId);
            return View(partBicycle);
        }

        // GET: PartBicycles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partBicycle = await _context.PartBicycles.FindAsync(id);
            if (partBicycle == null)
            {
                return NotFound();
            }
            ViewData["BicycleId"] = new SelectList(_context.Bicycles, "BicycleId", "BicycleId", partBicycle.BicycleId);
            ViewData["PartId"] = new SelectList(_context.Parts, "PartId", "PartId", partBicycle.PartId);
            return View(partBicycle);
        }

        // POST: PartBicycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartBicycleId,PartId,BicycleId,QuantityRequired")] PartBicycle partBicycle)
        {
            if (id != partBicycle.PartBicycleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partBicycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartBicycleExists(partBicycle.PartBicycleId))
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
            ViewData["BicycleId"] = new SelectList(_context.Bicycles, "BicycleId", "BicycleId", partBicycle.BicycleId);
            ViewData["PartId"] = new SelectList(_context.Parts, "PartId", "PartId", partBicycle.PartId);
            return View(partBicycle);
        }

        // GET: PartBicycles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partBicycle = await _context.PartBicycles
                .Include(p => p.Bicycle)
                .Include(p => p.Part)
                .FirstOrDefaultAsync(m => m.PartBicycleId == id);
            if (partBicycle == null)
            {
                return NotFound();
            }

            return View(partBicycle);
        }

        // POST: PartBicycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partBicycle = await _context.PartBicycles.FindAsync(id);
            if (partBicycle != null)
            {
                _context.PartBicycles.Remove(partBicycle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartBicycleExists(int id)
        {
            return _context.PartBicycles.Any(e => e.PartBicycleId == id);
        }
    }
}
