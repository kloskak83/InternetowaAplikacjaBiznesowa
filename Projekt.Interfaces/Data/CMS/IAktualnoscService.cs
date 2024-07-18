namespace Projekt.Interfaces.Data.CMS;

public interface IAktualnoscService<T> : ICRUDItemServices<T> where T : class
{
    public Task<T?> FindItemAsync(int id);
    public bool AnyItem(int id);
}
