using BazaDanych.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;
using Projekt.Intranet.Helpers.IHelpers;

namespace Projekt.Intranet.Controllers
{
    //TODO: Czy to normalne ze tyle zaleznosci w kontrolerze? Czy lepiej to jakos uproscic?
    public class PojazdyController(IPojazdService<Pojazd> _pojazdService,
                    ISlMarkaService<SlMarka> _slMarkaService,
                    ISlSegmentPojazduService<SlSegmentPojazdu> _slSegmentPojazdowService,
                    ISlTypSilnikaService<SlTypSilnika> _slTypSilnikaService,
                    ISlTypSkrzyniBiegowService<SlTypSkrzyniBiegow> _slTypSkrzyniBiegowService,
                    IFileHelper _fileHelper
                    ) : Controller
    {

        // GET: Pojazdy
        public async Task<IActionResult> Index()
        {
            return View(await _pojazdService.SoftGetAllItemsAsync());
        }

        // GET: Pojazdy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pojazd = await _pojazdService.GetItemByIdAsync(id.Value);
            return View(pojazd);
        }

        // GET: Pojazdy/Create
        public async Task<IActionResult> Create()
        {
            await ViewDataSelectList();
            return View();
        }

        // POST: Pojazdy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPojazd,IdSlownikMarka,Model,NazwaWSerwisie,IdTypSilnika,IdTypSkrzyniBiegow,IdSegmentPojazdu," +
            "CzyMaKlimatyzacje,PojemnoscSilnika,MocSilnika,SpalanieMiejskie,IloscPoduszek,IloscDrzwi,CzyMaABS,CzyMaElektryczneSzyby,CzyMaElektryczneLusterka," +
            "CzyMaPodgrzewaneLusterka,CzyMaKomputerPokladowy,CzyMaCentralnyZamek,DataProdukcji,OpisPojazdu,Zdjecie,SciezkaDoZdjecia")] Pojazd pojazd)
        {
            try
            {
                ModelState.Remove("SciezkaDoZdjecia");

                if (ModelState.IsValid)
                {
                    if (pojazd.Zdjecie != null)
                    {
                        pojazd.SciezkaDoZdjecia = await _fileHelper.SaveImageToWebAsync("samochody", pojazd.Zdjecie);                       
                    }
                    await _pojazdService.CreateItemAsync(pojazd);
                    return RedirectToAction(nameof(Index));
                }
                await ViewDataSelectList();
                return View(pojazd);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET: Pojazdy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pojazd = await _pojazdService.FindItemAsync(id.Value);
            if (pojazd == null)
            {
                return NotFound();
            }
            await ViewDataSelectList();
            return View(pojazd);
        }

        // POST: Pojazdy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPojazd,IdSlownikMarka,Model,NazwaWSerwisie,IdTypSilnika,IdTypSkrzyniBiegow,IdSegmentPojazdu,CzyMaKlimatyzacje,PojemnoscSilnika,MocSilnika,SpalanieMiejskie,IloscPoduszek,IloscDrzwi,CzyMaABS,CzyMaElektryczneSzyby,CzyMaElektryczneLusterka,CzyMaPodgrzewaneLusterka,CzyMaKomputerPokladowy,CzyMaCentralnyZamek,DataProdukcji,OpisPojazdu,Zdjecie")] Pojazd pojazd)
        {
            if (id != pojazd.IdPojazd)
            {
                return NotFound();
            }
            try
            {
                ModelState.Remove("SciezkaDoZdjecia");

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (pojazd.Zdjecie != null)
                        {
                            pojazd.SciezkaDoZdjecia = await _fileHelper.SaveImageToWebAsync("samochody", pojazd.Zdjecie);
                        }
                        await _pojazdService.UpdateItemAsync(pojazd);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PojazdExists(pojazd.IdPojazd))
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
                await ViewDataSelectList();
                return View(pojazd);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET: Pojazdy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pojazd = await _pojazdService.GetItemByIdAsync(id.Value);
            if (pojazd == null)
            {
                return NotFound();
            }

            return View(pojazd);
        }

        // POST: Pojazdy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _pojazdService.SoftDeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PojazdExists(int id)
            => _pojazdService.AnyItem(id);
        
        //TODO (AK: Wszystko dodac przez serwis) Są cztery widzę tysiąc. Czy przerobic to jakos,
        //czy zwracac mu DbSeta?
        private async Task ViewDataSelectList()
        {
            ViewData["IdSlownikMarka"] = new SelectList(await _slMarkaService.SoftGetAllItemsAsync(), "IdSlMarka", "MarkaPojazdu");
            ViewData["IdSegmentPojazdu"] = new SelectList(await _slSegmentPojazdowService.SoftGetAllItemsAsync(), "Id", "NazwaSegmentuPojazdu");
            ViewData["IdTypSilnika"] = new SelectList(await _slTypSilnikaService.SoftGetAllItemsAsync(), "Id", "NazwaTypuSilnika");
            ViewData["IdTypSkrzyniBiegow"] = new SelectList(await _slTypSkrzyniBiegowService.SoftGetAllItemsAsync(), "IdSlTypSkrzyniBiegow", "NazwaTypuSkrzyniBiegow");
        }
    }
}
