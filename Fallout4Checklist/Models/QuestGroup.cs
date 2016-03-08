using Fallout4Checklist.Entities;
using Fallout4Checklist.ViewModels;
using Fallout4Checklist.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;

namespace Fallout4Checklist.Models
{
    public class QuestGroup : CollapsableSection
    {
        public QuestGroup(QuestType questType)
        {
            QuestType = questType;
            InitializeViewModel(questType);
        }

        public List<QuestListItemViewModel> Quests { get; set; }
        public QuestType QuestType { get; set; }
        public string Header { get; set; }
        public string QuestCompletion => $"{QuestType.Quests.Where(x => x.IsChecked).Count()} / {QuestType.Quests.Count}";
        public override bool IsVisible => Quests.Any(x => x.IsVisible);
        private int TotalQuests;
        private int CompletedQuests;

        private void InitializeViewModel(QuestType questType)
        {
            Quests = new List<QuestListItemViewModel>();
            Header = questType.Type;

            foreach (var item in questType.Quests)
            {
                var questListItem = new QuestListItemViewModel(item);
                questListItem.PropertyChanged += QuestListItem_PropertyChanged;
                Quests.Add(questListItem);
            }

            TotalQuests = questType.Quests.Count;
            CompletedQuests = questType.Quests.Where(x => x.Completed).Count();
            IsExpanded = false;
        }

        private void QuestListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            QuestListItemViewModel quest = (QuestListItemViewModel)sender;
            if (e.PropertyName != PropertyInspector.GetPropertyName(() => quest.IsVisible)) return;

            NotifyOfPropertyChange(() => QuestCompletion);
            NotifyOfPropertyChange(() => IsVisible);
        }
    }
}
