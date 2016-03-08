using Caliburn.Micro;

namespace Fallout4Checklist.ViewModels.Base
{
    public abstract class CollapsableSection : PropertyChangedBase
    {
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                NotifyOfPropertyChange(() => IsExpanded);
            }
        }

        public abstract bool IsVisible { get; }
        private bool _isExpanded = true;

        public void HeaderClicked()
        {
            IsExpanded = !IsExpanded;
        }
    }
}
