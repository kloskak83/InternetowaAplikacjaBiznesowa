namespace Projekt.Interfaces.Data.CMS
{
    public interface IPojazdService<T> : ICRUDItemServices<T>
    {
        public Task<T?> FindItemAsync(int id);
        public bool AnyItem(int id);
    }
}
