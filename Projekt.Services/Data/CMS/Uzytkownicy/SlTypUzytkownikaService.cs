using BazaDanych.Data;
using BazaDanych.Data.CMS.Uzytkownicy;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS.Uzytkownicy;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS.Uzytkownicy
{
    public class SlTypUzytkownikaService(BazaContext context) : ABaseService(context), ISlTypUzytkownikaService<SlTypUzytkownika>
    {      

        public bool AnyItem(int id)
            => _context.SlTypUzytkownik.Any(e => e.Id == id);

        public async Task CreateItemAsync(SlTypUzytkownika item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task<SlTypUzytkownika?> FindItemAsync(int id)
            => await _context.SlTypUzytkownik.FindAsync(id);

        public async Task<SlTypUzytkownika?> GetItemByIdAsync(int id)
            => await _context.SlTypUzytkownik.FirstOrDefaultAsync(m => m.Id == id);

        public async Task SoftDeleteItemAsync(int item)
        {
            var marka = await _context.SlTypUzytkownik.FirstAsync(i => i.Id == item);
            if (marka != null)
            {
                marka.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SlTypUzytkownika>> SoftGetAllItemsAsync()
            => await _context.SlTypUzytkownik.Where(w => w.IsDeleted == false).ToListAsync();

        public async Task UpdateItemAsync(SlTypUzytkownika item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
