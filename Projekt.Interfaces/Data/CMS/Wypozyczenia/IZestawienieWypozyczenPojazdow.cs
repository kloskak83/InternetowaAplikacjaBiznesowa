using BazaDanych.Data.CMS;
using BazaDanych.Data.CMS.Wypozyczenia;
using BazaDanych.Model;

namespace Projekt.Interfaces.Data.CMS.Wypozyczenia;

public interface IZestawienieWypozyczenPojazdow
{    
    public Task<IEnumerable<Zyski>> ZesawienieZyskowAsync();
    public Task<IEnumerable<Pojazd>> WypozyczeniaWOkresieAsync(DateTime DataOd, DateTime dataDo);
    public Task<IEnumerable<NajlepsiKlienci>> NajlepsiKlienciTop5Async();
}
