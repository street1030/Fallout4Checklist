using System;

namespace Fallout4Checklist.Events
{
    public class NavigationItemClicked
    {
        public NavigationItemClicked(Type controlType)
        {
            ControlType = controlType;
        }

        public Type ControlType { get; set; }
    }
}
