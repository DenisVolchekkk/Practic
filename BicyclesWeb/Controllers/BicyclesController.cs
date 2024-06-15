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
    public class BicyclesController : Controller
    {
        private readonly BicycleRepository _context;

        public BicyclesController(BicycleRepository context)
        {
            _context = context;
        }

        // GET: Bicycles
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAsync());
        }

        // GET: Bicycles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.GetAsync(id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        // GET: Bicycles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bicycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BicycleId,ModelName")] Bicycle bicycle)
        {
            if (ModelState.IsValid)
            {
                _context.AddAsync(bicycle);
                return RedirectToAction(nameof(Index));
            }
            return View(bicycle);
        }

        // GET: Bicycles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.GetAsync(id);
            if (bicycle == null)
            {
                return NotFound();
            }
            return View(bicycle);
        }

        // POST: Bicycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BicycleId,ModelName")] Bicycle bicycle)
        {
            if (id != bicycle.BicycleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.UpdateAsync(bicycle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicycleExists(bicycle.BicycleId))
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
            return View(bicycle);
        }

        // GET: Bicycles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.GetAsync(id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        // POST: Bicycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bicycle = await _context.GetAsync(id);
            if (bicycle != null)
            {
                _context.DeleteAsync(bicycle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicycleExists(int id)
        {
            return _context.GetAsync().Result.Any(e => e.BicycleId == id);
        }
    }
}
