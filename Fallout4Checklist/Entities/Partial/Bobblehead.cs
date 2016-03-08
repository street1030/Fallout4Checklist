using Fallout4Checklist.Models;
using Fallout4Checklist.Repositories;
using System;

namespace Fallout4Checklist.Entities
{
    public partial class Bobblehead : IMenuItem, IAreaItem
    {
        private string _walkthroughWithLineBreaks;
        public string WalkthroughWithLineBreaks
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_walkthroughWithLineBreaks))
                    return _walkthroughWithLineBreaks;

                _walkthroughWithLineBreaks = Walkthrough.Replace(@"\n", Environment.NewLine.ToString());
                return _walkthroughWithLineBreaks;
            }
        }

        public string Location => (Area == null) ? string.Empty : Area.Name;
        public object EntityKey => ID;
        public string Name => ID;

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
