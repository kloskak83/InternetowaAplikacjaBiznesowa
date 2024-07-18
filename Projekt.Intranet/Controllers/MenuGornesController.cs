using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BazaDanych.Data;
using BazaDanych.Data.Menu;
using Projekt.Interfaces.Data.Menu;

namespace Projekt.Intranet.Controllers
{
    public class MenuGornesController(IMenuGorneService _menuGorneService) : Controller
    {
       
        // GET: MenuGornes
        public async Task<IActionResult> Index()
        {
            //return View(await _context.MenuGornes.ToListAsync());
            return View(await _menuGorneService.SoftGetAllItemsAsync());
        }

        // GET: MenuGornes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuGorne = await _menuGorneService.GetItemByIdAsync(id.Value);
            if (menuGorne == null)
            {
                return NotFound();
            }

            return View(menuGorne);
        }

        // GET: MenuGornes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuGornes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMenuGorne,NaglowekIntranet,NazwaPortal,TypPolaId")] MenuGorne menuGorne)
        {
            if (ModelState.IsValid)
            {
                await _menuGorneService.CreateItemAsync(menuGorne);
                return RedirectToAction(nameof(Index));
            }
            return View(menuGorne);
        }

        // GET: MenuGornes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuGorne = await _menuGorneService.FindItemAsync(id.Value);
            if (menuGorne == null)
            {
                return NotFound();
            }
            return View(menuGorne);
        }

        // POST: MenuGornes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMenuGorne,NaglowekIntranet,NazwaPortal,TypPolaId")] MenuGorne menuGorne)
        {
            if (id != menuGorne.IdMenuGorne)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _menuGorneService.UpdateItemAsync(menuGorne);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuGorneExists(menuGorne.IdMenuGorne))
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
            return View(menuGorne);
        }

        // GET: MenuGornes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuGorne = await _menuGorneService.GetItemByIdAsync(id.Value);
            if (menuGorne == null)
            {
                return NotFound();
            }

            return View(menuGorne);
        }

        // POST: MenuGornes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _menuGorneService.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MenuGorneExists(int id)
        {
            return _menuGorneService.AnyItem(id);
        }
    }
}
