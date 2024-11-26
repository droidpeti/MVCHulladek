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
    public class SzolgaltatasController : Controller
    {
        private readonly MVCHulladekContext _context;

        public SzolgaltatasController(MVCHulladekContext context)
        {
            _context = context;
        }

        // GET: Szolgaltatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Szolgaltatas.ToListAsync());
        }

        // GET: Szolgaltatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var szolgaltatas = await _context.Szolgaltatas
                .FirstOrDefaultAsync(m => m.SzolgaltatasId == id);
            if (szolgaltatas == null)
            {
                return NotFound();
            }

            return View(szolgaltatas);
        }

        // GET: Szolgaltatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Szolgaltatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SzolgaltatasId,Tipus,Jelentes")] Szolgaltatas szolgaltatas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(szolgaltatas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(szolgaltatas);
        }

        // GET: Szolgaltatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var szolgaltatas = await _context.Szolgaltatas.FindAsync(id);
            if (szolgaltatas == null)
            {
                return NotFound();
            }
            return View(szolgaltatas);
        }

        // POST: Szolgaltatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SzolgaltatasId,Tipus,Jelentes")] Szolgaltatas szolgaltatas)
        {
            if (id != szolgaltatas.SzolgaltatasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(szolgaltatas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SzolgaltatasExists(szolgaltatas.SzolgaltatasId))
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
            return View(szolgaltatas);
        }

        // GET: Szolgaltatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var szolgaltatas = await _context.Szolgaltatas
                .FirstOrDefaultAsync(m => m.SzolgaltatasId == id);
            if (szolgaltatas == null)
            {
                return NotFound();
            }

            return View(szolgaltatas);
        }

        // POST: Szolgaltatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var szolgaltatas = await _context.Szolgaltatas.FindAsync(id);
            if (szolgaltatas != null)
            {
                _context.Szolgaltatas.Remove(szolgaltatas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SzolgaltatasExists(int id)
        {
            return _context.Szolgaltatas.Any(e => e.SzolgaltatasId == id);
        }
    }
}
