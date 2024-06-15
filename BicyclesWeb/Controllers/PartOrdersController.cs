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
    public class PartOrdersController : Controller
    {
        private readonly PartOrderRepository _context;
        private readonly BicycleRepository _BContext;


        public PartOrdersController(PartOrderRepository context, BicycleRepository bContext)
        {
            _context = context;
            _BContext = bContext;
        }

        // GET: PartOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAsync());
        }

        // GET: PartOrders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partOrder = await _context.GetAsync(id);
            if (partOrder == null)
            {
                return NotFound();
            }

            return View(partOrder);
        }

        // GET: PartOrders/Create
        public IActionResult Create()
        {
            ViewData["BicycleId"] = new SelectList(_BContext.GetAsync().Result, "BicycleId", "ModelName");
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
                _context.AddAsync(partOrder);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BicycleId"] = new SelectList(_BContext.GetAsync().Result, "BicycleId", "ModelName", partOrder.BicycleId);
            return View(partOrder);
        }

        // GET: PartOrders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partOrder = await _context.GetAsync(id);
            if (partOrder == null)
            {
                return NotFound();
            }
            ViewData["BicycleId"] = new SelectList(_BContext.GetAsync().Result, "BicycleId", "ModelName", partOrder.BicycleId);
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
                    _context.UpdateAsync(partOrder);
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
            ViewData["BicycleId"] = new SelectList(_BContext.GetAsync().Result, "BicycleId", "ModelName", partOrder.BicycleId);
            return View(partOrder);
        }

        // GET: PartOrders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partOrder = await _context.GetAsync(id);
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
            var partOrder = await _context.GetAsync(id);
            if (partOrder != null)
            {
                _context.DeleteAsync(partOrder);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PartOrderExists(int id)
        {
            return _context.GetAsync().Result.Any(e => e.PartOrderId == id);
        }
    }
}
