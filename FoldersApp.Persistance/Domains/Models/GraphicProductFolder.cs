using FoldersApp.Persistance.Domains.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace FoldersApp.Persistance.Domains.Models
{
    public class GraphicProductFolder : Folder
    {
        [Key]
        public int Id { get; set; }

        //Relationships
        public int ProcessFolderId { get; set; }
        [XmlIgnore]
        [ForeignKey("ProcessFolderId")]
        public ProcessFolder? ProcessFolder { get; set; }

        public int FinalProductFolderId { get; set; }
        [XmlIgnore]
        [ForeignKey("FinalProductFolderId")]
        public FinalProductFolder? FinalProductFolder { get; set; }
    }
}
