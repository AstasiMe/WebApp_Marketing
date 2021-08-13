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
    public class IncomingTrafficsController : Controller
    {
        private readonly MyappdbContext _context;

        public IncomingTrafficsController(MyappdbContext context)
        {
            _context = context;
        }

        // GET: IncomingTraffics
        public async Task<IActionResult> Index()
        {
            var myappdbContext = _context.IncomingTraffics.Include(i => i.IdNavigation);
            return View(await myappdbContext.ToListAsync());
        }

        // GET: IncomingTraffics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomingTraffic = await _context.IncomingTraffics
                .Include(i => i.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdIt == id);
            if (incomingTraffic == null)
            {
                return NotFound();
            }

            return View(incomingTraffic);
        }

        // GET: IncomingTraffics/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: IncomingTraffics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIt,IncomTrafficGv,IncomTrafficMop,NewCardsSold,OpConversion,DataMonth,Id")] IncomingTraffic incomingTraffic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incomingTraffic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", incomingTraffic.Id);
            return View(incomingTraffic);
        }

        // GET: IncomingTraffics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomingTraffic = await _context.IncomingTraffics.FindAsync(id);
            if (incomingTraffic == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", incomingTraffic.Id);
            return View(incomingTraffic);
        }

        // POST: IncomingTraffics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIt,IncomTrafficGv,IncomTrafficMop,NewCardsSold,OpConversion,DataMonth,Id")] IncomingTraffic incomingTraffic)
        {
            if (id != incomingTraffic.IdIt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomingTraffic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomingTrafficExists(incomingTraffic.IdIt))
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
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", incomingTraffic.Id);
            return View(incomingTraffic);
        }

        // GET: IncomingTraffics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomingTraffic = await _context.IncomingTraffics
                .Include(i => i.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdIt == id);
            if (incomingTraffic == null)
            {
                return NotFound();
            }

            return View(incomingTraffic);
        }

        // POST: IncomingTraffics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incomingTraffic = await _context.IncomingTraffics.FindAsync(id);
            _context.IncomingTraffics.Remove(incomingTraffic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomingTrafficExists(int id)
        {
            return _context.IncomingTraffics.Any(e => e.IdIt == id);
        }
    }
}
