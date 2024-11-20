using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Goaltracking.Data;
using Goaltracking.Models;

namespace Goaltracking.Controllers
{
    public class GoalTrackingAppsController : Controller
    {
        private readonly GoaltrackingContext _context;

        public GoalTrackingAppsController(GoaltrackingContext context)
        {
            _context = context;
        }

        // GET: GoalTrackingApps
        public async Task<IActionResult> Index()
        {
            return View(await _context.GoalTrackingApp.ToListAsync());
        }

        // GET: GoalTrackingApps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalTrackingApp = await _context.GoalTrackingApp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goalTrackingApp == null)
            {
                return NotFound();
            }

            return View(goalTrackingApp);
        }

        // GET: GoalTrackingApps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoalTrackingApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Target,Progress")] GoalTrackingApp goalTrackingApp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goalTrackingApp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goalTrackingApp);
        }

        // GET: GoalTrackingApps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalTrackingApp = await _context.GoalTrackingApp.FindAsync(id);
            if (goalTrackingApp == null)
            {
                return NotFound();
            }
            return View(goalTrackingApp);
        }

        // POST: GoalTrackingApps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Target,Progress")] GoalTrackingApp goalTrackingApp)
        {
            if (id != goalTrackingApp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goalTrackingApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoalTrackingAppExists(goalTrackingApp.Id))
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
            return View(goalTrackingApp);
        }

        // GET: GoalTrackingApps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalTrackingApp = await _context.GoalTrackingApp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goalTrackingApp == null)
            {
                return NotFound();
            }

            return View(goalTrackingApp);
        }

        // POST: GoalTrackingApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goalTrackingApp = await _context.GoalTrackingApp.FindAsync(id);
            _context.GoalTrackingApp.Remove(goalTrackingApp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoalTrackingAppExists(int id)
        {
            return _context.GoalTrackingApp.Any(e => e.Id == id);
        }
    }
}
