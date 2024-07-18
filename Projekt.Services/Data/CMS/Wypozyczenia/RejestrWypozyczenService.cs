using BazaDanych.Data;
using BazaDanych.Data.CMS.Wypozyczenia;
using Projekt.Interfaces.Data.CMS.Wypozyczenia;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS.Wypozyczenia;

public class RejestrWypozyczenService(BazaContext context) : ABaseService(context), IRejestrWypozyczen<RejestrWypozyczen>
{
    public Task CreateItemAsync(RejestrWypozyczen item)
    {
        throw new NotImplementedException();
    }

    public Task<RejestrWypozyczen?> GetItemByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SoftDeleteItemAsync(int item)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RejestrWypozyczen>> SoftGetAllItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateItemAsync(RejestrWypozyczen item)
    {
        throw new NotImplementedException();
    }
}
