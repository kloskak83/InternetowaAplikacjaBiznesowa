using BazaDanych.Data;
using BazaDanych.Data.Portal;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.Portal;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.Portal
{
    public class StronaService(BazaContext context) : ABaseService(context), IStronaService<Strona>
    {
        public bool AnyItem(int id)
            => _context.Strony.Any(e => e.Id == id);
        public async Task CreateItemAsync(Strona item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task<Strona?> FindItemAsync(int id)
            => await _context.Strony.FindAsync(id);
        public async Task<Strona?> GetItemByIdAsync(int id)
            => await _context.Strony
            .Include(p => p.SlRodzajeStron)
            .FirstOrDefaultAsync(m => m.Id == id);

        public async Task SoftDeleteItemAsync(int item)
        {
            var pojazd = await _context.Strony.FirstAsync(i => i.Id == item);
            pojazd.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Strona>> SoftGetAllItemsAsync()
            => await _context.Strony
                    .Where(w => w.IsDeleted == false)
                    .Include(p => p.SlRodzajeStron)
                    .ToListAsync();

        public async Task<IEnumerable<Strona>> SoftGetAllItemsByIdAsync(int id)
                   => await _context.Strony
                    .Where(w => w.IsDeleted == false)
                    .Where(w=> w.IdSlRodzajeStron == id)
                    .Include(p => p.SlRodzajeStron)
                    .ToListAsync();


        public async Task UpdateItemAsync(Strona item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}