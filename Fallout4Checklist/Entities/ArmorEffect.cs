using Fallout4Checklist.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fallout4Checklist.Entities
{
    public partial class ArmorEffect
    {
        public int ID { get; set; }
        public string Effect { get; set; }

        public int ArmorID { get; set; }
        public virtual Armor Armor { get; set; }
    }
}
