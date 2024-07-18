using BazaDanych.Data.Portal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.Portal;

namespace Projekt.Intranet.Controllers
{

    public class SlRodzajeStronController(ISlRodzajeStronService<SlRodzajeStron> _slRodzajeStronService) : Controller
    {     

        // GET: SlRodzajeStron
        public async Task<IActionResult> Index()
        {
            return View(await _slRodzajeStronService.SoftGetAllItemsAsync());
        }

        // GET: SlRodzajeStron/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slRodzajeStron = await _slRodzajeStronService.GetItemByIdAsync(id.Value);
            if (slRodzajeStron == null)
            {
                return NotFound();
            }

            return View(slRodzajeStron);
        }

        // GET: SlRodzajeStron/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlRodzajeStron/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkTytul,Pozycja")] SlRodzajeStron slRodzajeStron)
        {
            if (ModelState.IsValid)
            {                
                await _slRodzajeStronService.CreateItemAsync(slRodzajeStron);             
                return RedirectToAction(nameof(Index));
            }
            return View(slRodzajeStron);
        }

        // GET: SlRodzajeStron/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slRodzajeStron = await _slRodzajeStronService.FindItemAsync(id.Value);
            if (slRodzajeStron == null)
            {
                return NotFound();
            }
            return View(slRodzajeStron);
        }

        // POST: SlRodzajeStron/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LinkTytul,Pozycja")] SlRodzajeStron slRodzajeStron)
        {
            if (id != slRodzajeStron.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _slRodzajeStronService.UpdateItemAsync(slRodzajeStron);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlRodzajeStronExists(slRodzajeStron.Id))
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
            return View(slRodzajeStron);
        }

        // GET: SlRodzajeStron/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slRodzajeStron = await _slRodzajeStronService.GetItemByIdAsync(id.Value);
            if (slRodzajeStron == null)
            {
                return NotFound();
            }

            return View(slRodzajeStron);
        }

        // POST: SlRodzajeStron/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _slRodzajeStronService.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SlRodzajeStronExists(int id)
        {
            return _slRodzajeStronService.AnyItem(id);
        }
    }
}
