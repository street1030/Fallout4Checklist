using Fallout4Checklist.Models;
using Fallout4Checklist.Repositories;
using System;

namespace Fallout4Checklist.Entities
{
    public partial class Companion : IMenuItem, IAreaItem
    {
        public string FullImagePath => string.Format(pathFormat, Environment.CurrentDirectory, ImagePath);
        public object EntityKey => Name;
        public string Location => Area.Name;
        int? IMenuItem.AreaID => AreaID;
        int? IAreaItem.AreaID => AreaID;
        private string pathFormat = "{0}\\Images\\Companions\\{1}";

        public bool IsChecked
        {
            get { return Collected; }
            set
            {
                Collected = value;
                Area?.AreaPaths.ForEach(x => x.SetCollectedStatus());
            }
        }
    }
}
