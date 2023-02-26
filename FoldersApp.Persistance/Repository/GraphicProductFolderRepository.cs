using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Repository
{
    public class GraphicProductFolderRepository : IGraphicProductFolderRepository
    {
        private readonly IAppDbContext _context;

        public GraphicProductFolderRepository(IAppDbContext context) => _context = context;

        public DbSet<GraphicProductFolder>? GetGraphicProductFolder()
        {
            return _context.GraphicProductFolders;
        }
    }
}
