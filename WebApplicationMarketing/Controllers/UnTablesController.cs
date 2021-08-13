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
    public class UnTablesController : Controller
    {
        private readonly MyappdbContext _context;

        public UnTablesController(MyappdbContext context)
        {
            _context = context;
        }


        //public void AddGraph()
        //{

        //    List<UnTable> tb;
        //    tb = (from m in _context.UnTables
        //          select m).ToList();


        //    var query = (from t in tb
        //                 select new { t.NewVisitors }).ToList();



        //    var myChart = new Chart(width: 600, height: 400).AddTitle("Таблица").AddSeries(chartType: "column", xValue: query,
        //  yValues: new[] { "2", "6", "4", "5", "3" }).Write();

        //    myChart.Save("~/wwwroot", "jpeg");

        //}


        // GET: UnTables
        public async Task<IActionResult> Index()
        {
            var myappdbContext = _context.UnTables.Include(u => u.IdNavigation);
            return View(await myappdbContext.ToListAsync());
        }

        // GET: UnTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unTable = await _context.UnTables
                .Include(u => u.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdUt == id);
            if (unTable == null)
            {
                return NotFound();
            }

            return View(unTable);
        }

        // GET: UnTables/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: UnTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUt,Sales,SalesCount,AdvertisingCosts,NewVisitors,SiteLeads,NewClient,ApplicPhone,ApplicSocial,DataMonth,Id")] UnTable unTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", unTable.Id);
            return View(unTable);
        }

        // GET: UnTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unTable = await _context.UnTables.FindAsync(id);
            if (unTable == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", unTable.Id);
            return View(unTable);
        }

        // POST: UnTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUt,Sales,SalesCount,AdvertisingCosts,NewVisitors,SiteLeads,NewClient,ApplicPhone,ApplicSocial,DataMonth,Id")] UnTable unTable)
        {
            if (id != unTable.IdUt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnTableExists(unTable.IdUt))
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
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", unTable.Id);
            return View(unTable);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unTable = await _context.UnTables
                .Include(u => u.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdUt == id);
            if (unTable == null)
            {
                return NotFound();
            }

            return View(unTable);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unTable = await _context.UnTables.FindAsync(id);
            _context.UnTables.Remove(unTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnTableExists(int id)
        {
            return _context.UnTables.Any(e => e.IdUt == id);
        }
    }
}
