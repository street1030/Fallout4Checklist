using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class ArmorSlot
    {
        public ArmorSlot()
        {
            Armor = new List<Armor>();
        }

        public string ID { get; set; }

        public virtual ICollection<Armor> Armor { get; set; }
    }
}
