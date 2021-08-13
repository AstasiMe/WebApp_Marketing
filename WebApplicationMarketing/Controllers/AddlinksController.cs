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
    public class AddlinksController : Controller
    {
        public MyappdbContext _context;

        public AddlinksController(MyappdbContext context)
        {
            _context = context;
        }


        // GET: Addlinks
        public async Task<IActionResult> Index()
        {
            var myappdbContext = _context.Addlinks.Include(a => a.IdNavigation);
            return View(await myappdbContext.ToListAsync());

        }

        // GET: Addlinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addlink = await _context.Addlinks
                .Include(a => a.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdLink == id);
            if (addlink == null)
            {
                return NotFound();
            }

            return View(addlink);
        }

        // GET: Addlinks/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Addlinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLink,YandexLink,GaLink,Id")] Addlink addlink)
        {
            if (ModelState.IsValid)
            {

                _context.Add(addlink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", addlink.Id);
            return View(addlink);
        }

        // GET: Addlinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var addlink = await _context.Addlinks.FindAsync(id);
            if (addlink == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", addlink.Id);
            return View(addlink);
        }

        // POST: Addlinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLink,YandexLink,GaLink,Id")] Addlink addlink)
        {
            if (id != addlink.IdLink)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addlink);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddlinkExists(addlink.IdLink))
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
            //  ViewData["Id"] = new SelectList(_context.Addlinks, "Id", "Id", addlink.Id);
            return View(addlink);




        }

        // GET: Addlinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addlink = await _context.Addlinks
                .Include(a => a.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdLink == id);
            if (addlink == null)
            {
                return NotFound();
            }

            return View(addlink);
        }

        // POST: Addlinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addlink = await _context.Addlinks.FindAsync(id);
            _context.Addlinks.Remove(addlink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddlinkExists(int id)
        {
            return _context.Addlinks.Any(e => e.IdLink == id);
        }
    }
}
