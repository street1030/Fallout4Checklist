using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class Ammo
    {
        public Ammo()
        {
            Weapons = new List<Weapon>();
        }

        public string ID { get; set; }

        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
