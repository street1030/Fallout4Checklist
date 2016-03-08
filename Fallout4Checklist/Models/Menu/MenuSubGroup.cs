using Fallout4Checklist.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;

namespace Fallout4Checklist.Models.Menu
{
    public class MenuSubGroup : CollapsableSection
    {
        public MenuSubGroup(string header, List<MenuItem> subItems)
        {
            Header = header;
            MenuItems = subItems;
            MenuItems.ForEach(x => x.PropertyChanged += item_PropertyChanged);
            IsExpanded = true;
        }

        public string Header { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public override bool IsVisible => MenuItems.Any(x => x.IsVisible);

        private void item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var item = (MenuItem)sender;
            if (e.PropertyName != PropertyInspector.GetPropertyName(() => item.IsVisible)) return;
            NotifyOfPropertyChange(() => IsVisible);
        }
    }
}
