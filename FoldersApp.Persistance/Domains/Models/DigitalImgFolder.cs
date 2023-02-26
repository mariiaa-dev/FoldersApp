using FoldersApp.Persistance.Domains.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace FoldersApp.Persistance.Domains.Models
{
    public class DigitalImgFolder : Folder
    {
        [Key]
        public int Id { get; set; }

        //Relationships
        public int ResourceFolderId { get; set; }
        [XmlIgnore]
        [ForeignKey("ResourceFolderId")]

        public ResourceFolder? ResourceFolder { get; set; }
        public int EvidenceFolderId { get; set; }
        [XmlIgnore]
        [ForeignKey("EvidenceFolderId")]
        public EvidenceFolder? EvidenceFolder { get; set; }

        public int GraphicProductFolderId { get; set; }
        [XmlIgnore]
        [ForeignKey("GraphicProductFolderId")]
        public GraphicProductFolder? GraphicProductFolder { get; set; }
    }
}
