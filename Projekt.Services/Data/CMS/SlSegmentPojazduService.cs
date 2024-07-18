using BazaDanych.Data;
using BazaDanych.Data.CMS;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.CMS;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.CMS
{
    public class SlSegmentPojazduService : ABaseService, ISlSegmentPojazduService<SlSegmentPojazdu>
    {
        public SlSegmentPojazduService(BazaContext context) : base(context)
        {
        }
        public bool AnyItem(int id) 
            => _context.SlSegmentyPojazdow.Any(e => e.Id == id);
        public async Task CreateItemAsync(SlSegmentPojazdu item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task<SlSegmentPojazdu?> FindItemAsync(int id)
            => await _context.SlSegmentyPojazdow.FindAsync(id);

        public async Task<SlSegmentPojazdu?> GetItemByIdAsync(int id)
            => await _context.SlSegmentyPojazdow.FirstOrDefaultAsync(m => m.Id == id);

        public  async Task SoftDeleteItemAsync(int item)
        {
            var marka = await _context.SlSegmentyPojazdow.FirstAsync(i => i.Id == item);
            if (marka != null)
            {
                marka.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SlSegmentPojazdu>> SoftGetAllItemsAsync()
            => await _context.SlSegmentyPojazdow.Where(w => w.IsDeleted == false).ToListAsync();

        public async Task UpdateItemAsync(SlSegmentPojazdu item)
        {
            await Task.Run(()=>_context.Update(item));
            await _context.SaveChangesAsync();
        }
    }
}
