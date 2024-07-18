using BazaDanych.Data;
using BazaDanych.Data.CMS;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS;

public class SlCechaPojazduService(BazaContext context) : ABaseService(context), ISlCechaPojazduService<SlCechaPojazdu>
{
    public bool AnyItem(int id)
        => _context.SlCechyPojazdow.Any(e => e.Id == id);
    public async Task CreateItemAsync(SlCechaPojazdu item)
    {
        await _context.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<SlCechaPojazdu?> FindItemAsync(int id)
        => await _context.SlCechyPojazdow.FindAsync(id);
    public async Task<SlCechaPojazdu?> GetItemByIdAsync(int id)
        => await _context.SlCechyPojazdow.FirstOrDefaultAsync(m => m.Id == id);

    public async Task SoftDeleteItemAsync(int item)
    {
        var marka = await _context.SlCechyPojazdow.FirstAsync(i => i.Id == item);
        if (marka != null)
        {
            marka.IsDeleted = true;
        }
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<SlCechaPojazdu>> SoftGetAllItemsAsync()
        => await _context.SlCechyPojazdow.Where(w => w.IsDeleted == false).ToListAsync();

    public async Task UpdateItemAsync(SlCechaPojazdu item)
    {
        _context.Update(item);
        await _context.SaveChangesAsync();
    }
}
