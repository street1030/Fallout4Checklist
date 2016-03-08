using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class QuestStage
    {
        public QuestStage()
        {
            PreviousQuestStages = new List<QuestStageChain>();
            NextQuestStages = new List<QuestStageChain>();
            Weapons = new List<Weapon>();
            Armor = new List<Armor>();
            Settlements = new List<Area>();
            NPCs = new List<Character>();
            Companions = new List<Companion>();
            OtherRewards = new List<QuestStageReward>();
        }

        public int Stage { get; set; }
        public string Description { get; set; }

        public int QuestID { get; set; }
        public virtual Quest Quest { get; set; }

        public virtual ICollection<QuestStageChain> PreviousQuestStages { get; set; }
        public virtual ICollection<QuestStageChain> NextQuestStages { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
        public virtual ICollection<Armor> Armor { get; set; }
        public virtual ICollection<Area> Settlements { get; set; }
        public virtual ICollection<Character> NPCs { get; set; }
        public virtual ICollection<Companion> Companions { get; set; }
        public virtual ICollection<QuestStageReward> OtherRewards { get; set; }
    }
}
