using BazaDanych.Data.CMS.Wypozyczenia;
using BazaDanych.Data;
using Projekt.Interfaces.Data.CMS.Wypozyczenia;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS.Wypozyczenia;

public class NazwaStatusuWypozyczenService(BazaContext context) : ABaseService(context), INazwaStatusuWypozyczenia<NazwaStatusuWypozyczenia>
{
    public Task CreateItemAsync(NazwaStatusuWypozyczenia item)
    {
        throw new NotImplementedException();
    }

    public Task<NazwaStatusuWypozyczenia?> GetItemByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SoftDeleteItemAsync(int item)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<NazwaStatusuWypozyczenia>> SoftGetAllItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateItemAsync(NazwaStatusuWypozyczenia item)
    {
        throw new NotImplementedException();
    }
}
