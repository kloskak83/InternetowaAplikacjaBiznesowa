using BazaDanych.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;

namespace Projekt.Intranet.Controllers
{
    public class SlCechaPojazduController : Controller
    {
        private readonly ISlCechaPojazduService<SlCechaPojazdu> _slCechaPojazdu;

        public SlCechaPojazduController(ISlCechaPojazduService<SlCechaPojazdu> slCechaPojazdu)
        {            
            _slCechaPojazdu = slCechaPojazdu;
        }

        // GET: SlCechaPojazdu
        public async Task<IActionResult> Index()
        {
            return View(await _slCechaPojazdu.SoftGetAllItemsAsync());            
        }

        // GET: SlCechaPojazdu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slCechaPojazdu = await _slCechaPojazdu.GetItemByIdAsync(id.Value);
            if (slCechaPojazdu == null)
            {
                return NotFound();
            }

            return View(slCechaPojazdu);
        }

        // GET: SlCechaPojazdu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlCechaPojazdu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CechaPojazdu")] SlCechaPojazdu slCechaPojazdu)
        {
            if (ModelState.IsValid)
            {
                await _slCechaPojazdu.CreateItemAsync(slCechaPojazdu);
                return RedirectToAction(nameof(Index));
            }
            return View(slCechaPojazdu);
        }

        // GET: SlCechaPojazdu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slCechaPojazdu = await _slCechaPojazdu.FindItemAsync(id.Value);
            if (slCechaPojazdu == null)
            {
                return NotFound();
            }
            return View(slCechaPojazdu);
        }

        // POST: SlCechaPojazdu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CechaPojazdu")] SlCechaPojazdu slCechaPojazdu)
        {
            if (id != slCechaPojazdu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _slCechaPojazdu.UpdateItemAsync(slCechaPojazdu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlCechaPojazduExists(slCechaPojazdu.Id))
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
            return View(slCechaPojazdu);
        }

        // GET: SlCechaPojazdu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slCechaPojazdu = await _slCechaPojazdu.GetItemByIdAsync(id.Value);
            if (slCechaPojazdu == null)
            {
                return NotFound();
            }

            return View(slCechaPojazdu);
        }

        // POST: SlCechaPojazdu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _slCechaPojazdu.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SlCechaPojazduExists(int id)
        {
            return _slCechaPojazdu.AnyItem(id);
        }
    }
}
