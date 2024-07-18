using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BazaDanych.Data;
using BazaDanych.Data.Portal;

namespace Projekt.Intranet.Controllers
{
    public class StronyNaSztywnoController : Controller
    {
        private readonly BazaContext _context;

        public StronyNaSztywnoController(BazaContext context)
        {
            _context = context;
        }

        // GET: StronyNaSztywno
        public async Task<IActionResult> Index()
        {
            return View(await _context.StronyNaSztywno.ToListAsync());
        }

        // GET: StronyNaSztywno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stronaNaSztywno = await _context.StronyNaSztywno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stronaNaSztywno == null)
            {
                return NotFound();
            }

            return View(stronaNaSztywno);
        }

        // GET: StronyNaSztywno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StronyNaSztywno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkTytul,Tresc,Id")] StronaNaSztywno stronaNaSztywno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stronaNaSztywno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stronaNaSztywno);
        }

        // GET: StronyNaSztywno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stronaNaSztywno = await _context.StronyNaSztywno.FindAsync(id);
            if (stronaNaSztywno == null)
            {
                return NotFound();
            }
            return View(stronaNaSztywno);
        }

        // POST: StronyNaSztywno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinkTytul,Tresc,Id")] StronaNaSztywno stronaNaSztywno)
        {
            if (id != stronaNaSztywno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stronaNaSztywno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronaNaSztywnoExists(stronaNaSztywno.Id))
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
            return View(stronaNaSztywno);
        }

        // GET: StronyNaSztywno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stronaNaSztywno = await _context.StronyNaSztywno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stronaNaSztywno == null)
            {
                return NotFound();
            }

            return View(stronaNaSztywno);
        }

        // POST: StronyNaSztywno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stronaNaSztywno = await _context.StronyNaSztywno.FindAsync(id);
            if (stronaNaSztywno != null)
            {
                _context.StronyNaSztywno.Remove(stronaNaSztywno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StronaNaSztywnoExists(int id)
        {
            return _context.StronyNaSztywno.Any(e => e.Id == id);
        }
    }
}
