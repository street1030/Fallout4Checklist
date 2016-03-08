using Fallout4Checklist.Entities;
using Fallout4Checklist.ViewModels;
using System.Collections.Generic;

namespace Fallout4Checklist.Models
{
    public class QuestStageContainer
    {
        public QuestStageContainer(List<QuestStageDetailsViewModel> stages)
        {
            Stages = stages;
        }

        public List<QuestStageDetailsViewModel> Stages { get; set; }
    }
}
