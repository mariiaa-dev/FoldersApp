using FoldersApp.Persistance.Domains.Models.BaseModels;

namespace FoldersApp.Application.DTOs
{
    public class DigitalImgFolderDTO : Folder
    {
        public string? ResourceFolderName { get; set; }
        public string? EvidenceFolderName { get; set; }
        public string? GraphicProductFolderName { get; set; }
    }
}
