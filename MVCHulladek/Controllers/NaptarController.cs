using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCHulladek.Data;
using MVCHulladek.Models;

namespace MVCHulladek.Controllers
{
    public class NaptarController : Controller
    {
        private readonly MVCHulladekContext _context;

        public NaptarController(MVCHulladekContext context)
        {
            _context = context;
        }

        // GET: Naptar
        public async Task<IActionResult> Index()
        {
            var mVCHulladekContext = _context.Naptar.Include(n => n.Szolgaltatas);
            return View(await mVCHulladekContext.ToListAsync());
        }

        // GET: Naptar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naptar = await _context.Naptar
                .Include(n => n.Szolgaltatas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naptar == null)
            {
                return NotFound();
            }

            return View(naptar);
        }

        // GET: Naptar/Create
        public IActionResult Create()
        {
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "SzolgaltatasId", "Jelentes");
            return View();
        }

        // POST: Naptar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,SzolgaltatasId")] Naptar naptar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(naptar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "SzolgaltatasId", "Jelentes", naptar.SzolgaltatasId);
            return View(naptar);
        }

        // GET: Naptar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naptar = await _context.Naptar.FindAsync(id);
            if (naptar == null)
            {
                return NotFound();
            }
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "SzolgaltatasId", "Jelentes", naptar.SzolgaltatasId);
            return View(naptar);
        }

        // POST: Naptar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,SzolgaltatasId")] Naptar naptar)
        {
            if (id != naptar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naptar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaptarExists(naptar.Id))
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
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "SzolgaltatasId", "Jelentes", naptar.SzolgaltatasId);
            return View(naptar);
        }

        // GET: Naptar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naptar = await _context.Naptar
                .Include(n => n.Szolgaltatas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naptar == null)
            {
                return NotFound();
            }

            return View(naptar);
        }

        // POST: Naptar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var naptar = await _context.Naptar.FindAsync(id);
            if (naptar != null)
            {
                _context.Naptar.Remove(naptar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaptarExists(int id)
        {
            return _context.Naptar.Any(e => e.Id == id);
        }
    }
}
