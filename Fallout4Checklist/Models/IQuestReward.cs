using Fallout4Checklist.Entities;
using System.Collections.Generic;

namespace Fallout4Checklist.Models
{
    public interface IQuestReward
    {
        ICollection<QuestStage> QuestStages { get; set; }
    }
}
