using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class Weapon
    {
        public Weapon()
        {
            Areas = new List<Area>();
            QuestStages = new List<QuestStage>();
            Merchants = new List<Character>();
            WornByCharacters = new List<Character>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string AttacksPerSecond { get; set; }
        public decimal? DamagePerShot { get; set; }
        public decimal? DamagePerSecond { get; set; }
        public decimal? FireRate { get; set; }
        public decimal? Range { get; set; }
        public decimal? CriticalChanceMultiplier { get; set; }
        public decimal? CriticalHitDamage { get; set; }
        public decimal? ActionPointCost { get; set; }
        public int? MagazineCapacity { get; set; }
        public decimal? Weight { get; set; }
        public int? Value { get; set; }
        public bool IsMenuItem { get; set; }

        #region IMenuItem
        public bool Collected { get; set; }
        #endregion

        public string AmmoID { get; set; }
        public virtual Ammo Ammo { get; set; }

        public int? ImagePathID { get; set; }
        public virtual ImagePath ImagePath { get; set; }

        public string WeaponTypeID { get; set; }
        public string WeaponSubTypeID { get; set; }
        public virtual WeaponSubType WeaponSubType { get; set; }

        public virtual List<Area> Areas { get; set; }
        public virtual ICollection<QuestStage> QuestStages { get; set; }
        public virtual List<Character> Merchants { get; set; }
        public virtual List<Character> WornByCharacters { get; set; }
    }
}
