using Fallout4Checklist.Repositories;
using System.Collections.Generic;
using Fallout4Checklist.Models.Menu;
using Fallout4Checklist.ViewModels.Base;

namespace Fallout4Checklist.ViewModels
{
    public class MenuViewModel : FilterableSection
    {
        public MenuViewModel()
        {
            DisplayName = "Items";
            SetMenuGroups();
        }

        public List<MenuGroup> MenuGroups { get; set; }

        protected override void SetItemVisibility(bool showAll)
        {
            foreach (var item in MenuGroups)
                foreach (var group in item.MenuSubGroups)
                    foreach (var subItem in group.MenuItems)
                        subItem.UpdateVisibility(showAll);
        }

        public override void Search(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                StopSearching();
                return;
            }

            foreach (var group in MenuGroups)
                foreach (var subGroup in group.MenuSubGroups)
                    foreach (var item in subGroup.MenuItems)
                    {
                        item.IsSearching = true;
                        if (CompareString(item.Entity.Location, text))
                            item.IsSearchResult = true;
                        else if (CompareString(item.Entity.Name, text))
                            item.IsSearchResult = true;
                    }
        }

        private void StopSearching()
        {
            foreach (var group in MenuGroups)
                foreach (var subGroup in group.MenuSubGroups)
                    foreach (var item in subGroup.MenuItems)
                        item.IsSearching = false;
        }

        private void SetMenuGroups() => MenuGroups = Repository.MenuItems;

        protected override void OnDeactivate(bool close)
        {
            Search(string.Empty);
            base.OnDeactivate(close);
        }
    }
}
