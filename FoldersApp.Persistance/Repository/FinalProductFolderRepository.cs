using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Repository
{
    public class FinalProductFolderRepository : IFinalProductFolderRepository
    {
        private readonly IAppDbContext _context;

        public FinalProductFolderRepository(IAppDbContext context) => _context = context;

        public DbSet<FinalProductFolder>? GetFinalProductFolder()
        {
            return _context.FinalProductFolders;
        }
    }
}
