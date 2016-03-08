using Fallout4Checklist.Models;
using Fallout4Checklist.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Fallout4Checklist.Entities
{
    public partial class Weapon : IMenuItem, IQuestReward, IAreaItem
    {
        public bool IsPurchased { get; set; }
        public bool IsWornByNPC { get; set; }
        public object EntityKey => ID;
        private List<Quest> _quests;

        public string Location
        {
            get
            {
                if (Areas.Count > 0) return Areas.First().Name;
                if (Merchants.Count > 0) return GetMerchantLocation();
                if (WornByCharacters.Count > 0) return GetWornByCharacterLocation();
                if (QuestStages.Count > 0) return $"Quest: {QuestStages.First().Quest.Name}";
                return string.Empty;
            }
        }

        public int? AreaID
        {
            get
            {
                if (Areas.Count > 0) return Areas.First().ID;
                if (QuestStages.Count > 0) return QuestStages.First().Quest.Locations.First()?.ID;
                if (Merchants.Count > 0) return Merchants.First().Areas.First()?.ID;
                if (WornByCharacters.Count > 0) return WornByCharacters.First().Areas.First()?.ID;
                return null;
            }
        }

        public List<Quest> Quests
        {
            get
            {
                if (_quests != null) return _quests;

                _quests = new List<Quest>();
                _quests = QuestStages.Select(x => x.Quest).DistinctBy(x => x.ID).ToList();
                return _quests;
            }
        }

        public bool IsChecked
        {
            get
            {
                return Collected;
            }
            set
            {
                Collected = value;
                Areas.ForEach(x => x.AreaPaths.ForEach(y => y.SetCollectedStatus()));
                Merchants.ForEach(x => x.Areas.ForEach(y => y.AreaPaths.ForEach(z => z.SetCollectedStatus())));
                WornByCharacters.ForEach(x => x.Areas.ForEach(y => y.AreaPaths.ForEach(z => z.SetCollectedStatus())));
            }
        }

        public string DisplayRange
        {
            get
            {
                if (!Range.HasValue)
                    return string.Empty;

                return $"{Range:G29} Range";
            }
        }

        public string DisplayActionPointCost
        {
            get
            {
                if (!ActionPointCost.HasValue)
                    return string.Empty;

                return $"{ActionPointCost:G29} AP Cost";
            }
        }

        public string Damage
        {
            get
            {
                if (!DamagePerShot.HasValue || DamagePerShot == 0)
                    return string.Empty;

                return $"{DamagePerShot:G29} Damage";
            }
        }

        public string DPS
        {
            get
            {
                if (!DamagePerSecond.HasValue || DamagePerSecond == 0)
                    return string.Empty;

                return $"({DamagePerSecond:G29} Damage per Second)";
            }
        }

        public string AttackSpeed
        {
            get
            {
                if (FireRate.HasValue && FireRate != 0)
                    return $"Speed {FireRate:G29}";
                else if (!string.IsNullOrWhiteSpace(AttacksPerSecond))
                    return $"Speed {AttacksPerSecond}";
                else
                    return string.Empty;
            }
        }

        public string CriticalHit
        {
            get
            {
                if (!CriticalHitDamage.HasValue && !CriticalChanceMultiplier.HasValue)
                    return string.Empty;

                if (!CriticalChanceMultiplier.HasValue)
                    return $"{CriticalHitDamage:G29} Critical";

                if (!CriticalHitDamage.HasValue)
                    return $"(x{CriticalChanceMultiplier:G29}) Critical";

                return $"{CriticalHitDamage:G29} (x{CriticalChanceMultiplier:G29}) Critical";
            }
        }

        public string AmmoCapacity
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AmmoID)) return string.Empty;

                if (!MagazineCapacity.HasValue)
                    return $"({AmmoID})";

                return $"{MagazineCapacity} ({AmmoID})";
            }
        }

        public string DisplayWeight
        {
            get
            {
                return $"Weight: {Weight}";
            }
        }

        private string GetMerchantLocation()
        {
            var merchant = Merchants.FirstOrDefault();
            var area = merchant.Areas.FirstOrDefault();

            return (area == null) ?
                $"Sold By: {merchant.Name}" :
                $"Sold By: {merchant.Name} - {area.Name}";
        }

        private string GetWornByCharacterLocation()
        {
            var character = WornByCharacters.FirstOrDefault();
            var area = character.Areas.FirstOrDefault();

            return (area == null) ?
                $"Worn By: {character.Name}" :
                $"Worn By: {character.Name} - {area.Name}";
        }
    }
}
