using FoldersApp.Persistance.Domains.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace FoldersApp.Persistance.Domains.Models
{
    public class ResourceFolder : Folder
    {
        [Key]
        public int Id { get; set; }

        //Relationships
        [XmlIgnore]
        public DigitalImgFolder? DigitalImgFolder { get; set; }

        public int PrimarySourceId { get; set; }
        [XmlIgnore]
        [ForeignKey("PrimarySourceId")]
        public PrimarySourceFolder? PrimarySourceFolder { get; set; }

        public int SecondarySourceId { get; set; }
        [XmlIgnore]
        [ForeignKey("SecondarySourceId")]
        public SecondarySourceFolder? SecondarySourceFolder { get; set; }
    }
}
