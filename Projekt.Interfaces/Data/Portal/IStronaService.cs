using BazaDanych.Data.Portal;
using System.Collections;

namespace Projekt.Interfaces.Data.Portal
{
    public interface IStronaService<T> : ICRUDItemServices<T> where T : class
    {
        public Task<T?> FindItemAsync(int id);
        public bool AnyItem(int id);

        Task<IEnumerable<T>> SoftGetAllItemsByIdAsync(int id);
    }
}
