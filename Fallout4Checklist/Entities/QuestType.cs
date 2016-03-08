using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class QuestType
    {
        public QuestType()
        {
            Quests = new List<Quest>();
        }

        public string Type { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<Quest> Quests { get; set; }
    }
}
