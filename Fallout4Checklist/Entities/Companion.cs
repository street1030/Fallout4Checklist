using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class Companion
    {
        public Companion()
        {
            QuestStagesRewardedFrom = new List<QuestStage>();
            ChecklistCollectedStatus = new List<ChecklistCompanion>();
        }

        public string Name { get; set; }
        public string Perk { get; set; }
        public string PerkDescription { get; set; }
        public string PerkRequirement { get; set; }

        #region IMenuItem
        public bool Collected { get; set; }

        public int AreaID { get; set; }
        public virtual Area Area { get; set; }
        #endregion


        public int? ImagePathID { get; set; }
        public virtual ImagePath ImagePath { get; set; }

        public virtual ICollection<QuestStage> QuestStagesRewardedFrom { get; set; }
        public virtual List<ChecklistCompanion> ChecklistCollectedStatus { get; set; }
    }
}
