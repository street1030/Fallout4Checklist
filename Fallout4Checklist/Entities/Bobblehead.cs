using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fallout4Checklist.Entities
{
    public partial class Bobblehead
    {
        public Bobblehead()
        {
            ChecklistCollectedStatus = new List<ChecklistBobblehead>();
        }

        public string ID { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Walkthrough { get; set; }

        #region IMenuItem
        public bool Collected { get; set; }

        public int? AreaID { get; set; }
        public virtual Area Area { get; set; }
        #endregion

        public string BobbleheadTypeID { get; set; }
        public virtual BobbleheadType BobbleheadType { get; set; }

        public int ImagePathID { get; set; }
        public virtual ImagePath ImagePath { get; set; }

        public virtual List<ChecklistBobblehead> ChecklistCollectedStatus { get; set; }
    }
}
