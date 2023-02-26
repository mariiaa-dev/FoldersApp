using FoldersApp.Persistance.Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Context.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<DigitalImgFolder> DigitalImgFolders { get; set; }
        public DbSet<EvidenceFolder> EvidenceFolders { get; set; }
        public DbSet<FinalProductFolder> FinalProductFolders { get; set; }
        public DbSet<GraphicProductFolder> GraphicProductFolders { get; set; }
        public DbSet<PrimarySourceFolder> PrimarySourceFolders { get; set; }
        public DbSet<ProcessFolder> ProcessFolders { get; set; }
        public DbSet<ResourceFolder> ResourceFolders { get; set; }
        public DbSet<SecondarySourceFolder> SecondarySourceFolders { get; set; }

        void SaveChanges();
    }
}
