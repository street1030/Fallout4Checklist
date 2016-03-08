using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class WeaponSubType
    {
        public WeaponSubType()
        {
            Weapons = new List<Weapon>();
        }

        public string ID { get; set; }

        public string WeaponTypeID { get; set; }
        public virtual WeaponType WeaponType { get; set; }

        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
