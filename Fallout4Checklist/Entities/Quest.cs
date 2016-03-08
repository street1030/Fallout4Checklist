using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class Quest
    {
        public Quest()
        {
            QuestStages = new List<QuestStage>();
            PreviousQuests = new List<Quest>();
            NextQuests = new List<Quest>();
            GivenByNPC = new List<Character>();
            Locations = new List<Area>();
        }

        public int ID { get; set; }
        public int XP { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public int DisplayOrder { get; set; }

        public int? ImagePathID { get; set; }
        public virtual ImagePath ImagePath { get; set; }

        public string QuestTypeID { get; set; }
        public virtual QuestType QuestType { get; set; }

        public virtual ICollection<QuestStage> QuestStages { get; set; }
        public virtual ICollection<Quest> PreviousQuests { get; set; }
        public virtual ICollection<Quest> NextQuests { get; set; }
        public virtual ICollection<Character> GivenByNPC { get; set; }
        public virtual ICollection<Area> Locations { get; set; }
    }
}
