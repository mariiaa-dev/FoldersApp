using FoldersApp.Application.DTOs;
using FoldersApp.Application.Services.Interfaces;
using FoldersApp.Persistance.Repository.Interfaces;

namespace FoldersApp.Application.Services
{
    public class ProcessFolderService : IProcessFolderService
    {
        private readonly IProcessFolderRepository _repository;

        public ProcessFolderService(IProcessFolderRepository repository) => _repository = repository;

        public ProcessFolderDTO GetProcessFolder()
        {
            var processFolder = _repository.GetProcessFolder();

            var processFolderDTO = new ProcessFolderDTO
            {
                CurrentFolderName = processFolder?.FirstOrDefault()?.CurrentFolderName
            };

            return processFolderDTO;
        }
    }
}
