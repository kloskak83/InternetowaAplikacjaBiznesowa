using BazaDanych.Data;
using BazaDanych.Data.CMS.Uzytkownicy;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS.Uzytkownicy;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS.Uzytkownicy;

public class UzytkownikService(BazaContext context) : ABaseService(context), IUzytkownikService<Uzytkownik>
{
    public bool AnyItem(int id) 
        => _context.Uzytkownicy.Any(e => e.Id == id);

    public async Task CreateItemAsync(Uzytkownik item)
    {
        await _context.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Uzytkownik?> FindItemAsync(int id)
        => await _context.Uzytkownicy.FindAsync(id);

    public async Task<Uzytkownik?> GetItemByIdAsync(int id)
        => await _context.Uzytkownicy
        .Include(i=>i.SlTypUzytkownika)
        .FirstOrDefaultAsync(m => m.Id == id);

    public async Task SoftDeleteItemAsync(int item)
    {
        var marka = await _context.Uzytkownicy.FirstAsync(i => i.Id == item);
        if (marka != null)
        {
            marka.IsDeleted = true;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Uzytkownik>> SoftGetAllItemsAsync() 
        => await _context.Uzytkownicy
        .Where(w => w.IsDeleted == false)
        .Include(u=>u.SlTypUzytkownika)
        .ToListAsync();

    public async Task UpdateItemAsync(Uzytkownik item)
    {
        _context.Update(item);
        await _context.SaveChangesAsync();
    }
}
