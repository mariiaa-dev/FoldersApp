using FoldersApp.Application.DTOs;
using FoldersApp.Application.Services.Interfaces;
using FoldersApp.Persistance.Repository.Interfaces;

namespace FoldersApp.Application.Services
{
    public class SecondarySourceFolderService : ISecondarySourceFolderService
    {
        private readonly ISecondarySourceFolderRepository _repository;

        public SecondarySourceFolderService(ISecondarySourceFolderRepository repository) => _repository = repository;

        public SecondarySourceFolderDTO GetSecondarySourceFolder()
        {
            var secondarySourceFolder = _repository.GetSecondarySourceFolder();

            var secondarySourceFolderDTO = new SecondarySourceFolderDTO
            {
                CurrentFolderName = secondarySourceFolder?.FirstOrDefault()?.CurrentFolderName
            };

            return secondarySourceFolderDTO;
        }
    }
}
