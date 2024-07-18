using BazaDanych.Data.Portal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.Portal;

namespace Projekt.Intranet.Controllers
{
    public class StronyController(IStronaService<Strona> _stronaService, ISlRodzajeStronService<SlRodzajeStron> _slRodzajeStronService) : Controller
    {       
        // GET: Strony
        public async Task<IActionResult> Index()
        {            
            return View(await _stronaService.SoftGetAllItemsAsync());
        }

        // GET: Strony/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strona = await _stronaService.GetItemByIdAsync(id.Value);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

        // GET: Strony/Create
        public async Task<IActionResult> Create()
        {
            await ViewDataSelectList();
            return View();
        }

        // POST: Strony/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkTytul,Tytul,Tresc,Pozycja,IdSlRodzajeStron")] Strona strona)
        {
            if (ModelState.IsValid)
            {
                await _stronaService.CreateItemAsync(strona);
                return RedirectToAction(nameof(Index));
            }
            await ViewDataSelectList();
            return View(strona);
        }

        // GET: Strony/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strona = await _stronaService.FindItemAsync(id.Value);
            if (strona == null)
            {
                return NotFound();
            }
            await ViewDataSelectList();
            return View(strona);
        }

        // POST: Strony/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LinkTytul,Tytul,Tresc,Pozycja,IdSlRodzajeStron")] Strona strona)
        {
            if (id != strona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _stronaService.UpdateItemAsync(strona);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronaExists(strona.Id))
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
            return View(strona);
        }

        // GET: Strony/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strona = await _stronaService.GetItemByIdAsync(id.Value);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

        // POST: Strony/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {            
            await _stronaService.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StronaExists(int id)
        {
            return _stronaService.AnyItem(id);
        }

        private async Task ViewDataSelectList()
        {
            ViewData["IdSlRodzajeStron"] = new SelectList(await _slRodzajeStronService.SoftGetAllItemsAsync(), "Id", "LinkTytul");
        }
    }
}
