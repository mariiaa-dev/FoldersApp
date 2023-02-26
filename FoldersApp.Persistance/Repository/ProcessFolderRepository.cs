using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Repository
{
    public class ProcessFolderRepository : IProcessFolderRepository
    {
        private readonly IAppDbContext _context;

        public ProcessFolderRepository(IAppDbContext context) => _context = context;

        public DbSet<ProcessFolder>? GetProcessFolder()
        {
            return _context.ProcessFolders;
        }
    }
}
