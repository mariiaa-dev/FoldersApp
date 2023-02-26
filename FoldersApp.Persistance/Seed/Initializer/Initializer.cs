using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Seed.LocalStorage;

namespace FoldersApp.Persistance.Seed.Initializer
{
    public class Initializer
    {
        private readonly IAppDbContext _context;

        public Initializer(IAppDbContext context) => _context = context;

        public void Initialize()
        {
            if (!_context.PrimarySourceFolders.Any())
            {
                _context.PrimarySourceFolders.Add(Storage.GetData<PrimarySourceFolder>());
                _context.SaveChanges();
            }
            if (!_context.SecondarySourceFolders.Any())
            {
                _context.SecondarySourceFolders.Add(Storage.GetData<SecondarySourceFolder>());
                _context.SaveChanges();
            }
            if (!_context.ProcessFolders.Any())
            {
                _context.ProcessFolders.Add(Storage.GetData<ProcessFolder>());
                _context.SaveChanges();
            }
            if (!_context.FinalProductFolders.Any())
            {
                _context.FinalProductFolders.Add(Storage.GetData<FinalProductFolder>());
                _context.SaveChanges();
            }
            if (!_context.ResourceFolders.Any())
            {
                _context.ResourceFolders.Add(Storage.GetData<ResourceFolder>());
                _context.SaveChanges();
            }
            if (!_context.EvidenceFolders.Any())
            {
                _context.EvidenceFolders.Add(Storage.GetData<EvidenceFolder>());
                _context.SaveChanges();
            }
            if (!_context.GraphicProductFolders.Any())
            {
                _context.GraphicProductFolders.Add(Storage.GetData<GraphicProductFolder>());
                _context.SaveChanges();
            }
            if (!_context.DigitalImgFolders.Any())
            {
                _context.DigitalImgFolders.Add(Storage.GetData<DigitalImgFolder>());
                _context.SaveChanges();
            }
        }
    }
}
