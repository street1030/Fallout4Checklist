using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class MagazineType
    {
        public MagazineType()
        {
            Magazines = new List<Magazine>();
        }

        public string ID { get; set; }

        public virtual ICollection<Magazine> Magazines { get; set; }
    }
}
