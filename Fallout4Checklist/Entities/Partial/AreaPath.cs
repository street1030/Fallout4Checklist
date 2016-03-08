using Fallout4Checklist.Events;
using Caliburn.Micro;
using System.Timers;
using System.Windows.Shapes;

namespace Fallout4Checklist.Entities
{
    public partial class AreaPath : PropertyChangedBase
    {
        public AreaPath()
        {
            AnimationTimer.Elapsed += AnimationTimer_Elapsed;
        }

        public bool IsAnimating
        {
            get { return _isAnimating; }
            set
            {
                _isAnimating = value;
                NotifyOfPropertyChange(() => IsAnimating);
                if (value) AnimationTimer.Start();
            }
        }

        public CollectedStatuses CollectedStatus
        {
            get { return _collectedStatus; }
            set
            {
                _collectedStatus = value;
                NotifyOfPropertyChange(() => CollectedStatus);
            }
        }

        public Timer AnimationTimer = new Timer(10000);
        private bool _isAnimating;
        private CollectedStatuses _collectedStatus;

        public void PathClicked() => CaliburnBootstrapper.EventAggregator.PublishOnUIThreadAsync(new LocationBorderClick(AreaID));

        private void AnimationTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            AnimationTimer.Stop();
            IsAnimating = false;
        }

        public void SetCollectedStatus()
        {
            if (!Area.HasKeyCollectables.Value && !Area.HasOtherCollectables.Value)
                CollectedStatus = CollectedStatuses.NotAvailable;
            else if (Area.IsAllItemsCollected)
                CollectedStatus = CollectedStatuses.AllGear;
            else if (Area.IsKeyItemsCollected)
                CollectedStatus = CollectedStatuses.NonPurchasableOrLootableGear;
            else
                CollectedStatus = CollectedStatuses.Incomplete;
        }
    }

    public enum CollectedStatuses
    {
        NonPurchasableOrLootableGear,
        AllGear,
        NotAvailable,
        Incomplete
    }
}
