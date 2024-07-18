using BazaDanych.Data;
using BazaDanych.Data.CMS;
using BazaDanych.Data.CMS.Wypozyczenia;
using BazaDanych.Model;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS.Wypozyczenia;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS.Wypozyczenia;
//Zlaczyc to za pomoca jednej encij i wyrzucic na endpointa
public class ZestawienieWypozyczenPojazdowService(BazaContext bazaContext) : ABaseService(bazaContext), IZestawienieWypozyczenPojazdow
{

    public async Task<IEnumerable<NajlepsiKlienci>> NajlepsiKlienciTop5Async()

    //    var result = _context.RejestrWypozyczens.Include(i => i.Uzytkownik)
    //    .Select(s => new { Imie = s.Uzytkownik.Imie, Nazwisko = s.Uzytkownik.Nazwisko, IloscDni = (s.WypozyczenieDo - s.WypozyczenieOd).Days });

    //    return await Task.Run(() => result.GroupBy(i => new { i.Imie, i.Nazwisko })
    //        .Select(g => new NajlepsiKlienci
    //        {
    //            Imie = g.Key.Imie,
    //            Nazwisko = g.Key.Nazwisko,
    //            IloscWypozyczen = g.Sum(i => i.IloscDni)
    //        })
    //        .OrderByDescending(o => o.IloscWypozyczen)
    //        .Take(5));
    //}


    => await _context.Uzytkownicy.Select(s => new NajlepsiKlienci { Imie = "Jas", Nazwisko = "Kapela", IloscWypozyczen = 100 }).Take(5).ToListAsync();

    public async Task<IEnumerable<Zyski>> ZesawienieZyskowAsync()
        => await _context.RejestrWypozyczens.Select(s => new Zyski { MarkaPojazdu = "Marka", IloscWypozyczen = 1, Zysk = 200 }).ToListAsync();
    //    => await Task.Run(()=>(from rejestr in _context.RejestrWypozyczens
    //              join pojazd in _context.Pojazdy on rejestr.IdPojazd equals pojazd.IdPojazd
    //              join marka in _context.SlMarkiPojazdow on pojazd.IdSlownikMarka equals marka.IdSlMarka
    //              where !rejestr.IsDeleted && !pojazd.IsDeleted && !marka.IsDeleted
    //              group new { rejestr, pojazd
    //}
    //by marka.MarkaPojazdu into g
    //              select new Zyski
    //              {
    //                  MarkaPojazdu = g.Key,
    //                  IloscWypozyczen = g.Count(),
    //                  Zysk = g.Sum(x => (x.rejestr.WypozyczenieDo - x.rejestr.WypozyczenieOd).Days* x.pojazd.KosztWypozyczeniaDoba)
    //              }));


    public async Task<IEnumerable<Pojazd>> WypozyczeniaWOkresieAsync(DateTime dataOd, DateTime dataDo)
    {
        //Hardkodujemy
        var wynik = await _context.RejestrWypozyczens.Where(w => w.WypozyczenieOd >= dataOd && w.WypozyczenieDo <= dataDo).Select(s => s.Pojazd).ToListAsync();
        return wynik;
    }
}
