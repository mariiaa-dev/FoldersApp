using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Repository
{
    public class ResourceFolderRepository : IResourceFolderRepository
    {
        private readonly IAppDbContext _context;

        public ResourceFolderRepository(IAppDbContext context) => _context = context;

        public DbSet<ResourceFolder>? GetResourceFolder()
        {
            return _context.ResourceFolders;
        }
    }
}
