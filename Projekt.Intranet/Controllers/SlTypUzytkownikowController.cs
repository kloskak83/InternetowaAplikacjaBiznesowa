using BazaDanych.Data.CMS.Uzytkownicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS.Uzytkownicy;

namespace Projekt.Intranet.Controllers
{
    public class SlTypUzytkownikowController(ISlTypUzytkownikaService<SlTypUzytkownika> _slTypUzytkownikaService) : Controller
    {        

        // GET: SlTypUzytkownikow
        public async Task<IActionResult> Index()
        {
            return View(await _slTypUzytkownikaService.SoftGetAllItemsAsync());           
        }

        // GET: SlTypUzytkownikow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slTypUzytkownika = await _slTypUzytkownikaService.GetItemByIdAsync(id.Value);
            if (slTypUzytkownika == null)
            {
                return NotFound();
            }

            return View(slTypUzytkownika);
        }

        // GET: SlTypUzytkownikow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlTypUzytkownikow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NazwaUprawnienia,OpisUprawnieniaUzytkownika")] SlTypUzytkownika slTypUzytkownika)
        {
            if (ModelState.IsValid)
            {               
                await _slTypUzytkownikaService.CreateItemAsync(slTypUzytkownika);
                return RedirectToAction(nameof(Index));
            }
            return View(slTypUzytkownika);
        }

        // GET: SlTypUzytkownikow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slTypUzytkownika = await _slTypUzytkownikaService.FindItemAsync(id.Value);
            if (slTypUzytkownika == null)
            {
                return NotFound();
            }
            return View(slTypUzytkownika);
        }

        // POST: SlTypUzytkownikow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazwaUprawnienia,OpisUprawnieniaUzytkownika")] SlTypUzytkownika slTypUzytkownika)
        {
            if (id != slTypUzytkownika.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _slTypUzytkownikaService.UpdateItemAsync(slTypUzytkownika);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlTypUzytkownikaExists(slTypUzytkownika.Id))
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
            return View(slTypUzytkownika);
        }

        // GET: SlTypUzytkownikow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slTypUzytkownika = await _slTypUzytkownikaService.GetItemByIdAsync(id.Value);
            if (slTypUzytkownika == null)
            {
                return NotFound();
            }

            return View(slTypUzytkownika);
        }

        // POST: SlTypUzytkownikow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _slTypUzytkownikaService.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SlTypUzytkownikaExists(int id)
        {
            return _slTypUzytkownikaService.AnyItem(id);
        }
    }
}
