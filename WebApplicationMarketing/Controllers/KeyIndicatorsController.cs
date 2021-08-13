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
    public class KeyIndicatorsController : Controller
    {
        private readonly MyappdbContext _context;

        public KeyIndicatorsController(MyappdbContext context)
        {
            _context = context;
        }

        // GET: KeyIndicators
        public async Task<IActionResult> Index()
        {
            var myappdbContext = _context.KeyIndicators.Include(k => k.IdNavigation);
            return View(await myappdbContext.ToListAsync());
        }

        // GET: KeyIndicators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyIndicator = await _context.KeyIndicators
                .Include(k => k.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdKi == id);
            if (keyIndicator == null)
            {
                return NotFound();
            }

            return View(keyIndicator);
        }

        // GET: KeyIndicators/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: KeyIndicators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKi,LeadsSite,NewVisitorsSite,LeadsLandingPages,NewVisitorsLandingPages,AllLeadsSites,GoalsAdvertising,SpentWebsitePromotion,CostLeadSites,TargetCost,NewWebsiteVisitors,MailSubsShares,DataMonth,Id")] KeyIndicator keyIndicator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keyIndicator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", keyIndicator.Id);
            return View(keyIndicator);
        }

        // GET: KeyIndicators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyIndicator = await _context.KeyIndicators.FindAsync(id);
            if (keyIndicator == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", keyIndicator.Id);
            return View(keyIndicator);
        }

        // POST: KeyIndicators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKi,LeadsSite,NewVisitorsSite,LeadsLandingPages,NewVisitorsLandingPages,AllLeadsSites,GoalsAdvertising,SpentWebsitePromotion,CostLeadSites,TargetCost,NewWebsiteVisitors,MailSubsShares,DataMonth,Id")] KeyIndicator keyIndicator)
        {
            if (id != keyIndicator.IdKi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keyIndicator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeyIndicatorExists(keyIndicator.IdKi))
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
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", keyIndicator.Id);
            return View(keyIndicator);
        }

        // GET: KeyIndicators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyIndicator = await _context.KeyIndicators
                .Include(k => k.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdKi == id);
            if (keyIndicator == null)
            {
                return NotFound();
            }

            return View(keyIndicator);
        }

        // POST: KeyIndicators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keyIndicator = await _context.KeyIndicators.FindAsync(id);
            _context.KeyIndicators.Remove(keyIndicator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeyIndicatorExists(int id)
        {
            return _context.KeyIndicators.Any(e => e.IdKi == id);
        }
    }
}
