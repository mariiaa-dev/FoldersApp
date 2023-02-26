using FoldersApp.Persistance.Domains.Models;
using Microsoft.Extensions.Logging;

namespace FoldersApp.Persistance.Seed.LocalStorage
{
    public class Storage
    {
        public static dynamic? GetData<T>() where T : class
        {
            Lazy<PrimarySourceFolder> primarySourceFolder = new Lazy<PrimarySourceFolder>(() => new PrimarySourceFolder()
            {
                Id = 1,
                CurrentFolderName = "Primary Sources"
            });

            Lazy<SecondarySourceFolder> secondarySourceFolder = new Lazy<SecondarySourceFolder>(() => new SecondarySourceFolder()
            {
                Id = 1,
                CurrentFolderName = "Secondary Sources"
            });

            Lazy<ProcessFolder> processFolder = new Lazy<ProcessFolder>(() => new ProcessFolder()
            {
                Id = 1,
                CurrentFolderName = "Process"
            });

            Lazy<FinalProductFolder> finalProductFolder = new Lazy<FinalProductFolder>(() => new FinalProductFolder()
            {
                Id = 1,
                CurrentFolderName = "Final Product"
            });

            Lazy<ResourceFolder> resourceFolder = new Lazy<ResourceFolder>(() => new ResourceFolder()
            {
                Id = 1,
                CurrentFolderName = "Resources",
                PrimarySourceId = primarySourceFolder.Value.Id,
                SecondarySourceId = secondarySourceFolder.Value.Id
            });

            Lazy<GraphicProductFolder> graphicProductFolder = new Lazy<GraphicProductFolder>(() => new GraphicProductFolder()
            {
                Id = 1,
                CurrentFolderName = "Graphic Products",
                ProcessFolderId = processFolder.Value.Id,
                FinalProductFolderId = finalProductFolder.Value.Id
            });

            Lazy<EvidenceFolder> evidenceFolder = new Lazy<EvidenceFolder>(() => new EvidenceFolder()
            {
                Id = 1,
                CurrentFolderName = "Evidence",
            });

            Lazy<DigitalImgFolder> digitalImgFolder = new Lazy<DigitalImgFolder>(() => new DigitalImgFolder()
            {
                Id = 1,
                CurrentFolderName = "Creating Digital Images",
                ResourceFolderId = resourceFolder.Value.Id,
                GraphicProductFolderId = graphicProductFolder.Value.Id,
                EvidenceFolderId = evidenceFolder.Value.Id
            });

            if (typeof(T).Equals(typeof(PrimarySourceFolder))) return primarySourceFolder.Value;
            if (typeof(T).Equals(typeof(SecondarySourceFolder))) return secondarySourceFolder.Value;
            if (typeof(T).Equals(typeof(ProcessFolder))) return processFolder.Value;
            if (typeof(T).Equals(typeof(FinalProductFolder))) return finalProductFolder.Value;
            if (typeof(T).Equals(typeof(ResourceFolder))) return resourceFolder.Value;
            if (typeof(T).Equals(typeof(GraphicProductFolder))) return graphicProductFolder.Value;
            if (typeof(T).Equals(typeof(EvidenceFolder))) return evidenceFolder.Value;
            if (typeof(T).Equals(typeof(DigitalImgFolder))) return digitalImgFolder.Value;
            else throw new Exception("Invalid type");
        }
    }
}
