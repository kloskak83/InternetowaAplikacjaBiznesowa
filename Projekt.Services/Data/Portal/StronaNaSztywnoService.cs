using BazaDanych.Data;
using BazaDanych.Data.Portal;
using Microsoft.EntityFrameworkCore;
using Projekt.Interfaces.Data.Portal;
using Projekt.Services.Data.Abstractions;

namespace Projekt.Services.Data.Portal
{
    public class StronaNaSztywnoService(BazaContext context) : ABaseService(context), IStronyNaSztywnoService
    {
        public async Task<StronaNaSztywno?> GetStronaAsync(int id)
            => await _context.StronyNaSztywno.FirstOrDefaultAsync(i=>i.Id==id);
    }
}
