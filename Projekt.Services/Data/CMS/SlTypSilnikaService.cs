using BazaDanych.Data;
using BazaDanych.Data.CMS;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS
{
    public class SlTypSilnikaService : ABaseService, ISlTypSilnikaService<SlTypSilnika>
    {
        public SlTypSilnikaService(BazaContext context) : base(context)
        {
        }

        public bool AnyItem(int id)
            => _context.SlTypySilnikow.Any(e => e.Id == id);
        public async Task CreateItemAsync(SlTypSilnika item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task<SlTypSilnika?> FindItemAsync(int id) 
            => await _context.SlTypySilnikow.FindAsync(id);

        public async Task<SlTypSilnika?> GetItemByIdAsync(int id)
            => await _context.SlTypySilnikow.FirstOrDefaultAsync(m => m.Id == id);

        public async Task SoftDeleteItemAsync(int item)
        {
            var marka = await _context.SlTypySilnikow.FirstAsync(i => i.Id == item);
            if (marka != null)
            {
                marka.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SlTypSilnika>> SoftGetAllItemsAsync() 
            => await _context.SlTypySilnikow.Where(w => w.IsDeleted == false).ToListAsync();

        public async Task UpdateItemAsync(SlTypSilnika item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
