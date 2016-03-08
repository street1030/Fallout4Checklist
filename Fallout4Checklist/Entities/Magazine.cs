using System.ComponentModel.DataAnnotations.Schema;

namespace Fallout4Checklist.Entities
{
    public partial class Magazine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MagazineTypeID { get; set; }

        [Column(TypeName = "ntext")]
        public string Walkthrough { get; set; }

        #region IMenuItem
        public bool Collected { get; set; }

        public int? AreaID { get; set; }
        public virtual Area Area { get; set; }
        #endregion

        public int? ImagePathID { get; set; }
        public virtual ImagePath ImagePath { get; set; }

        public virtual MagazineType MagazineType { get; set; }
    }
}
