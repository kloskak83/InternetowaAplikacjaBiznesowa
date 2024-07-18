using BazaDanych.Data;
using BazaDanych.Data.Menu;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.Menu;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.Menu;

public class MenuGorneServices(BazaContext context) : ABaseService(context), IMenuGorneService
{
    public bool AnyItem(int id)
        => _context.MenuGornes.Any(e => e.IdMenuGorne == id);

    public async Task CreateItemAsync(MenuGorne item)
    {
        await _context.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<MenuGorne?> FindItemAsync(int id)
        => await _context.MenuGornes.FindAsync(id);

    public async Task<MenuGorne?> GetItemByIdAsync(int id)
        => await _context.MenuGornes.FirstOrDefaultAsync(x => x.IdMenuGorne == id);

    public async Task SoftDeleteItemAsync(int item)
    {
        var marka = await _context.MenuGornes.FirstAsync(i => i.IdMenuGorne == item);
        if (marka != null)
        {
            marka.IsDeleted = true;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MenuGorne>> SoftGetAllItemsAsync()
         => await _context.MenuGornes.Where(w => w.IsDeleted == false).ToListAsync();

    public async Task UpdateItemAsync(MenuGorne item)
    {
        _context.Update(item);
        await _context.SaveChangesAsync();
    }
}
