using BazaDanych.Data;
using BazaDanych.Data.CMS;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS
{
    public class SlMarkaService : ABaseService, ISlMarkaService<SlMarka>
    {
        public SlMarkaService(BazaContext context) : base(context)
        {
        }
        public async Task CreateItemAsync(SlMarka item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task SoftDeleteItemAsync(int item)
        {
            var marka = await _context.SlMarkiPojazdow.FirstAsync(i => i.IdSlMarka == item);
            if (marka != null)
            {
                marka.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }
        public async Task UpdateItemAsync(SlMarka item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task<SlMarka?> GetItemByIdAsync(int id)
            => await _context.SlMarkiPojazdow
                .Include(i => i.Pojazdy)
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync(w => w.IdSlMarka == id);
        //    => await _context.SlMarkiPojazdow.FirstOrDefaultAsync(m => m.IdSlMarka == id);

        public async Task<IEnumerable<SlMarka>> SoftGetAllItemsAsync()
            => await _context.SlMarkiPojazdow.Where(w => w.IsDeleted == false).ToListAsync();

        public async Task<SlMarka?> FindItemAsync(int id)
            => await _context.SlMarkiPojazdow.FindAsync(id);

        public bool AnyItem(int id)
            => _context.SlMarkiPojazdow.Any(e => e.IdSlMarka == id);


    }
}
