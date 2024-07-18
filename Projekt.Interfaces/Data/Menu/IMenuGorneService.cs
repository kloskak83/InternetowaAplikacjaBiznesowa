using BazaDanych.Data.Menu;

namespace Projekt.Interfaces.Data.Menu;
public interface IMenuGorneService : ICRUDItemServices<MenuGorne>
{
    public Task<MenuGorne?> FindItemAsync(int id);
    public bool AnyItem(int id);
}
