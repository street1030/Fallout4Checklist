using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class WeaponType
    {
        public WeaponType()
        {
            WeaponSubTypes = new List<WeaponSubType>();
        }

        public string ID { get; set; }

        public virtual ICollection<WeaponSubType> WeaponSubTypes { get; set; }
    }
}
