using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class BobbleheadType
    {
        public BobbleheadType()
        {
            Bobbleheads = new List<Bobblehead>();
        }

        public string ID { get; set; }

        public virtual ICollection<Bobblehead> Bobbleheads { get; set; }
    }
}
