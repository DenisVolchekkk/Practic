using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domains.Models;
using Repositories.Context;
using Repositories.Repositories.AppRepositories;

namespace BicyclesWeb.Controllers
{
    public class PartBicyclesController : Controller
    {
        private readonly PartRepository _PContext;
        private readonly PartBicycleRepository _context;
        private readonly BicycleRepository _BContext;


        public PartBicyclesController(PartBicycleRepository context, PartRepository pcontext, BicycleRepository bcontext)
        {
            _context = context;
            _PContext = pcontext;
            _BContext = bcontext;
        }

        // GET: PartBicycles
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAsync());
        }

        // GET: PartBicycles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partBicycle = await _context.GetAsync(id);
            if (partBicycle == null)
            {
                return NotFound();
            }

            return View(partBicycle);
        }

        // GET: PartBicycles/Create
        public IActionResult Create()
        {
            ViewData["BicycleId"] = new SelectList(_BContext.GetAsync().Result, "BicycleId", "ModelName");
            ViewData["PartId"] = new SelectList(_PContext.GetAsync().Result, "PartId", "PartName");
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
                _context.AddAsync(partBicycle);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BicycleId"] = new SelectList(_BContext.GetAsync().Result, "BicycleId", "ModelName", partBicycle.BicycleId);
            ViewData["PartId"] = new SelectList(_PContext.GetAsync().Result, "PartId", "PartName", partBicycle.PartId);
            return View(partBicycle);
        }

        // GET: PartBicycles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partBicycle = await _context.GetAsync(id);
            if (partBicycle == null)
            {
                return NotFound();
            }
            ViewData["BicycleId"] = new SelectList(_BContext.GetAsync().Result, "BicycleId", "ModelName", partBicycle.BicycleId);
            ViewData["PartId"] = new SelectList(_PContext.GetAsync().Result, "PartId", "PartName", partBicycle.PartId);
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
                    _context.UpdateAsync(partBicycle);
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
            ViewData["BicycleId"] = new SelectList(_BContext.GetAsync().Result, "BicycleId", "ModelName", partBicycle.BicycleId);
            ViewData["PartId"] = new SelectList(_PContext.GetAsync().Result, "PartId", "PartName", partBicycle.PartId);
            return View(partBicycle);
        }

        // GET: PartBicycles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partBicycle = await _context.GetAsync(id);
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
            var partBicycle = await _context.GetAsync(id);
            if (partBicycle != null)
            {
                _context.DeleteAsync(partBicycle);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PartBicycleExists(int id)
        {
            return _context.GetAsync().Result.Any(e => e.PartBicycleId == id);
        }
    }
}
