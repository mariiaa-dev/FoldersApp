using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace FoldersApp.Persistance.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<DigitalImgFolder> DigitalImgFolders { get; set; }
        public DbSet<EvidenceFolder> EvidenceFolders { get; set; }
        public DbSet<FinalProductFolder> FinalProductFolders { get; set; }
        public DbSet<GraphicProductFolder> GraphicProductFolders { get; set; }
        public DbSet<PrimarySourceFolder> PrimarySourceFolders { get; set; }
        public DbSet<ProcessFolder> ProcessFolders { get; set; }
        public DbSet<ResourceFolder> ResourceFolders { get; set; }
        public DbSet<SecondarySourceFolder> SecondarySourceFolders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }

        void IAppDbContext.SaveChanges() => SaveChanges();
    }
}
