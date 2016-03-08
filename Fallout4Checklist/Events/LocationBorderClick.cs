using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fallout4Checklist.Events
{
    public class LocationBorderClick
    {
        public LocationBorderClick(int areaID)
        {
            AreaID = areaID;
        }

        public int AreaID { get; set; }
    }
}
