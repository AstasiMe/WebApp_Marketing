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
    public class SocialMediumsController : Controller
    {
        private readonly MyappdbContext _context;

        public SocialMediumsController(MyappdbContext context)
        {
            _context = context;
        }

        // GET: SocialMediums
        public async Task<IActionResult> Index()
        {
            var myappdbContext = _context.SocialMedia.Include(s => s.IdNavigation);
            return View(await myappdbContext.ToListAsync());
        }

        // GET: SocialMediums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedium = await _context.SocialMedia
                .Include(s => s.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdSm == id);
            if (socialMedium == null)
            {
                return NotFound();
            }

            return View(socialMedium);
        }

        // GET: SocialMediums/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: SocialMediums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSm,LeadsVk,OtherLeads,DataMonth,Id")] SocialMedium socialMedium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialMedium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", socialMedium.Id);
            return View(socialMedium);
        }

        // GET: SocialMediums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedium = await _context.SocialMedia.FindAsync(id);
            if (socialMedium == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", socialMedium.Id);
            return View(socialMedium);
        }

        // POST: SocialMediums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSm,LeadsVk,OtherLeads,DataMonth,Id")] SocialMedium socialMedium)
        {
            if (id != socialMedium.IdSm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialMedium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediumExists(socialMedium.IdSm))
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
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", socialMedium.Id);
            return View(socialMedium);
        }

        // GET: SocialMediums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedium = await _context.SocialMedia
                .Include(s => s.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdSm == id);
            if (socialMedium == null)
            {
                return NotFound();
            }

            return View(socialMedium);
        }

        // POST: SocialMediums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialMedium = await _context.SocialMedia.FindAsync(id);
            _context.SocialMedia.Remove(socialMedium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialMediumExists(int id)
        {
            return _context.SocialMedia.Any(e => e.IdSm == id);
        }
    }
}
