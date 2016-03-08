using Caliburn.Micro;
using System.Globalization;

namespace Fallout4Checklist.ViewModels.Base
{
    public abstract class FilterableSection : Screen
    {
        private bool showAll;
        public bool ShowAll
        {
            get
            {
                return showAll;
            }
            set
            {
                showAll = value;
                SetItemVisibility(value);
                NotifyOfPropertyChange(() => ShowAll);
            }
        }

        protected abstract void SetItemVisibility(bool showAll);
        public abstract void Search(string text);

        private CultureInfo _culture = new CultureInfo("en-US");
        public bool CompareString(string source, string text)
        {
            return _culture.CompareInfo.IndexOf(source, text, CompareOptions.IgnoreCase) >= 0;
        }
    }
}
