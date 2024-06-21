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
    public class PartsController : Controller
    {
        private readonly PartRepository _context;
        private readonly SupplierRepository _SContext;


        public PartsController(PartRepository context, SupplierRepository scontext)
        {
            _context = context;
            _SContext = scontext;
        }

        // GET: Parts
        public async Task<IActionResult> Index()
        {
            var bicyclesContext = _context.GetAsync();
            return View(await bicyclesContext);
        }

        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.GetAsync(id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // GET: Parts/Create
        public IActionResult Create()
        {
            ViewData["SupplierId"] = new SelectList(_SContext.GetAsync().Result, "SupplierId", "SupplierName");
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartId,PartName,PartDescription,SupplierId")] Part part)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(part);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_SContext.GetAsync().Result, "SupplierId", "SupplierName", part.SupplierId);
            return View(part);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.GetAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_SContext.GetAsync().Result, "SupplierId", "SupplierName", part.SupplierId);
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartId,PartName,PartDescription,SupplierId")] Part part)
        {
            if (id != part.PartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAsync(part);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartExists(part.PartId))
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
            ViewData["SupplierId"] = new SelectList(_SContext.GetAsync().Result, "SupplierId", "SupplierName", part.SupplierId);
            return View(part);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.GetAsync(id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var part = await _context.GetAsync(id);
            if (part != null)
            {
                await _context.DeleteAsync(part);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PartExists(int id)
        {
            return _context.GetAsync().Result.Any(e => e.PartId == id);
        }
    }
}
