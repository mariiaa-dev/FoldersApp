using FoldersApp.Application.DTOs;
using FoldersApp.Application.Services.Interfaces;
using FoldersApp.Persistance.Repository.Interfaces;

namespace FoldersApp.Application.Services
{
    public class FinalProductFolderService : IFinalProductFolderService
    {
        private readonly IFinalProductFolderRepository _repository;

        public FinalProductFolderService(IFinalProductFolderRepository repository) => _repository = repository;

        public FinalProductFolderDTO GetFinalProductFolder()
        {
            var finalProductFolder = _repository.GetFinalProductFolder();

            var finalProductFolderDTO = new FinalProductFolderDTO
            {
                CurrentFolderName = finalProductFolder?.FirstOrDefault()?.CurrentFolderName
            };

            return finalProductFolderDTO;
        }
    }
}