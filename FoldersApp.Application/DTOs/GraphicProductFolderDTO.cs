using FoldersApp.Persistance.Domains.Models.BaseModels;

namespace FoldersApp.Application.DTOs
{
    public class GraphicProductFolderDTO : Folder
    {
        public string? ProcessFolderName { get; set; }
        public string? FinalProductFolderName { get; set; }
    }
}
