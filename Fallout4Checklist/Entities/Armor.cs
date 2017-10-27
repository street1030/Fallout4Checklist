using Fallout4Checklist.Entities.Base;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class Armor
    {
        public Armor()
        {
            Effects = new List<ArmorEffect>();
            Slots = new List<ArmorSlot>();
            Areas = new List<Area>();
            QuestStages = new List<QuestStage>();
            Merchants = new List<Character>();
            WornByCharacters = new List<Character>();
            ChecklistCollectedStatus = new List<ChecklistArmor>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int DamageResist { get; set; }
        public int EnergyResist { get; set; }
        public int RadiationResist { get; set; }
        public decimal Weight { get; set; }
        public int Value { get; set; }
        public int? Health { get; set; }
        public bool IsMenuItem { get; set; }
        public bool IsPowerArmor { get; set; }

        #region IMenuItem
        public bool Collected { get; set; }
        #endregion

        public int? ImagePathID { get; set; }
        public virtual ImagePath ImagePath { get; set; }

        public virtual ICollection<ArmorSlot> Slots { get; set; }
        public virtual ICollection<ArmorEffect> Effects { get; set; }
        public virtual ICollection<QuestStage> QuestStages { get; set; }
        public virtual List<Character> Merchants { get; set; }
        public virtual List<Character> WornByCharacters { get; set; }
        public virtual List<Area> Areas { get; set; }
        public virtual List<ChecklistArmor> ChecklistCollectedStatus { get; set; }
    }
}
