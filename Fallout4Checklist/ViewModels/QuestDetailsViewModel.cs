using Caliburn.Micro;
using Fallout4Checklist.Events;
using Fallout4Checklist.Entities;
using Fallout4Checklist.Repositories;
using Fallout4Checklist.Models;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Fallout4Checklist.ViewModels
{
    public class QuestDetailsViewModel : Screen, IHandle<QuestClicked>
    {
        public QuestDetailsViewModel()
        {
            CaliburnBootstrapper.EventAggregator.Subscribe(this);
            Stages = new ObservableCollection<QuestStageContainer>();
            WeaponRewards = new ObservableCollection<WeaponStatsViewModel>();
        }

        public ObservableCollection<QuestStageContainer> Stages { get; set; }

        public Quest CurrentQuest
        {
            get { return _currentQuest; }
            set
            {
                _currentQuest = value;
                NotifyOfPropertyChange(() => CurrentQuest);
                BuildStagesForNewQuest();
            }
        }

        public bool IsChecked
        {
            get { return CurrentQuest.IsChecked; }
            set
            {
                CurrentQuest.IsChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
            }
        }

        public ObservableCollection<WeaponStatsViewModel> WeaponRewards { get; set; }
        private Quest _currentQuest { get; set; }

        public void Handle(QuestClicked message)
        {
            var quest = QuestRepository.GetQuestByID(message.QuestID);
            if (quest == null) return;

            CurrentQuest = quest;
        }

        public void BuildStageList(QuestStageDetailsViewModel stage)
        {
            if (stage == null) return;

            var item = Stages.FirstOrDefault(x => x.Stages.Contains(stage));
            var index = Stages.IndexOf(item) + 1;
            var endIndex = Stages.Count - 1;

            for (int i = index; i <= endIndex; i++)
                Stages.RemoveAt(index);

            BuildStages(stage);
        }

        public void SelectedStageChanged(SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;

            var stage = (QuestStageDetailsViewModel)e.AddedItems[0];
            BuildStageList(stage);
        }

        private void BuildStagesForNewQuest()
        {
            Stages.Clear();
            var first = CurrentQuest.FirstStage;
            if (first == null) return;

            var firstStage = new List<QuestStageDetailsViewModel>();
            var viewModel = new QuestStageDetailsViewModel(first);
            firstStage.Add(viewModel);

            Stages.Add(new QuestStageContainer(firstStage));
            BuildStages(viewModel);
        }

        private void BuildStages(QuestStageDetailsViewModel stage)
        {
            var stages = stage.NextStages;
            if (stages == null || stages.Count == 0) return;

            var container = new QuestStageContainer(stages);
            Stages.Add(container);

            var first = stages.First();
            BuildStages(first);
        }
    }
}
