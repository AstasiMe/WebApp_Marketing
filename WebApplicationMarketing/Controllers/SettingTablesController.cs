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
    public class SettingTablesController : Controller
    {
        private readonly MyappdbContext _context;

        public SettingTablesController(MyappdbContext context)
        {
            _context = context;
        }

        // GET: SettingTables
        public async Task<IActionResult> Index()
        {
            var myappdbContext = _context.SettingTables.Include(s => s.IdNavigation);
            return View(await myappdbContext.ToListAsync());
        }

        // GET: SettingTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingTable = await _context.SettingTables
                .Include(s => s.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdSt == id);
            if (settingTable == null)
            {
                return NotFound();
            }

            return View(settingTable);
        }

        // GET: SettingTables/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: SettingTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSt,IncomingTraffics,InsideClubs,KeysIndicators,OnlinePays,SocialMediums,Id")] SettingTable settingTable)
        {
            if (ModelState.IsValid)
            {
                //_context.SettingTables.Remove(settingTable);
                _context.Add(settingTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", settingTable.Id);
            return View(settingTable);
        }

        // GET: SettingTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingTable = await _context.SettingTables.FindAsync(id);
            if (settingTable == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", settingTable.Id);
            return View(settingTable);
        }

        // POST: SettingTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSt,IncomingTraffics,InsideClubs,KeysIndicators,OnlinePays,SocialMediums,Id")] SettingTable settingTable)
        {
            if (id != settingTable.IdSt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settingTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingTableExists(settingTable.IdSt))
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
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", settingTable.Id);
            return View(settingTable);
        }

        // GET: SettingTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingTable = await _context.SettingTables
                .Include(s => s.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdSt == id);
            if (settingTable == null)
            {
                return NotFound();
            }

            return View(settingTable);
        }

        // POST: SettingTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var settingTable = await _context.SettingTables.FindAsync(id);
            _context.SettingTables.Remove(settingTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Create));
        }

        private bool SettingTableExists(int id)
        {
            return _context.SettingTables.Any(e => e.IdSt == id);
        }
    }
}
