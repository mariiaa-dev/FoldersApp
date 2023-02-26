using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Repository
{
    public class DigitalImgFolderRepository : IDigitalImgFolderRepository
    {
        private readonly IAppDbContext _context;

        public DigitalImgFolderRepository(IAppDbContext context) => _context = context;

        public DbSet<DigitalImgFolder>? GetDigitalImgFolder()
        {
            return _context?.DigitalImgFolders;
        }
    }
}
