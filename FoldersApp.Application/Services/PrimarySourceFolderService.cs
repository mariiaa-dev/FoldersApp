using FoldersApp.Application.DTOs;
using FoldersApp.Application.Services.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;

namespace FoldersApp.Application.Services
{
    public class PrimarySourceFolderService : IPrimarySourceFolderService
    {
        public readonly IPrimarySourceFolderRepository _repository;

        public PrimarySourceFolderService(IPrimarySourceFolderRepository repository) => _repository = repository;

        public PrimarySourceFolderDTO GetPrimarySourceFolder()
        {
            var primarySourceFolder = _repository.GetPrimarySourceFolder();

            var primarySourceFolderDTO = new PrimarySourceFolderDTO
            {
                CurrentFolderName = primarySourceFolder?.FirstOrDefault()?.CurrentFolderName
            };

            return primarySourceFolderDTO;
        }
    }
}
