using BazaDanych.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;

namespace Projekt.Intranet.Controllers
{
    public class SlSegmentPojazduController(ISlSegmentPojazduService<SlSegmentPojazdu> _slSegmentPojazduService) 
        : Controller
    {
        // GET: SlSegmentPojazdu
        public async Task<IActionResult> Index()
        {
            return View(await _slSegmentPojazduService.SoftGetAllItemsAsync());            
        }

        // GET: SlSegmentPojazdu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slSegmentPojazdu = await _slSegmentPojazduService.GetItemByIdAsync(id.Value);
            if (slSegmentPojazdu == null)
            {
                return NotFound();
            }

            return View(slSegmentPojazdu);
        }

        // GET: SlSegmentPojazdu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlSegmentPojazdu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NazwaSegmentuPojazdu")] SlSegmentPojazdu slSegmentPojazdu)
        {
            if (ModelState.IsValid)
            {
                await _slSegmentPojazduService.CreateItemAsync(slSegmentPojazdu);
                return RedirectToAction(nameof(Index));
            }
            return View(slSegmentPojazdu);
        }

        // GET: SlSegmentPojazdu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slSegmentPojazdu = await _slSegmentPojazduService.FindItemAsync(id.Value);
            if (slSegmentPojazdu == null)
            {
                return NotFound();
            }
            return View(slSegmentPojazdu);
        }

        // POST: SlSegmentPojazdu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazwaSegmentuPojazdu")] SlSegmentPojazdu slSegmentPojazdu)
        {
            if (id != slSegmentPojazdu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _slSegmentPojazduService.UpdateItemAsync(slSegmentPojazdu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlSegmentPojazduExists(slSegmentPojazdu.Id))
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
            return View(slSegmentPojazdu);
        }

        // GET: SlSegmentPojazdu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slSegmentPojazdu = await _slSegmentPojazduService.GetItemByIdAsync(id.Value);
            if (slSegmentPojazdu == null)
            {
                return NotFound();
            }

            return View(slSegmentPojazdu);
        }

        // POST: SlSegmentPojazdu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slSegmentPojazdu = await _slSegmentPojazduService.FindItemAsync(id);
            if (slSegmentPojazdu != null)
            {
                slSegmentPojazdu.IsDeleted = true;
            }

            await _slSegmentPojazduService.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SlSegmentPojazduExists(int id)
        {
            return _slSegmentPojazduService.AnyItem(id);
        }
    }
}
