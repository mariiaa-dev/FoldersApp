using FoldersApp.Persistance.Domains.Models.BaseModels;

namespace FoldersApp.Application.DTOs
{
    public class ResourceFolderDTO : Folder
    {
        public string? PrimarySourceName { get; set; }
        public string? SecondarySourceName { get; set; }
    }
}
