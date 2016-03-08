using Fallout4Checklist.Models;
using Fallout4Checklist.Repositories;
using System.Linq;

namespace Fallout4Checklist.Entities
{
    public partial class Armor : IMenuItem, IQuestReward, IAreaItem
    {
        public bool IsPurchased { get; set; }
        public bool IsWornByNPC { get; set; }
        public object EntityKey => ID;
        private int? _areaID;
        private string _location = string.Empty;

        public int? AreaID
        {
            get
            {
                if (_areaID.HasValue) return _areaID;

                if (Areas.Count > 0)
                    _areaID = Areas.First().ID;
                else if (Merchants.Count > 0)
                    _areaID = Merchants.FirstOrDefault()?.Areas.FirstOrDefault()?.ID;
                else if (QuestStages.Count > 0 && QuestStages.First().Quest.Locations.Count > 0)
                    _areaID = QuestStages.First().Quest.Locations.First().ID;
                else if (WornByCharacters.Count > 0 && WornByCharacters.First().Areas.Count > 0)
                    _areaID = WornByCharacters.First().Areas.First().ID;

                return _areaID;
            }
        }

        public bool IsChecked
        {
            get { return Collected; }
            set
            {
                Collected = value;
                Areas.ForEach(x => x.AreaPaths.ForEach(y => y.SetCollectedStatus()));
                Merchants.ForEach(x => x.Areas.ForEach(y => y.AreaPaths.ForEach(z => z.SetCollectedStatus())));
                WornByCharacters.ForEach(x => x.Areas.ForEach(y => y.AreaPaths.ForEach(z => z.SetCollectedStatus())));
            }
        }

        public string Location
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_location)) return _location;

                if (Areas.Count > 0)
                    _location = Areas.First().Name;
                else if (Merchants.Count > 0)
                    _location = (Merchants.First().Areas.FirstOrDefault() == null) ?
                        $"Sold By: {Merchants.First().Name}" :
                        $"Sold By: {Merchants.First().Name} - {Merchants.First().Areas.First().Name}";
                else if (QuestStages.Count > 0)
                    _location = $"Quest: {QuestStages.FirstOrDefault().Quest.Name}";
                else if (WornByCharacters.Count > 0)
                    _location = (WornByCharacters.First().Areas.FirstOrDefault() == null) ?
                        $"Worn By: {WornByCharacters.First().Name}" :
                        $"Worn By: {WornByCharacters.First().Name} - {WornByCharacters.First().Areas.First().Name}";

                return _location;
            }
        }
    }
}
