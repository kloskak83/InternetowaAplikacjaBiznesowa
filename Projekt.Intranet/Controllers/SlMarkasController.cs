using BazaDanych.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;

namespace Projekt.Intranet.Controllers
{
    public class SlMarkasController(ISlMarkaService<SlMarka> _slMarkaService) : Controller
    {
        // GET: SlMarkas
        public async Task<IActionResult> Index()
        {
            return View(await _slMarkaService.SoftGetAllItemsAsync());
        }

        // GET: SlMarkas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slMarka = await _slMarkaService.GetItemByIdAsync(id.Value);
            if (slMarka == null)
            {
                return NotFound();
            }

            return View(slMarka);
        }

        // GET: SlMarkas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlMarkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSlMarka,IsDeleted,MarkaPojazdu")] SlMarka slMarka)
        {
            if (ModelState.IsValid)
            {
                await _slMarkaService.CreateItemAsync(slMarka);
                return RedirectToAction(nameof(Index));
            }
            return View(slMarka);
        }

        // GET: SlMarkas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slMarka = await _slMarkaService.FindItemAsync(id.Value);


            if (slMarka == null)
            {
                return NotFound();
            }
            return View(slMarka);
        }

        // POST: SlMarkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSlMarka,IsDeleted,MarkaPojazdu")] SlMarka slMarka)
        {
            if (id != slMarka.IdSlMarka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _slMarkaService.UpdateItemAsync(slMarka);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlMarkaExists(slMarka.IdSlMarka))
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
            return View(slMarka);
        }

        // GET: SlMarkas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slMarka = await _slMarkaService.GetItemByIdAsync(id.Value);
            if (slMarka == null)
            {
                return NotFound();
            }

            return View(slMarka);
        }

        // POST: SlMarkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _slMarkaService.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SlMarkaExists(int id)
        {
            return _slMarkaService.AnyItem(id);
        }
    }
}
