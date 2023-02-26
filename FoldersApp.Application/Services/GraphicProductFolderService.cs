using FoldersApp.Application.DTOs;
using FoldersApp.Application.Services.Interfaces;
using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Repository.Interfaces;

namespace FoldersApp.Application.Services
{
    public class GraphicProductFolderService : IGraphicProductFolderService
    {
        private readonly IGraphicProductFolderRepository _repository;

        public GraphicProductFolderService(IGraphicProductFolderRepository repository) => _repository = repository;

        public GraphicProductFolderDTO GetGraphicProductFolder()
        {
            var graphicProductFolder = _repository.GetGraphicProductFolder();

            var graphicProductFolderDTO = new GraphicProductFolderDTO
            {
                CurrentFolderName = graphicProductFolder?.FirstOrDefault()?.CurrentFolderName,

                ProcessFolderName = graphicProductFolder?.Where(p =>
                p.ProcessFolderId == p.ProcessFolder.Id)
                .Select(n => n.ProcessFolder.CurrentFolderName)
                .FirstOrDefault(),

                FinalProductFolderName = graphicProductFolder?.Where(f =>
                f.FinalProductFolderId == f.FinalProductFolder.Id)
                .Select(n => n.FinalProductFolder.CurrentFolderName)
                .FirstOrDefault()
            };

            return graphicProductFolderDTO;
        }
    }
}
