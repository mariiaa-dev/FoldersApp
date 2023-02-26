using FoldersApp.Application.DTOs;
using FoldersApp.Application.Services.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;
using System.Linq;

namespace FoldersApp.Application.Services
{
    public class DigitalImgFolderService : IDigitalImgFolderService
    {
        private readonly IDigitalImgFolderRepository _repository;

        public DigitalImgFolderService(IDigitalImgFolderRepository repository) => _repository = repository;

        public DigitalImgFolderDTO GetDigitalImgFolder()
        {
            var digitalImgFolder = _repository.GetDigitalImgFolder();

            var digitalImgFolderDTO = new DigitalImgFolderDTO
            {
                CurrentFolderName = digitalImgFolder?.FirstOrDefault()?.CurrentFolderName,

                ResourceFolderName = digitalImgFolder?.Where(r => 
                r.ResourceFolderId == r.ResourceFolder.Id)
                .Select(n => n.ResourceFolder.CurrentFolderName)
                .FirstOrDefault(),

                GraphicProductFolderName = digitalImgFolder?.Where(g => 
                g.GraphicProductFolderId == g.GraphicProductFolder.Id)
                .Select(n => n.GraphicProductFolder.CurrentFolderName)
                .FirstOrDefault(),

                EvidenceFolderName = digitalImgFolder?.Where(e => 
                e.EvidenceFolderId == e.EvidenceFolder.Id)
                .Select(n => n.EvidenceFolder.CurrentFolderName)
                .FirstOrDefault()
            };
            return digitalImgFolderDTO;
        }
    }
}
