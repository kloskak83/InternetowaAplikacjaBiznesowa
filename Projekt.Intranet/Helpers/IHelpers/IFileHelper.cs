namespace Projekt.Intranet.Helpers.IHelpers;

public interface IFileHelper
{
    /// <summary>
    /// Metoda przyjmuje folder gdzie zapisac plik i zwraca nazwe pliku
    /// </summary>
    /// <param name="path"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    public Task<string> SaveImageToWebAsync(string path, IFormFile file);    
}
