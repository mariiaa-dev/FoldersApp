using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Repository
{
    public class EvidenceFolderRepository : IEvidenceFolderRepository
    {
        private readonly IAppDbContext _context;

        public EvidenceFolderRepository(IAppDbContext context) => _context = context;

        public DbSet<EvidenceFolder>? GetEvidenceFolder()
        {
            return _context.EvidenceFolders;
        }
    }
}
