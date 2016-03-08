using Fallout4Checklist.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;

namespace Fallout4Checklist.Models.Menu
{
    public class MenuGroup : CollapsableSection
    {
        public MenuGroup(string header, List<MenuSubGroup> subGroups)
        {
            Header = header;
            IsExpanded = true;
            MenuSubGroups = subGroups;
            MenuSubGroups.ForEach(x => x.PropertyChanged += item_PropertyChanged);
        }

        public MenuGroup(string header, MenuSubGroup subGroup) : 
            this(header, new List<MenuSubGroup>() { subGroup }){ }

        public string Header { get; set; }
        public List<MenuSubGroup> MenuSubGroups { get; set; }
        public override bool IsVisible => MenuSubGroups.Any(x => x.IsVisible);

        private void item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var item = (MenuSubGroup)sender;
            if (e.PropertyName != PropertyInspector.GetPropertyName(() => item.IsVisible)) return;
            NotifyOfPropertyChange(() => IsVisible);
        }
    }
}
