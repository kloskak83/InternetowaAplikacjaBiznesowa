using BazaDanych.Data.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Interfaces.Data.Portal
{
    public interface IStronyNaSztywnoService
    {
        Task<StronaNaSztywno?> GetStronaAsync(int id);
    }
}
