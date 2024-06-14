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
    public class PartOrdersController : Controller
    {
        private readonly BicyclesContext _context;

        public PartOrdersController(BicyclesContext context)
        {
            _context = context;
        }

        // GET: PartOrders
        public async Task<IActionResult> Index()
        {
            var bicyclesContext = _context.PartOrders.Include(p => p.Bicycle);
            return View(await bicyclesContext.ToListAsync());
        }

        // GET: PartOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partOrder = await _context.PartOrders
                .Include(p => p.Bicycle)
                .FirstOrDefaultAsync(m => m.PartOrderId == id);
            if (partOrder == null)
            {
                return NotFound();
            }

            return View(partOrder);
        }

        // GET: PartOrders/Create
        public IActionResult Create()
        {
            ViewData["BicycleId"] = new SelectList(_context.Bicycles, "BicycleId", "BicycleId");
            return View();
        }

        // POST: PartOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartOrderId,OrderDate,ExpectedDeliveryDate,BicycleId,CountofBicycles")] PartOrder partOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BicycleId"] = new SelectList(_context.Bicycles, "BicycleId", "BicycleId", partOrder.BicycleId);
            return View(partOrder);
        }

        // GET: PartOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partOrder = await _context.PartOrders.FindAsync(id);
            if (partOrder == null)
            {
                return NotFound();
            }
            ViewData["BicycleId"] = new SelectList(_context.Bicycles, "BicycleId", "BicycleId", partOrder.BicycleId);
            return View(partOrder);
        }

        // POST: PartOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartOrderId,OrderDate,ExpectedDeliveryDate,BicycleId,CountofBicycles")] PartOrder partOrder)
        {
            if (id != partOrder.PartOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartOrderExists(partOrder.PartOrderId))
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
            ViewData["BicycleId"] = new SelectList(_context.Bicycles, "BicycleId", "BicycleId", partOrder.BicycleId);
            return View(partOrder);
        }

        // GET: PartOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partOrder = await _context.PartOrders
                .Include(p => p.Bicycle)
                .FirstOrDefaultAsync(m => m.PartOrderId == id);
            if (partOrder == null)
            {
                return NotFound();
            }

            return View(partOrder);
        }

        // POST: PartOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partOrder = await _context.PartOrders.FindAsync(id);
            if (partOrder != null)
            {
                _context.PartOrders.Remove(partOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartOrderExists(int id)
        {
            return _context.PartOrders.Any(e => e.PartOrderId == id);
        }
    }
}
