using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class Character
    {
        public Character()
        {
            AvailableQuests = new List<Quest>();
            Areas = new List<Area>();
            QuestStagesRewardedFrom = new List<QuestStage>();
            ArmorSold = new List<Armor>();
            ArmorWorn = new List<Armor>();
            WeaponsSold = new List<Weapon>();
            WeaponsWorn = new List<Weapon>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDead { get; set; }
        public bool IsSpawned { get; set; }
        public bool IsEssential { get; set; }
        public bool IsDoctor { get; set; }
        public bool IsMerchant { get; set; }
        public virtual List<Area> Areas { get; set; }
        public virtual ICollection<Quest> AvailableQuests { get; set; }
        public virtual ICollection<QuestStage> QuestStagesRewardedFrom { get; set; }
        public virtual List<Armor> ArmorSold { get; set; }
        public virtual List<Armor> ArmorWorn { get; set; }
        public virtual List<Weapon> WeaponsSold { get; set; }
        public virtual List<Weapon> WeaponsWorn { get; set; }
    }
}
