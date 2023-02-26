using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Repository
{
    public class PrimarySourceFolderRepository : IPrimarySourceFolderRepository
    {
        private readonly IAppDbContext _context;

        public PrimarySourceFolderRepository(IAppDbContext context) => _context = context;

        public DbSet<PrimarySourceFolder>? GetPrimarySourceFolder()
        {
            return _context.PrimarySourceFolders;
        }
    }
}
