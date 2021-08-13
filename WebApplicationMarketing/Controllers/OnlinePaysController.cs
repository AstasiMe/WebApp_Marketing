using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationMarketing.Data_;
using WebApplicationMarketing.Models_;

namespace WebApplicationMarketing.Controllers
{
    public class OnlinePaysController : Controller
    {
        private readonly MyappdbContext _context;

        public OnlinePaysController(MyappdbContext context)
        {
            _context = context;
        }

        // GET: OnlinePays
        public async Task<IActionResult> Index()
        {
            var myappdbContext = _context.OnlinePays.Include(o => o.IdNavigation);
            return View(await myappdbContext.ToListAsync());
        }

        // GET: OnlinePays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlinePay = await _context.OnlinePays
                .Include(o => o.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdOp == id);
            if (onlinePay == null)
            {
                return NotFound();
            }

            return View(onlinePay);
        }

        // GET: OnlinePays/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: OnlinePays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOp,PaySiteRub,PaySiteCount,OnlineSales,AverageCheck,PayConversion,DataMonth,Id")] OnlinePay onlinePay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onlinePay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", onlinePay.Id);
            return View(onlinePay);
        }

        // GET: OnlinePays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlinePay = await _context.OnlinePays.FindAsync(id);
            if (onlinePay == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", onlinePay.Id);
            return View(onlinePay);
        }

        // POST: OnlinePays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOp,PaySiteRub,PaySiteCount,OnlineSales,AverageCheck,PayConversion,DataMonth,Id")] OnlinePay onlinePay)
        {
            if (id != onlinePay.IdOp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onlinePay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnlinePayExists(onlinePay.IdOp))
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
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", onlinePay.Id);
            return View(onlinePay);
        }

        // GET: OnlinePays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlinePay = await _context.OnlinePays
                .Include(o => o.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdOp == id);
            if (onlinePay == null)
            {
                return NotFound();
            }

            return View(onlinePay);
        }

        // POST: OnlinePays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var onlinePay = await _context.OnlinePays.FindAsync(id);
            _context.OnlinePays.Remove(onlinePay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnlinePayExists(int id)
        {
            return _context.OnlinePays.Any(e => e.IdOp == id);
        }
    }
}
