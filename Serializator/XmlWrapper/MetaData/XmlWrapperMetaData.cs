using FoldersApp.Persistance.Domains.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FoldersApp.DbSerializator.XmlWrapper.MetaData
{
    [Serializable]
    [XmlRoot("XmlWrapper")]
    public class XmlWrapperMetaData
    {
        [XmlElement("DigitalImgFolder")]
        public DigitalImgFolder? DigitalImgFolder { get; set; }

        [XmlElement("EvidenceFolder")]
        public EvidenceFolder? EvidenceFolder { get; set; }

        [XmlElement("FinalProductFolder")]
        public FinalProductFolder? FinalProductFolder { get; set; }

        [XmlElement("GraphicProductFolder")]
        public GraphicProductFolder? GraphicProductFolder { get; set; }

        [XmlElement("PrimarySourceFolder")]
        public PrimarySourceFolder? PrimarySourceFolder { get; set; }

        [XmlElement("ProcessFolder")]
        public ProcessFolder? ProcessFolder { get; set; }

        [XmlElement("ResourceFolder")]
        public ResourceFolder? ResourceFolder { get; set; }

        [XmlElement("SecondarySourceFolder")]
        public SecondarySourceFolder? SecondarySourceFolder { get; set; }
    }
}
