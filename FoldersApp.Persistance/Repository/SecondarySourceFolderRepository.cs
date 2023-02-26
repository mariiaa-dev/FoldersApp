using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Repository
{
    public class SecondarySourceFolderRepository : ISecondarySourceFolderRepository
    {
        private readonly IAppDbContext _context;

        public SecondarySourceFolderRepository(IAppDbContext context) => _context = context;

        public DbSet<SecondarySourceFolder>? GetSecondarySourceFolder()
        {
            return _context.SecondarySourceFolders;
        }
    }
}
