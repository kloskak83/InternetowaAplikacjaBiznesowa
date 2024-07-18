using BazaDanych.Data.Portal;
using Microsoft.AspNetCore.Mvc;
using Projekt.Interfaces.Data.Portal;

namespace Projekt.PortalWWW.Controllers
{
    public class ListMenuComponent(IStronaService<Strona> _stronaService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
            => View("ListMenuComponent", await _stronaService.SoftGetAllItemsByIdAsync(2));
    }
}
