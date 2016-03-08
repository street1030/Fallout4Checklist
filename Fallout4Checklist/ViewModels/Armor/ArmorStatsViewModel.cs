using Fallout4Checklist.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Fallout4Checklist.ViewModels
{
    public class ArmorStatsViewModel
    {
        public ArmorStatsViewModel(Armor armor)
        {
            Armor = armor;
            ArmorSlots = new ArmorSlotViewModel(armor.Slots.ToList());
            Effects = armor.Effects.Select(x => x.Effect).ToList();
        }

        public Armor Armor { get; set; }
        public List<string> Effects { get; set; }
        public ArmorSlotViewModel ArmorSlots { get; set; }
    }
}
