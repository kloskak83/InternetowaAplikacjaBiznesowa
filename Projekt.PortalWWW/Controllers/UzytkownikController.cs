using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BazaDanych.Data;
using BazaDanych.Data.CMS.Uzytkownicy;

namespace Projekt.PortalWWW.Controllers
{
    public class UzytkownikController : Controller
    {
        private readonly BazaContext _context;

        public UzytkownikController(BazaContext context)
        {
            _context = context;
        }

        // GET: Uzytkownik
        public async Task<IActionResult> Index()
        {
            var bazaContext = _context.Uzytkownicy.Include(u => u.SlTypUzytkownika);
            return View(await bazaContext.ToListAsync());
        }

        // GET: Uzytkownik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownicy
                .Include(u => u.SlTypUzytkownika)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // GET: Uzytkownik/Create
        public IActionResult Create()
        {
            ViewData["IdSlTypUzytkownika"] = new SelectList(_context.SlTypUzytkownik, "Id", "NazwaUprawnienia");
            return View();
        }

        // POST: Uzytkownik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Imie,Nazwisko,Email,Password,TelefonKontaktowy,ZamieszkanieAdres,ZamieszkanieMiasto,ZamieszkanieKodPoczotwy,KorespondencyjnyAdres,KorespondencyjnyMiasto,KoresponedncyjnyKodPocztowy,FirmaNazwa,FirmaNip,FirmaAdres,FirmaMiasto,FirmaKodPocztowy,IdSlTypUzytkownika,Id")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uzytkownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSlTypUzytkownika"] = new SelectList(_context.SlTypUzytkownik, "Id", "NazwaUprawnienia", uzytkownik.IdSlTypUzytkownika);
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownicy.FindAsync(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }
            ViewData["IdSlTypUzytkownika"] = new SelectList(_context.SlTypUzytkownik, "Id", "NazwaUprawnienia", uzytkownik.IdSlTypUzytkownika);
            return View(uzytkownik);
        }

        // POST: Uzytkownik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Imie,Nazwisko,Email,Password,TelefonKontaktowy,ZamieszkanieAdres,ZamieszkanieMiasto,ZamieszkanieKodPoczotwy,KorespondencyjnyAdres,KorespondencyjnyMiasto,KoresponedncyjnyKodPocztowy,FirmaNazwa,FirmaNip,FirmaAdres,FirmaMiasto,FirmaKodPocztowy,IdSlTypUzytkownika,Id")] Uzytkownik uzytkownik)
        {
            if (id != uzytkownik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzytkownik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzytkownikExists(uzytkownik.Id))
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
            ViewData["IdSlTypUzytkownika"] = new SelectList(_context.SlTypUzytkownik, "Id", "NazwaUprawnienia", uzytkownik.IdSlTypUzytkownika);
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownicy
                .Include(u => u.SlTypUzytkownika)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // POST: Uzytkownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uzytkownik = await _context.Uzytkownicy.FindAsync(id);
            if (uzytkownik != null)
            {
                _context.Uzytkownicy.Remove(uzytkownik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UzytkownikExists(int id)
        {
            return _context.Uzytkownicy.Any(e => e.Id == id);
        }
    }
}
