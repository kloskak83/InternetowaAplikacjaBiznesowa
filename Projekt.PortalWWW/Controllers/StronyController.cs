using BazaDanych.Data.Portal;
using Microsoft.AspNetCore.Mvc;
using Projekt.Interfaces.Data.Portal;

namespace Projekt.PortalWWW.Controllers
{
    public class StronyController(IStronaService<Strona> _stronaService) : Controller
    {
        public async Task<IActionResult> Index(int? id)
        { 
            if (id == null)
            {
                return NotFound();
            }
            var item = await _stronaService.GetItemByIdAsync(id.Value);
            if (item == null)
            {
                return NotFound();
            }
            return View(await _stronaService.GetItemByIdAsync(id.Value));
        }
    }
}
