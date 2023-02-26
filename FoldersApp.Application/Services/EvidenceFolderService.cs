using FoldersApp.Application.DTOs;
using FoldersApp.Application.Services.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;

namespace FoldersApp.Application.Services
{
    public class EvidenceFolderService : IEvidenceFolderService
    {
        private readonly IEvidenceFolderRepository _repository;

        public EvidenceFolderService(IEvidenceFolderRepository repository) => _repository = repository;

        public EvidenceFolderDTO GetEvidenceFolder()
        {
            var evidenceFolder = _repository.GetEvidenceFolder();

            EvidenceFolderDTO? evidenceFolderDTO = new EvidenceFolderDTO
            {
                CurrentFolderName = evidenceFolder?.FirstOrDefault()?.CurrentFolderName
            };
            return evidenceFolderDTO;
        }
    }
}
