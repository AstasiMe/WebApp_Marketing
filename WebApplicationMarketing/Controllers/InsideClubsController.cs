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
    public class InsideClubsController : Controller
    {
        private readonly MyappdbContext _context;

        public InsideClubsController(MyappdbContext context)
        {
            _context = context;
        }

        // GET: InsideClubs
        public async Task<IActionResult> Index()
        {
            var myappdbContext = _context.InsideClubs.Include(i => i.IdNavigation);
            return View(await myappdbContext.ToListAsync());
        }

        // GET: InsideClubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insideClub = await _context.InsideClubs
                .Include(i => i.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdIc == id);
            if (insideClub == null)
            {
                return NotFound();
            }

            return View(insideClub);
        }

        // GET: InsideClubs/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: InsideClubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIc,GuestVisits,CallsMopPhone,CallsReceptPhone,Calltracking,OtherLeads,DataMonth,Id")] InsideClub insideClub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insideClub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", insideClub.Id);
            return View(insideClub);
        }

        // GET: InsideClubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insideClub = await _context.InsideClubs.FindAsync(id);
            if (insideClub == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", insideClub.Id);
            return View(insideClub);
        }

        // POST: InsideClubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIc,GuestVisits,CallsMopPhone,CallsReceptPhone,Calltracking,OtherLeads,DataMonth,Id")] InsideClub insideClub)
        {
            if (id != insideClub.IdIc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insideClub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsideClubExists(insideClub.IdIc))
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
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", insideClub.Id);
            return View(insideClub);
        }

        // GET: InsideClubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insideClub = await _context.InsideClubs
                .Include(i => i.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdIc == id);
            if (insideClub == null)
            {
                return NotFound();
            }

            return View(insideClub);
        }

        // POST: InsideClubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insideClub = await _context.InsideClubs.FindAsync(id);
            _context.InsideClubs.Remove(insideClub);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsideClubExists(int id)
        {
            return _context.InsideClubs.Any(e => e.IdIc == id);
        }
    }
}
