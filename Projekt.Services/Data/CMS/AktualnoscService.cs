using BazaDanych.Data;
using BazaDanych.Data.CMS;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS;

public class AktualnoscService : ABaseService, IAktualnoscService<Aktualnosc>
{
    public AktualnoscService(BazaContext context) : base(context)
    {
    }

    public bool AnyItem(int id)
        => _context.Aktualnosci.Any(e => e.AktualnosciId == id);

    public async Task CreateItemAsync(Aktualnosc item)
    {
        await _context.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Aktualnosc?> FindItemAsync(int id)
        => await _context.Aktualnosci.FindAsync(id);

    public async Task<Aktualnosc?> GetItemByIdAsync(int id)
        => await _context.Aktualnosci.FirstOrDefaultAsync(m => m.AktualnosciId == id);

    public async Task SoftDeleteItemAsync(int item)
    {
        var marka = await _context.Aktualnosci.FirstAsync(i => i.AktualnosciId == item);
        if (marka != null)
        {
            marka.IsDeleted = true;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Aktualnosc>> SoftGetAllItemsAsync() 
        => await _context.Aktualnosci.Where(w => w.IsDeleted == false).ToListAsync();

    public async Task UpdateItemAsync(Aktualnosc item)
    {
        _context.Update(item);
        await _context.SaveChangesAsync();
    }
}
