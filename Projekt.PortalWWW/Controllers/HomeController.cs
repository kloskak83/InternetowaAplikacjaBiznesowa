using BazaDanych.Data;
using BazaDanych.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;
using Projekt.Interfaces.Data.Portal;
using Projekt.PortalWWW.Models;
using System.Diagnostics;

namespace Projekt.PortalWWW.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly BazaContext _dbContext;
        private readonly IStronyNaSztywnoService _stronyNaSztywnoService;
		private readonly IAktualnoscService<Aktualnosc> _aktualnoscService;

        public HomeController(
            IAktualnoscService<Aktualnosc> aktualnoscService,
            ILogger<HomeController> logger, BazaContext bazaContext,IStronyNaSztywnoService stronyNaSztywnoService)
		{
			_logger = logger;
			_dbContext = bazaContext;
			_stronyNaSztywnoService = stronyNaSztywnoService;
			_aktualnoscService = aktualnoscService;
        }

		public async Task<IActionResult> Index()
		{
			ViewBag.ModelPojazdy = (from pojazdy in _dbContext.Pojazdy select pojazdy).ToList();
			return View(await _stronyNaSztywnoService.GetStronaAsync(3));
		}

        public async Task<IActionResult> PanelKlienta()
        {
            return View(await _stronyNaSztywnoService.GetStronaAsync(1));
        }

        public async Task<IActionResult> Kontakt()
		{ 
			return View(await _stronyNaSztywnoService.GetStronaAsync(2)); 
		}
		public IActionResult Privacy()
		{
			ViewBag.ModelPojazdy = (from pojazdy in _dbContext.Pojazdy select pojazdy).ToList();
			return View();
		}

		public async Task<IActionResult> Aktualnosci()
		{
			// ViewBag.ModelAktualnosci = (from aktualnosci in _dbContext.Aktualnosci select aktualnosci).ToList();
			
			return View(await _aktualnoscService.SoftGetAllItemsAsync());
		}
		public IActionResult Samochody()
		{
			// ViewBag.ModelAktualnosci = (from aktualnosci in _dbContext.Aktualnosci select aktualnosci).ToList();

			//  var item = _dbContext.Pojazdy.ToList();

			//var item = _dbContext.Pojazdy.Select(item => new PojazdyListaDto
			//{
			//    Naglowek = item.Model + " " + _dbContext.SlMarkiPojazdow
			//        .FirstOrDefault(s=>s.IdSlMarka == item.IdSlownikMarka).MarkaPojazdu
			//        .ToString(),
			//    TypSilnika = _dbContext.SlTypySilnikow
			//        .Where(s=> s.IdSlTypSilnika == item.IdTypSilnika)
			//        .Select(s=>s.NazwaTypuSilnika)
			//        .ToString()+"",
			//    SkrzyniaBiegow = item.SlTypSkrzyniBiegow.NazwaTypuSkrzyniBiegow,
			//    LiczbaDrzwi = item.IloscDrzwi,
			//    SciezkaDoZdjecia = item.SciezkaDoZdjecia

			//});
			//var item = (from pojazd in _dbContext.Pojazdy
			//            join typSilnika in _dbContext.SlTypySilnikow
			//            on pojazd.IdTypSilnika equals typSilnika.IdSlTypSilnika
			//            join skrzyniaBiegow in _dbContext.SlTypySkrzyniBiegow
			//            on pojazd.IdTypSkrzyniBiegow equals skrzyniaBiegow.IdSlTypSkrzyniBiegow
			//            select new PojazdyListaDto
			//            {
			//                Naglowek = pojazd.NazwaWSerwisie,
			//                TypSilnika = typSilnika.NazwaTypuSilnika,
			//                SciezkaDoZdjecia = pojazd.SciezkaDoZdjecia,
			//                SkrzyniaBiegow = skrzyniaBiegow.NazwaTypuSkrzyniBiegow,
			//                LiczbaDrzwi = pojazd.IloscDrzwi,
			//            })
			//            .ToList();
			var item = _dbContext.Pojazdy
				.Include(i => i.SlMarka)
				.Include(i => i.SlTypSilnika)
				.Include(i => i.SlTypSkrzyniBiegow)
				.ToList();

			return View(item);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
