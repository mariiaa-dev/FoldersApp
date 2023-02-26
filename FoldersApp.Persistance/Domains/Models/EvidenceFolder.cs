using FoldersApp.Persistance.Domains.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FoldersApp.Persistance.Domains.Models
{
    public class EvidenceFolder:Folder
    {
        [Key]
        public int Id { get; set; }

        //Relationships
        [XmlIgnore]
        public DigitalImgFolder? DigitalImgFolder { get; set; }
    }
}
