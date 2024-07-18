using BazaDanych.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;

namespace Projekt.Intranet.Controllers
{
    public class SlTypSkrzyniBiegowController(ISlTypSkrzyniBiegowService<SlTypSkrzyniBiegow> _slTypSkrzyniBiegowService) 
        : Controller
    {  
        // GET: SlTypSkrzyniBiegow
        public async Task<IActionResult> Index()
        {
            return View(await _slTypSkrzyniBiegowService.SoftGetAllItemsAsync());
        }

        // GET: SlTypSkrzyniBiegow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slTypSkrzyniBiegow = await _slTypSkrzyniBiegowService.GetItemByIdAsync(id.Value);
            if (slTypSkrzyniBiegow == null)
            {
                return NotFound();
            }

            return View(slTypSkrzyniBiegow);
        }

        // GET: SlTypSkrzyniBiegow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlTypSkrzyniBiegow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSlTypSkrzyniBiegow,IsDeleted,NazwaTypuSkrzyniBiegow")] SlTypSkrzyniBiegow slTypSkrzyniBiegow)
        {
            if (ModelState.IsValid)
            {
                await _slTypSkrzyniBiegowService.CreateItemAsync(slTypSkrzyniBiegow);
                return RedirectToAction(nameof(Index));
            }
            return View(slTypSkrzyniBiegow);
        }

        // GET: SlTypSkrzyniBiegow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slTypSkrzyniBiegow = await _slTypSkrzyniBiegowService.FindItemAsync(id.Value);
            if (slTypSkrzyniBiegow == null)
            {
                return NotFound();
            }
            return View(slTypSkrzyniBiegow);
        }

        // POST: SlTypSkrzyniBiegow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSlTypSkrzyniBiegow,IsDeleted,NazwaTypuSkrzyniBiegow")] SlTypSkrzyniBiegow slTypSkrzyniBiegow)
        {
            if (id != slTypSkrzyniBiegow.IdSlTypSkrzyniBiegow)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _slTypSkrzyniBiegowService.UpdateItemAsync(slTypSkrzyniBiegow);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlTypSkrzyniBiegowExists(slTypSkrzyniBiegow.IdSlTypSkrzyniBiegow))
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
            return View(slTypSkrzyniBiegow);
        }

        // GET: SlTypSkrzyniBiegow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slTypSkrzyniBiegow = await _slTypSkrzyniBiegowService.GetItemByIdAsync(id.Value);
            if (slTypSkrzyniBiegow == null)
            {
                return NotFound();
            }

            return View(slTypSkrzyniBiegow);
        }

        // POST: SlTypSkrzyniBiegow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _slTypSkrzyniBiegowService.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SlTypSkrzyniBiegowExists(int id)
        {
            return _slTypSkrzyniBiegowService.AnyItem(id);
        }
    }
}
