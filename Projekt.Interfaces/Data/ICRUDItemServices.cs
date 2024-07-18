namespace Projekt.Interfaces.Data;

//TODO: (AK: Dodatkowe interfejsy), czy mozna dodawac dodakowe interfejsy i dziedziczyc na 
//konkretne inteface, czy to nie ma sensu? 
public interface ICRUDItemServices<T>
{
    Task<IEnumerable<T>> SoftGetAllItemsAsync();
    Task<T?> GetItemByIdAsync(int id);
    Task CreateItemAsync(T item);
    Task SoftDeleteItemAsync(int item);
    Task UpdateItemAsync(T item);
}
