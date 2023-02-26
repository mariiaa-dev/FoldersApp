using Microsoft.AspNetCore.Http;

namespace FoldersApp.DbSerializator.DbSerializator.Interfaces
{
    public interface ISerializator
    {
        void ExportDbToXml(string path);
        dynamic ImportXmlToDb(IFormFile xmlFile);
    }
}
