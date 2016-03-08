using Caliburn.Micro;

namespace Fallout4Checklist.Models
{
    public abstract class CheckableItem : PropertyChangedBase
    {
        public bool IsVisible
        {
            get
            {
                if (IsSearching) return IsSearchResult;
                return _isShowAllChecked ? true : !IsChecked;
            }
        } 

        public bool IsSearchResult
        {
            get { return _isSearchResult; }
            set
            {
                _isSearchResult = value;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }

        public bool IsSearching
        {
            get { return _isSearching; }
            set
            {
                _isSearching = value;
                IsSearchResult = false;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }

        public abstract bool IsChecked { get; set; }
        private bool _isShowAllChecked;
        private bool _isSearchResult;
        private bool _isSearching;

        public void UpdateVisibility(bool showAllChecked)
        {
            _isShowAllChecked = showAllChecked;
            NotifyOfPropertyChange(() => IsVisible);
        }
    }
}
