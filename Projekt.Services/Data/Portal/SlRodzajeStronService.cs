using BazaDanych.Data;
using BazaDanych.Data.Portal;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.Portal;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.Portal
{
    public class SlRodzajeStronService(BazaContext baseContext) : ABaseService(baseContext), ISlRodzajeStronService<SlRodzajeStron>
    {
        public bool AnyItem(int id)
            => _context.RodzejStron.Any(e => e.Id == id);

        public async Task CreateItemAsync(SlRodzajeStron item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<SlRodzajeStron?> FindItemAsync(int id)
            => await _context.RodzejStron.FindAsync(id);

        public async Task<SlRodzajeStron?> GetItemByIdAsync(int id)
            => await _context.RodzejStron.FirstOrDefaultAsync(m => m.Id == id);

        public async Task SoftDeleteItemAsync(int item)
        {
            var marka = await _context.RodzejStron.FirstAsync(i => i.Id == item);
            if (marka != null)
            {
                marka.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SlRodzajeStron>> SoftGetAllItemsAsync()
            => await _context.RodzejStron.Where(w => w.IsDeleted == false).ToListAsync();

        public async Task UpdateItemAsync(SlRodzajeStron item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
