#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api_web.Models;

namespace api_web.Controllers
{
    public class IntervensionsController : Controller
    {
        private readonly consultorioContext _context;

        public IntervensionsController(consultorioContext context)
        {
            _context = context;
        }

        // GET: Intervensions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Intervensions.ToListAsync());
        }

        // GET: Intervensions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervension = await _context.Intervensions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (intervension == null)
            {
                return NotFound();
            }

            return View(intervension);
        }

        // GET: Intervensions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Intervensions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipointervension")] Intervension intervension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intervension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(intervension);
        }

        // GET: Intervensions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervension = await _context.Intervensions.FindAsync(id);
            if (intervension == null)
            {
                return NotFound();
            }
            return View(intervension);
        }

        // POST: Intervensions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipointervension")] Intervension intervension)
        {
            if (id != intervension.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intervension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntervensionExists(intervension.Id))
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
            return View(intervension);
        }

        // GET: Intervensions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervension = await _context.Intervensions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (intervension == null)
            {
                return NotFound();
            }

            return View(intervension);
        }

        // POST: Intervensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intervension = await _context.Intervensions.FindAsync(id);
            _context.Intervensions.Remove(intervension);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntervensionExists(int id)
        {
            return _context.Intervensions.Any(e => e.Id == id);
        }
    }
}
