using Fallout4Checklist.Models;
using Fallout4Checklist.Repositories;
using Fallout4Checklist.ViewModels.Base;
using System.Collections.Generic;
using System;

namespace Fallout4Checklist.ViewModels
{
    public class QuestViewModel : FilterableSection
    {
        public QuestViewModel()
        {
            InitializeViewModel();
        }

        public List<QuestGroup> QuestGroups { get; set; }

        protected override void SetItemVisibility(bool showAll)
        {
            foreach (var group in QuestGroups)
                foreach (var quest in group.Quests)
                        quest.UpdateVisibility(showAll);
        }

        public override void Search(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                StopSearching();
                return;
            }

            foreach (var group in QuestGroups)
                foreach (var quest in group.Quests)
                    {
                        quest.IsSearching = true;
                        if (CompareString(quest.Quest.Name, text))
                            quest.IsSearchResult = true;
                    }
        }

        private void StopSearching()
        {
            foreach (var group in QuestGroups)
                foreach (var quest in group.Quests)
                        quest.IsSearching = false;
        }

        private void InitializeViewModel()
        {
            QuestGroups = new List<QuestGroup>();

            foreach (var type in Repository.QuestTypes)
                QuestGroups.Add(new QuestGroup(type));
        }

        protected override void OnDeactivate(bool close)
        {
            Search(string.Empty);
            base.OnDeactivate(close);
        }
    }
}
