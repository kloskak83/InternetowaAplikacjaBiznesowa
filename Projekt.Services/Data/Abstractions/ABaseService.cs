using BazaDanych.Data;

namespace Projekt.Services.Data.Abstractions
{
    public abstract class ABaseService
    {
        protected readonly BazaContext _context;

        protected ABaseService(BazaContext context)
        {
            _context = context;
        }
    }
}
