using BazaDanych.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;
using Projekt.Intranet.Helpers.IHelpers;
using System.Diagnostics;

namespace Projekt.Intranet.Controllers;

public class AktualnosciController(IAktualnoscService<Aktualnosc> _aktualnoscService,IFileHelper _fileHelper) : Controller
{   
    // GET: Aktualnosci
    public async Task<IActionResult> Index()
    {
        return View(await _aktualnoscService.SoftGetAllItemsAsync());
    }

    // GET: Aktualnosci/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aktualnosc = await _aktualnoscService.GetItemByIdAsync(id.Value);
        if (aktualnosc == null)
        {
            return NotFound();
        }

        return View(aktualnosc);
    }

    // GET: Aktualnosci/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Aktualnosci/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("AktualnosciId,IsDeleted,DataAktualnosci,Naglowek,Opis,Zdjecie,SciezkaDoZdjecia")] Aktualnosc aktualnosc)
    {
        try
        {
            ModelState.Remove("SciezkaDoZdjecia");

            if (ModelState.IsValid)
            {
                if (aktualnosc.Zdjecie != null)
                {
                    aktualnosc.SciezkaDoZdjecia = await _fileHelper.SaveImageToWebAsync("artykuly", aktualnosc.Zdjecie);
                }
                try
                {
                    await _aktualnoscService.CreateItemAsync(aktualnosc);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(aktualnosc);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // GET: Aktualnosci/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        try
        {
            var aktualnosc = await _aktualnoscService.FindItemAsync(id.Value);
            return View(aktualnosc);
        }
        catch
        {
            return NotFound();
        }

    }

    // POST: Aktualnosci/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("AktualnosciId,IsDeleted,DataAktualnosci,Naglowek,Opis,Zdjecie,SciezkaDoZdjecia")] Aktualnosc aktualnosc)
    {
        if (id != aktualnosc.AktualnosciId)
        {
            return NotFound();
        }

        try
        {
            ModelState.Remove("SciezkaDoZdjecia");

            if (ModelState.IsValid)
            {
                if (aktualnosc.Zdjecie != null)
                {
                    aktualnosc.SciezkaDoZdjecia = await _fileHelper.SaveImageToWebAsync("artykuly", aktualnosc.Zdjecie);
                }
                try
                {
                    await _aktualnoscService.UpdateItemAsync(aktualnosc);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AktualnoscExists(aktualnosc.AktualnosciId))
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
            return View(aktualnosc);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // GET: Aktualnosci/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aktualnosc = await _aktualnoscService.GetItemByIdAsync(id.Value);
        if (aktualnosc == null)
        {
            return NotFound();
        }

        return View(aktualnosc);
    }

    // POST: Aktualnosci/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {          
        await _aktualnoscService.SoftDeleteItemAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private bool AktualnoscExists(int id)
    {
        return _aktualnoscService.AnyItem(id);
    }
}
