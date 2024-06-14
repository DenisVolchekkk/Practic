using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domains.Models;
using Repositories.Repositories.AppRepositories;

namespace BicyclesWeb.Controllers
{
    public class SupplierTypesController : Controller
    {
        private readonly SupplierTypeRepository _context;

        public SupplierTypesController(SupplierTypeRepository context)
        {
            _context = context;
        }

        // GET: SupplierTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAsync());
        }

        // GET: SupplierTypes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.GetAsync(id);
            if (supplierType == null)
            {
                return NotFound();
            }

            return View(supplierType);
        }

        // GET: SupplierTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierTypeId,SupplierTypeName")] SupplierType supplierType)
        {
            if (ModelState.IsValid)
            {
                _context.AddAsync(supplierType);
                return RedirectToAction(nameof(Index));
            }
            return View(supplierType);
        }

        // GET: SupplierTypes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.GetAsync(id);
            if (supplierType == null)
            {
                return NotFound();
            }
            return View(supplierType);
        }

        // POST: SupplierTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierTypeId,SupplierTypeName")] SupplierType supplierType)
        {
            if (id != supplierType.SupplierTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.UpdateAsync(supplierType);
                }
                catch (DbUpdateConcurrencyException)
                {
                        return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplierType);
        }

        // GET: SupplierTypes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.GetAsync(id);
            if (supplierType == null)
            {
                return NotFound();
            }

            return View(supplierType);
        }

        // POST: SupplierTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierType = await _context.GetAsync(id);
            if (supplierType != null)
            {
                _context.DeleteAsync(supplierType);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
