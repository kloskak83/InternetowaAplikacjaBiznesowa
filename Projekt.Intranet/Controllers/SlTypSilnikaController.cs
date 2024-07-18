using BazaDanych.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;

namespace Projekt.Intranet.Controllers
{
    public class SlTypSilnikaController : Controller
    {        
        private readonly ISlTypSilnikaService<SlTypSilnika> _slTypSilnikaService;

        public SlTypSilnikaController(ISlTypSilnikaService<SlTypSilnika> slTypSilnikaService)
        {
           _slTypSilnikaService = slTypSilnikaService;
        }

        // GET: SlTypSilnika
        public async Task<IActionResult> Index()
        {
            return View(await _slTypSilnikaService.SoftGetAllItemsAsync());
        }

        // GET: SlTypSilnika/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slTypSilnika = await _slTypSilnikaService.GetItemByIdAsync(id.Value);
            if (slTypSilnika == null)
            {
                return NotFound();
            }

            return View(slTypSilnika);
        }

        // GET: SlTypSilnika/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlTypSilnika/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NazwaTypuSilnika")] SlTypSilnika slTypSilnika)
        {
            if (ModelState.IsValid)
            {
                await _slTypSilnikaService.CreateItemAsync(slTypSilnika);
                return RedirectToAction(nameof(Index));
            }
            return View(slTypSilnika);
        }

        // GET: SlTypSilnika/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slTypSilnika = await _slTypSilnikaService.FindItemAsync(id.Value);
            if (slTypSilnika == null)
            {
                return NotFound();
            }
            return View(slTypSilnika);
        }

        // POST: SlTypSilnika/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazwaTypuSilnika")] SlTypSilnika slTypSilnika)
        {
            if (id != slTypSilnika.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _slTypSilnikaService.UpdateItemAsync(slTypSilnika);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlTypSilnikaExists(slTypSilnika.Id))
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
            return View(slTypSilnika);
        }

        // GET: SlTypSilnika/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slTypSilnika = await _slTypSilnikaService.GetItemByIdAsync(id.Value);
            if (slTypSilnika == null)
            {
                return NotFound();
            }

            return View(slTypSilnika);
        }

        // POST: SlTypSilnika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _slTypSilnikaService.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SlTypSilnikaExists(int id)
        {
            return _slTypSilnikaService.AnyItem(id);
        }
    }
}
