using Caliburn.Micro;

namespace Fallout4Checklist.ViewModels.Base
{
    public abstract class CollectableItemViewModel : PropertyChangedBase
    {
        public abstract string Walkthrough { get; }
        public abstract bool IsChecked { get; set; }
        public abstract bool IsPurchased { get; }
        public abstract bool IsWornByNPC { get; }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                NotifyOfPropertyChange(() => IsExpanded);
            }
        }

        private bool _isExpanded = true;

        public void HeaderClicked() => IsExpanded = !IsExpanded;
    }
}
