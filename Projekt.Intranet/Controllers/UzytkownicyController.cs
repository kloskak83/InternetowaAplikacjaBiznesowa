using BazaDanych.Data;
using BazaDanych.Data.CMS.Uzytkownicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS.Uzytkownicy;

namespace Projekt.Intranet.Controllers
{
    public class UzytkownicyController(ISlTypUzytkownikaService<SlTypUzytkownika> _slTypUzytkownikaService,
        IUzytkownikService<Uzytkownik> _uzytkownikService) : Controller
    {        
        // GET: Uzytkownicy
        public async Task<IActionResult> Index()
        {
            return View(await _uzytkownikService.SoftGetAllItemsAsync());
        }

        // GET: Uzytkownicy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _uzytkownikService.GetItemByIdAsync(id.Value);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // GET: Uzytkownicy/Create
        public async Task<IActionResult> Create()
        {
            await ViewDataSelectList();
            return View();
        }

        // POST: Uzytkownicy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,Email,Password,TelefonKontaktowy,ZamieszkanieAdres,ZamieszkanieMiasto,ZamieszkanieKodPoczotwy,KorespondencyjnyAdres,KorespondencyjnyMiasto,KoresponedncyjnyKodPocztowy,FirmaNazwa,FirmaNip,FirmaAdres,FirmaMiasto,FirmaKodPocztowy,IdSlTypUzytkownika")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {                
                await _uzytkownikService.CreateItemAsync(uzytkownik);
                return RedirectToAction(nameof(Index));
            }
            await ViewDataSelectList();
            return View(uzytkownik);
        }

        // GET: Uzytkownicy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _uzytkownikService.FindItemAsync(id.Value);
            if (uzytkownik == null)
            {
                return NotFound();
            }
            await ViewDataSelectList();
            return View(uzytkownik);
        }

        // POST: Uzytkownicy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,Email,Password,TelefonKontaktowy,ZamieszkanieAdres,ZamieszkanieMiasto,ZamieszkanieKodPoczotwy,KorespondencyjnyAdres,KorespondencyjnyMiasto,KoresponedncyjnyKodPocztowy,FirmaNazwa,FirmaNip,FirmaAdres,FirmaMiasto,FirmaKodPocztowy,IdSlTypUzytkownika")] Uzytkownik uzytkownik)
        {
            if (id != uzytkownik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _uzytkownikService.UpdateItemAsync(uzytkownik);
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
            await ViewDataSelectList();
            return View(uzytkownik);
        }

        // GET: Uzytkownicy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _uzytkownikService.GetItemByIdAsync(id.Value);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // POST: Uzytkownicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _uzytkownikService.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UzytkownikExists(int id)
            => _uzytkownikService.AnyItem(id);

        private async Task ViewDataSelectList()
        {
            ViewData["IdSlTypUzytkownika"] = new SelectList(await _slTypUzytkownikaService.SoftGetAllItemsAsync(), "Id", "NazwaUprawnienia");
        }
    }
}
