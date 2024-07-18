using BazaDanych.Data;
using BazaDanych.Data.CMS;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS
{
    public class SlTypSkrzyniBiegowService : ABaseService, ISlTypSkrzyniBiegowService<SlTypSkrzyniBiegow>
    {
        public SlTypSkrzyniBiegowService(BazaContext context) : base(context)
        {
        }

        public bool AnyItem(int id) 
            => _context.SlTypySkrzyniBiegow.Any(e => e.IdSlTypSkrzyniBiegow == id);

        public async Task CreateItemAsync(SlTypSkrzyniBiegow item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<SlTypSkrzyniBiegow?> FindItemAsync(int id)
            => await _context.SlTypySkrzyniBiegow.FindAsync(id);

        public async Task<SlTypSkrzyniBiegow?> GetItemByIdAsync(int id) 
            => await _context.SlTypySkrzyniBiegow.FirstOrDefaultAsync(m => m.IdSlTypSkrzyniBiegow == id);
        public async Task SoftDeleteItemAsync(int item)
        {
            var marka = await _context.SlTypySkrzyniBiegow.FirstAsync(i => i.IdSlTypSkrzyniBiegow == item);
            if (marka != null)
            {
                marka.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SlTypSkrzyniBiegow>> SoftGetAllItemsAsync() 
            => await _context.SlTypySkrzyniBiegow.Where(w => w.IsDeleted == false).ToListAsync();

        public async Task UpdateItemAsync(SlTypSkrzyniBiegow item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
