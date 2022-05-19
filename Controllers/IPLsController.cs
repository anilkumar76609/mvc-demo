using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCDemo3.Models;

namespace MVCDemo3.Controllers
{
    public class IPLsController : Controller
    {
        private readonly IplContext _context;

        public IPLsController(IplContext context)
        {
            _context = context;
        }

        // GET: IPLs
        public async Task<IActionResult> Index()
        {
              return _context.IPLs != null ? 
                          View(await _context.IPLs.ToListAsync()) :
                          Problem("Entity set 'IplContext.IPLs'  is null.");
        }

        // GET: IPLs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IPLs == null)
            {
                return NotFound();
            }

            var iPL = await _context.IPLs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iPL == null)
            {
                return NotFound();
            }

            return View(iPL);
        }

        // GET: IPLs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IPLs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamName,MatchesPlayed,MatchesWin,MatchesLoss,NetRunrate,TeamPoints")] IPL iPL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iPL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iPL);
        }

        // GET: IPLs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IPLs == null)
            {
                return NotFound();
            }

            var iPL = await _context.IPLs.FindAsync(id);
            if (iPL == null)
            {
                return NotFound();
            }
            return View(iPL);
        }

        // POST: IPLs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamName,MatchesPlayed,MatchesWin,MatchesLoss,NetRunrate,TeamPoints")] IPL iPL)
        {
            if (id != iPL.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iPL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IPLExists(iPL.Id))
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
            return View(iPL);
        }

        // GET: IPLs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IPLs == null)
            {
                return NotFound();
            }

            var iPL = await _context.IPLs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iPL == null)
            {
                return NotFound();
            }

            return View(iPL);
        }

        // POST: IPLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IPLs == null)
            {
                return Problem("Entity set 'IplContext.IPLs'  is null.");
            }
            var iPL = await _context.IPLs.FindAsync(id);
            if (iPL != null)
            {
                _context.IPLs.Remove(iPL);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IPLExists(int id)
        {
          return (_context.IPLs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
