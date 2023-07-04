using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hutagazyn.Data;
using Hutagazyn.Models;

namespace Hutagazyn.Controllers
{
    public class AdditionalOrderInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdditionalOrderInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdditionalOrderInfo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AdditionalOrderInfo.Include(a => a.Order).Include(a => a.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AdditionalOrderInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdditionalOrderInfo == null)
            {
                return NotFound();
            }

            var additionalOrderInfo = await _context.AdditionalOrderInfo
                .Include(a => a.Order)
                .Include(a => a.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (additionalOrderInfo == null)
            {
                return NotFound();
            }

            return View(additionalOrderInfo);
        }

        // GET: AdditionalOrderInfo/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "CreationDate");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            return View();
        }

        // POST: AdditionalOrderInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,ProductId,OrderId")] AdditionalOrderInfo additionalOrderInfo)
        {
                _context.Add(additionalOrderInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: AdditionalOrderInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdditionalOrderInfo == null)
            {
                return NotFound();
            }

            var additionalOrderInfo = await _context.AdditionalOrderInfo.FindAsync(id);
            if (additionalOrderInfo == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "CreationDate", additionalOrderInfo.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", additionalOrderInfo.ProductId);
            return View(additionalOrderInfo);
        }

        // POST: AdditionalOrderInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,ProductId,OrderId")] AdditionalOrderInfo additionalOrderInfo)
        {
            if (id != additionalOrderInfo.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(additionalOrderInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdditionalOrderInfoExists(additionalOrderInfo.Id))
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

        // GET: AdditionalOrderInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdditionalOrderInfo == null)
            {
                return NotFound();
            }

            var additionalOrderInfo = await _context.AdditionalOrderInfo
                .Include(a => a.Order)
                .Include(a => a.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (additionalOrderInfo == null)
            {
                return NotFound();
            }

            return View(additionalOrderInfo);
        }

        // POST: AdditionalOrderInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdditionalOrderInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AdditionalOrderInfo'  is null.");
            }
            var additionalOrderInfo = await _context.AdditionalOrderInfo.FindAsync(id);
            if (additionalOrderInfo != null)
            {
                _context.AdditionalOrderInfo.Remove(additionalOrderInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdditionalOrderInfoExists(int id)
        {
          return (_context.AdditionalOrderInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
