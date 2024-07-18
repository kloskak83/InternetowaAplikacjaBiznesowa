using BazaDanych.Data;
using BazaDanych.Data.CMS;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS
{
    public class PojazdService : ABaseService, IPojazdService<Pojazd>
    {
        public PojazdService(BazaContext context)
            : base(context)
        {
        }

        public async Task CreateItemAsync(Pojazd item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteItemAsync(int item)
        {
            var pojazd = await _context.Pojazdy.FirstAsync(i => i.IdPojazd == item);
            pojazd.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateItemAsync(Pojazd item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task<Pojazd?> GetItemByIdAsync(int id)
            => await _context.Pojazdy
                .Include(p => p.SlMarka)
                .Include(p => p.SlSegmentPojazdu)
                .Include(p => p.SlTypSilnika)
                .Include(p => p.SlTypSkrzyniBiegow)
                .Include(p => p.SlCechaPojazdus)
                .FirstOrDefaultAsync(m => m.IdPojazd == id);

        public async Task<IEnumerable<Pojazd>> SoftGetAllItemsAsync()
            => await _context.Pojazdy
                .Where(w => w.IsDeleted == false)
                .Include(p => p.SlMarka)
                .Include(p => p.SlSegmentPojazdu)
                .Include(p => p.SlTypSilnika)
                .Include(p => p.SlTypSkrzyniBiegow)
                .Include(p => p.SlCechaPojazdus)
                .ToListAsync();

        public async Task<Pojazd?> FindItemAsync(int id)
             => await _context.Pojazdy.FindAsync(id);

        public bool AnyItem(int id)
            => _context.Pojazdy.Any(e => e.IdPojazd == id);
    }
}
