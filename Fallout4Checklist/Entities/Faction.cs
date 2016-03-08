using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class Faction
    {
        public Faction()
        {
            Areas = new List<Area>();
        }

        public string Name { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}
