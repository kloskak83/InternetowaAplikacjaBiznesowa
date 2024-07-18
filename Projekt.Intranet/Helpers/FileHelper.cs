using Projekt.Intranet.Helpers.IHelpers;

namespace Projekt.Intranet.Helpers;

public class FileHelper : IFileHelper
{
    public async Task<string> SaveImageToWebAsync(string path, IFormFile file)
    {
        // TODO: pobierac sciezke z jsona
        string folder = $"C:/xampp/htdocs/zdjeciaProjekt/{path}/";
        string nazwaPliku = Guid.NewGuid().ToString() + "_" + file.FileName;
        string serverFolder = Path.Combine(folder, nazwaPliku);

        using (var fileStream = new FileStream(serverFolder, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
        return nazwaPliku;
    }
}
