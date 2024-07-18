namespace Projekt.Interfaces.Data.CMS.Uzytkownicy
{
    public interface IUzytkownikService<T> : ICRUDItemServices<T> where T : class
    {
        public Task<T?> FindItemAsync(int id);
        public bool AnyItem(int id);
    }
}
