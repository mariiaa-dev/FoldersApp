using System.Xml.Serialization;
using System.Xml;
using FoldersApp.DbSerializator.DbSerializator.Interfaces;
using FoldersApp.Persistance.Domains.Models;
using FoldersApp.Persistance.Context.Interfaces;
using FoldersApp.Persistance.Seed.LocalStorage;
using FoldersApp.DbSerializator.XmlWrapper.MetaData;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace FoldersApp.Dberializator.DbSerializator
{
    public class Serializator : ISerializator
    {
        private readonly IAppDbContext _context;

        public Serializator(IAppDbContext context) => _context = context;

        public dynamic ImportXmlToDb(IFormFile xmlFile)
        {
            return SaveToDb(xmlFile);
        }

        public void ExportDbToXml(string path)
        {
            var wrapper = GetData();

            SerializeToXml(path, wrapper);
        }

        private dynamic SaveToDb(IFormFile xmlFile)
        {
            List<DigitalImgFolder> imgFolders = GetParseDataFromXml<DigitalImgFolder>(xmlFile);
            foreach (var imgFolder in imgFolders)
            {
                var filter = _context.DigitalImgFolders.Where(d => d.Id.Equals(imgFolder.Id)).FirstOrDefault();

                if (filter != null)
                {
                    filter.Id = imgFolder.Id;
                    filter.CurrentFolderName = imgFolder.CurrentFolderName;
                    filter.ResourceFolderId = imgFolder.ResourceFolderId;
                    filter.EvidenceFolderId = imgFolder.EvidenceFolderId;
                    filter.GraphicProductFolderId = imgFolder.GraphicProductFolderId;
                }
                else _context.DigitalImgFolders.Add(imgFolder);
            }
            _context.SaveChanges();

            List<EvidenceFolder> evidenceFolders = GetParseDataFromXml<EvidenceFolder>(xmlFile);
            foreach (var evidenceFolder in evidenceFolders)
            {
                var filter = _context.EvidenceFolders.Where(d => d.Id.Equals(evidenceFolder.Id)).FirstOrDefault();

                if (filter != null)
                {
                    filter.Id = evidenceFolder.Id;
                    filter.CurrentFolderName = evidenceFolder.CurrentFolderName;
                }
                else _context.EvidenceFolders.Add(evidenceFolder);
            }
            _context.SaveChanges();

            List<FinalProductFolder> finalProductFolders = GetParseDataFromXml<FinalProductFolder>(xmlFile);
            foreach (var finalProductFolder in finalProductFolders)
            {
                var filter = _context.FinalProductFolders.Where(d => d.Id.Equals(finalProductFolder.Id)).FirstOrDefault();

                if (filter != null)
                {
                    filter.Id = finalProductFolder.Id;
                    filter.CurrentFolderName = finalProductFolder.CurrentFolderName;
                }
                else _context.FinalProductFolders.Add(finalProductFolder);
            }
            _context.SaveChanges();

            List<GraphicProductFolder> graphicFolders = GetParseDataFromXml<GraphicProductFolder>(xmlFile);
            foreach (var graphicFolder in graphicFolders)
            {
                var filter = _context.GraphicProductFolders.Where(d => d.Id.Equals(graphicFolder.Id)).FirstOrDefault();

                if (filter != null)
                {
                    filter.Id = graphicFolder.Id;
                    filter.CurrentFolderName = graphicFolder.CurrentFolderName;
                    filter.ProcessFolderId = graphicFolder.ProcessFolderId;
                    filter.FinalProductFolderId = graphicFolder.FinalProductFolderId;
                }
                else _context.GraphicProductFolders.Add(graphicFolder);
            }
            _context.SaveChanges();

            List<PrimarySourceFolder> primaryFolders = GetParseDataFromXml<PrimarySourceFolder>(xmlFile);
            foreach (var primaryFolder in primaryFolders)
            {
                var filter = _context.PrimarySourceFolders.Where(d => d.Id.Equals(primaryFolder.Id)).FirstOrDefault();

                if (filter != null)
                {
                    filter.Id = primaryFolder.Id;
                    filter.CurrentFolderName = primaryFolder.CurrentFolderName;
                }
                else _context.PrimarySourceFolders.Add(primaryFolder);
            }
            _context.SaveChanges();

            List<ProcessFolder> processFolders = GetParseDataFromXml<ProcessFolder>(xmlFile);
            foreach (var processFolder in processFolders)
            {
                var filter = _context.ProcessFolders.Where(d => d.Id.Equals(processFolder.Id)).FirstOrDefault();

                if (filter != null)
                {
                    filter.Id = processFolder.Id;
                    filter.CurrentFolderName = processFolder.CurrentFolderName;
                }
                else _context.ProcessFolders.Add(processFolder);
            }
            _context.SaveChanges();

            List<ResourceFolder> resourceFolders = GetParseDataFromXml<ResourceFolder>(xmlFile);
            foreach (var resourceFolder in resourceFolders)
            {
                var filter = _context.ResourceFolders.Where(d => d.Id.Equals(resourceFolder.Id)).FirstOrDefault();

                if (filter != null)
                {
                    filter.Id = resourceFolder.Id;
                    filter.CurrentFolderName = resourceFolder.CurrentFolderName;
                    filter.PrimarySourceId = resourceFolder.PrimarySourceId;
                    filter.SecondarySourceId = resourceFolder.SecondarySourceId;
                }
                else _context.ResourceFolders.Add(resourceFolder);
            }
            _context.SaveChanges();

            List<SecondarySourceFolder> secondaryFolders = GetParseDataFromXml<SecondarySourceFolder>(xmlFile);
            foreach (var secondaryFolder in secondaryFolders)
            {
                var filter = _context.SecondarySourceFolders.Where(d => d.Id.Equals(secondaryFolder.Id)).FirstOrDefault();

                if (filter != null)
                {
                    filter.Id = secondaryFolder.Id;
                    filter.CurrentFolderName = secondaryFolder.CurrentFolderName;
                }
                else _context.SecondarySourceFolders.Add(secondaryFolder);
            }
            _context.SaveChanges();

            return new List<object>
            {
                imgFolders?.FirstOrDefault(),
                evidenceFolders?.FirstOrDefault(),
                finalProductFolders?.FirstOrDefault(),
                graphicFolders?.FirstOrDefault(),
                primaryFolders?.FirstOrDefault(),
                processFolders?.FirstOrDefault(),
                secondaryFolders?.FirstOrDefault(),
                resourceFolders?.FirstOrDefault()
            };
        }

        private void SerializeToXml(string path, XmlWrapperMetaData wrapper)
        {
            using (XmlWriter writer = XmlWriter.Create(path))
            {
                XmlSerializer serializer = new XmlSerializer(wrapper.GetType(), new Type[]
                {
                    typeof(DigitalImgFolder),
                    typeof(EvidenceFolder),
                    typeof(FinalProductFolder),
                    typeof(GraphicProductFolder),
                    typeof(PrimarySourceFolder),
                    typeof(ProcessFolder),
                    typeof(ResourceFolder),
                    typeof(SecondarySourceFolder),
                });

                serializer.Serialize(writer, wrapper);
            }
        }

        private XmlWrapperMetaData GetData()
        {
            return new XmlWrapperMetaData
            {
                DigitalImgFolder = _context.DigitalImgFolders.FirstOrDefault(),
                EvidenceFolder = _context.EvidenceFolders.FirstOrDefault(),
                FinalProductFolder = _context.FinalProductFolders.FirstOrDefault(),
                GraphicProductFolder = _context.GraphicProductFolders.FirstOrDefault(),
                PrimarySourceFolder = _context.PrimarySourceFolders.FirstOrDefault(),
                ProcessFolder = _context.ProcessFolders.FirstOrDefault(),
                ResourceFolder = _context.ResourceFolders.FirstOrDefault(),
                SecondarySourceFolder = _context.SecondarySourceFolders.FirstOrDefault()
            };
        }

        private XmlWrapperMetaData SetDefaultData()
        {
            return new XmlWrapperMetaData
            {
                DigitalImgFolder = Storage.GetData<DigitalImgFolder>(),
                EvidenceFolder = Storage.GetData<EvidenceFolder>(),
                FinalProductFolder = Storage.GetData<FinalProductFolder>(),
                GraphicProductFolder = Storage.GetData<GraphicProductFolder>(),
                PrimarySourceFolder = Storage.GetData<PrimarySourceFolder>(),
                ProcessFolder = Storage.GetData<ProcessFolder>(),
                ResourceFolder = Storage.GetData<ResourceFolder>(),
                SecondarySourceFolder = Storage.GetData<SecondarySourceFolder>()
            };
        }

        private dynamic GetParseDataFromXml<T>(IFormFile xmlFile)
        {
            if (CheckFileForValid(xmlFile))
            {
                var xmlPath = Path.Combine(Directory.GetCurrentDirectory() + "//" + xmlFile.FileName);
                XDocument xDoc = XDocument.Load(xmlPath);

                if (typeof(T).Equals(typeof(DigitalImgFolder)))
                {
                    return xDoc.Descendants("DigitalImgFolder").Select(imgFolder =>
                    new DigitalImgFolder
                    {
                        Id = Convert.ToInt32(imgFolder?.Element("Id")?.Value),
                        CurrentFolderName = imgFolder?.Element("CurrentFolderName")?.Value,
                        EvidenceFolderId = Convert.ToInt32(imgFolder?.Element("EvidenceFolderId")?.Value),
                        ResourceFolderId = Convert.ToInt32(imgFolder?.Element("ResourceFolderId")?.Value),
                        GraphicProductFolderId = Convert.ToInt32(imgFolder?.Element("GraphicProductFolderId")?.Value)
                    }).ToList();
                }
                if (typeof(T).Equals(typeof(EvidenceFolder)))
                {
                    return xDoc.Descendants("EvidenceFolder").Select(imgFolder =>
                   new EvidenceFolder
                   {
                       Id = Convert.ToInt32(imgFolder?.Element("Id")?.Value),
                       CurrentFolderName = imgFolder?.Element("CurrentFolderName")?.Value,
                   }).ToList();
                }
                if (typeof(T).Equals(typeof(FinalProductFolder)))
                {
                    return xDoc.Descendants("FinalProductFolder").Select(imgFolder =>
                   new FinalProductFolder
                   {
                       Id = Convert.ToInt32(imgFolder?.Element("Id")?.Value),
                       CurrentFolderName = imgFolder?.Element("CurrentFolderName")?.Value,
                   }).ToList();
                }
                if (typeof(T).Equals(typeof(GraphicProductFolder)))
                {
                    return xDoc.Descendants("GraphicProductFolder").Select(imgFolder =>
                   new GraphicProductFolder
                   {
                       Id = Convert.ToInt32(imgFolder?.Element("Id")?.Value),
                       CurrentFolderName = imgFolder?.Element("CurrentFolderName")?.Value,
                       ProcessFolderId = Convert.ToInt32(imgFolder?.Element("ProcessFolderId")?.Value),
                       FinalProductFolderId = Convert.ToInt32(imgFolder?.Element("FinalProductFolderId")?.Value),
                   }).ToList();
                }
                if (typeof(T).Equals(typeof(PrimarySourceFolder)))
                {
                    return xDoc.Descendants("PrimarySourceFolder").Select(imgFolder =>
                   new PrimarySourceFolder
                   {
                       Id = Convert.ToInt32(imgFolder?.Element("Id")?.Value),
                       CurrentFolderName = imgFolder?.Element("CurrentFolderName")?.Value,
                   }).ToList();
                }
                if (typeof(T).Equals(typeof(ProcessFolder)))
                {
                    return xDoc.Descendants("ProcessFolder").Select(imgFolder =>
                   new ProcessFolder
                   {
                       Id = Convert.ToInt32(imgFolder?.Element("Id")?.Value),
                       CurrentFolderName = imgFolder?.Element("CurrentFolderName")?.Value,
                   }).ToList();
                }
                if (typeof(T).Equals(typeof(ResourceFolder)))
                {
                    return xDoc.Descendants("ResourceFolder").Select(imgFolder =>
                   new ResourceFolder
                   {
                       Id = Convert.ToInt32(imgFolder?.Element("Id")?.Value),
                       CurrentFolderName = imgFolder?.Element("CurrentFolderName")?.Value,
                       PrimarySourceId = Convert.ToInt32(imgFolder?.Element("PrimarySourceId")?.Value),
                       SecondarySourceId = Convert.ToInt32(imgFolder?.Element("SecondarySourceId")?.Value),
                   }).ToList();
                }
                if (typeof(T).Equals(typeof(SecondarySourceFolder)))
                {
                    return xDoc.Descendants("SecondarySourceFolder").Select(imgFolder =>
                   new SecondarySourceFolder
                   {
                       Id = Convert.ToInt32(imgFolder?.Element("Id")?.Value),
                       CurrentFolderName = imgFolder?.Element("CurrentFolderName")?.Value,
                   }).ToList();
                }
            }


            return new XmlWrapperMetaData
            {
                DigitalImgFolder = Storage.GetData<DigitalImgFolder>(),
                EvidenceFolder = Storage.GetData<EvidenceFolder>(),
                FinalProductFolder = Storage.GetData<FinalProductFolder>(),
                GraphicProductFolder = Storage.GetData<GraphicProductFolder>(),
                PrimarySourceFolder = Storage.GetData<PrimarySourceFolder>(),
                ProcessFolder = Storage.GetData<ProcessFolder>(),
                ResourceFolder = Storage.GetData<ResourceFolder>(),
                SecondarySourceFolder = Storage.GetData<SecondarySourceFolder>()
            };
        }

        private bool CheckFileForValid(IFormFile xmlFile)
        {
            if (xmlFile.ContentType.Equals("application/xml") || xmlFile.ContentType.Equals("text/xml"))
                return true;
            return false;
        }
    }
}
