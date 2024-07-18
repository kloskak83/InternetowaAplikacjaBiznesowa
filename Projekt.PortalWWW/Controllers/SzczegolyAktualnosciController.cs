using BazaDanych.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Projekt.Interfaces.Data.CMS;

namespace Projekt.PortalWWW.Controllers
{
    public class SzczegolyAktualnosciController(IAktualnoscService<Aktualnosc> _aktualnoscService) : Controller
    {
        public async Task<IActionResult> Index(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }
            return View(await _aktualnoscService.GetItemByIdAsync(id.Value));
        }
    }
}
