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
    public class SuppliersController : Controller
    {
        private readonly SupplierRepository _context;
        private readonly SupplierTypeRepository _SpContext;

        public SuppliersController(SupplierRepository context, SupplierTypeRepository spContext)
        {
            _context = context;
            _SpContext = spContext;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            var bicyclesContext = _context.GetAsync();
            return View(await bicyclesContext);
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.GetAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            ViewData["SupplierTypeId"] = new SelectList(_SpContext.GetAsync().Result, "SupplierTypeId", "SupplierTypeName");
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,SupplierName,ContactInfo,Address,SupplierTypeId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierTypeId"] = new SelectList(_SpContext.GetAsync().Result, "SupplierTypeId", "SupplierTypeName", supplier.SupplierTypeId);
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.GetAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            ViewData["SupplierTypeId"] = new SelectList(_SpContext.GetAsync().Result, "SupplierTypeId", "SupplierTypeName", supplier.SupplierTypeId);
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,SupplierName,ContactInfo,Address,SupplierTypeId")] Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAsync(supplier);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.SupplierId))
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
            ViewData["SupplierTypeId"] = new SelectList(_SpContext.GetAsync().Result, "SupplierTypeId", "SupplierTypeName", supplier.SupplierTypeId);
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.GetAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.GetAsync(id);
            if (supplier != null)
            {
                await _context.DeleteAsync(supplier);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
            return _context.GetAsync().Result.Any(e => e.SupplierId == id);
        }
    }
}
