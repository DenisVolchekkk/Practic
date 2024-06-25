using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domains.Models;
using Domains.ViewModels;
using Repositories.Context;
using Repositories.Repositories.AppRepositories;
using ClosedXML.Excel;

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
            var totalPartsRequired = partOrder.Bicycle.PartBicycles
                .GroupBy(pb => pb.Part)
                .Select(g => new PartOrderViewModel
                {
                    PartName = g.Key.PartName,
                    TotalQuantity = g.Sum(pb => pb.QuantityRequired * partOrder.CountofBicycles)
                }).ToList();

            var totalDays = (partOrder.ExpectedDeliveryDate - partOrder.OrderDate).TotalDays;
            var partsPerDay = totalPartsRequired
                .Select(p => new PartOrderViewModel
                {
                    PartName = p.PartName,
                    DailyQuantity = totalDays == 0 ? 0 : ((double)p.TotalQuantity / (double)totalDays)
                }).ToList();

            ViewData["TotalPartsRequired"] = totalPartsRequired;
            ViewData["PartsPerDay"] = partsPerDay;

            return View(partOrder);
        }
        [HttpPost]
        public async Task<IActionResult> ExportToExcel(int id)
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

            var totalPartsRequired = partOrder.Bicycle.PartBicycles
                .GroupBy(pb => pb.Part)
                .Select(g => new PartOrderViewModel
                {
                    PartName = g.Key.PartName,
                    TotalQuantity = g.Sum(pb => pb.QuantityRequired * partOrder.CountofBicycles)
                }).ToList();

            var totalDays = (partOrder.ExpectedDeliveryDate - partOrder.OrderDate).TotalDays;
            var partsPerDay = totalPartsRequired
                .Select(p => new PartOrderViewModel
                {
                    PartName = p.PartName,
                    DailyQuantity = totalDays == 0 ? 0 : ((double)p.TotalQuantity / (double)totalDays)
                }).ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("PartOrderDetails");

                worksheet.Cell(1, 1).Value = "Заказ";
                worksheet.Cell(2, 1).Value = "Дата заказа";
                worksheet.Cell(2, 2).Value = partOrder.OrderDate;
                worksheet.Cell(3, 1).Value = "Дата выполнения заказа";
                worksheet.Cell(3, 2).Value = partOrder.ExpectedDeliveryDate;
                worksheet.Cell(4, 1).Value = "Кол-во велосипедов";
                worksheet.Cell(4, 2).Value = partOrder.CountofBicycles;
                worksheet.Cell(5, 1).Value = "Модель велосипеда";
                worksheet.Cell(5, 2).Value = partOrder.Bicycle.ModelName;

                worksheet.Cell(7, 1).Value = "Общее количество деталей для всех велосипедов";
                worksheet.Cell(8, 1).Value = "Название детали";
                worksheet.Cell(8, 2).Value = "Общее количество";

                var row = 9;
                foreach (var part in totalPartsRequired)
                {
                    worksheet.Cell(row, 1).Value = part.PartName;
                    worksheet.Cell(row, 2).Value = part.TotalQuantity;
                    row++;
                }

                row += 2;
                worksheet.Cell(row, 1).Value = "Количество деталей для производства за один день";
                worksheet.Cell(row + 1, 1).Value = "Название детали";
                worksheet.Cell(row + 1, 2).Value = "Количество в день";

                row += 2;
                foreach (var part in partsPerDay)
                {
                    worksheet.Cell(row, 1).Value = part.PartName;
                    worksheet.Cell(row, 2).Value = part.DailyQuantity;
                    row++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "PartOrderDetails.xlsx");
                }
            }
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
                await _context.AddAsync(partOrder);
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
                    await _context.UpdateAsync(partOrder);
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
                await _context.DeleteAsync(partOrder);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PartOrderExists(int id)
        {
            return _context.GetAsync().Result.Any(e => e.PartOrderId == id);
        }
    }
}
