using FoldersApp.Application.DTOs;
using FoldersApp.Application.Services.Interfaces;
using FoldersApp.Persistance.Repository.Interfaces;

namespace FoldersApp.Application.Services
{
    public class ResourceFolderService : IResourceFolderService
    {
        private readonly IResourceFolderRepository _repository;

        public ResourceFolderService(IResourceFolderRepository repository) => _repository = repository;

        public ResourceFolderDTO GetResourceFolder()
        {
            var resourceFolder = _repository.GetResourceFolder();

            var resourceFolderDTO = new ResourceFolderDTO
            {
                CurrentFolderName = resourceFolder?.FirstOrDefault()?.CurrentFolderName,

                PrimarySourceName = resourceFolder?.Where(p =>
                p.PrimarySourceId == p.PrimarySourceFolder.Id)
                .Select(n => n.PrimarySourceFolder.CurrentFolderName)
                .FirstOrDefault(),

                SecondarySourceName = resourceFolder?.Where(s =>
                s.SecondarySourceId == s.SecondarySourceFolder.Id)
                .Select(n => n.SecondarySourceFolder.CurrentFolderName)
                .FirstOrDefault()
            };

            return resourceFolderDTO;
        }
    }
}
