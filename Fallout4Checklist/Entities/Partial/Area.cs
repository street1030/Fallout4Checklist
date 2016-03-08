using System.Collections.Generic;
using System.Linq;

namespace Fallout4Checklist.Entities
{
    public partial class Area
    {
        public List<Armor> AllArmor
        {
            get
            {
                if (_allArmor != null)
                    return _allArmor;

                _allArmor = new List<Armor>();
                _allArmor.AddRange(Armor);
                _allArmor.AddRange(NPCS.SelectMany(x => x.ArmorSold));
                _allArmor.AddRange(NPCS.SelectMany(x => x.ArmorWorn));
                return _allArmor;
            }
        }

        public List<Weapon> AllWeapons
        {
            get
            {
                if (_allWeapons != null)
                    return _allWeapons;

                _allWeapons = new List<Weapon>();
                _allWeapons.AddRange(Weapons);
                _allWeapons.AddRange(NPCS.SelectMany(x => x.WeaponsSold));
                _allWeapons.AddRange(NPCS.SelectMany(x => x.WeaponsWorn));
                return _allWeapons;
            }
        }

        public bool? HasKeyCollectables
        {
            get
            {
                if (_hasKeyCollectables.HasValue)
                    return _hasKeyCollectables;

                _hasKeyCollectables = Weapons.Any() ||
                    Armor.Any() ||
                    Bobbleheads.Any() ||
                    Magazines.Any();

                return _hasKeyCollectables;
            }
        }
        
        public bool? HasOtherCollectables
        {
            get
            {
                if (_hasOtherCollectables.HasValue)
                    return _hasOtherCollectables;

                _hasOtherCollectables = NPCS.Any(x => 
                    x.ArmorSold.Any() ||
                    x.ArmorWorn.Any() ||
                    x.WeaponsSold.Any() ||
                    x.WeaponsWorn.Any()) ||
                    Companions.Any();

                return _hasOtherCollectables;
            }
        }

        public bool IsKeyItemsCollected
        {
            get
            {
                return HasKeyCollectables.Value &&
                    Weapons.All(x => x.Collected) &&
                    Armor.All(x => x.Collected) &&
                    Bobbleheads.All(x => x.Collected) &&
                    Magazines.All(x => x.Collected);
            }
        }

        public bool IsAllItemsCollected
        {
            get
            {
                return AllWeapons.All(x => x.Collected) &&
                    AllArmor.All(x => x.Collected) &&
                    Bobbleheads.All(x => x.Collected) &&
                    Magazines.All(x => x.Collected) &&
                    Companions.All(x => x.Collected);
            }
        }

        public string RecommendedLevel
        {
            get
            {
                var prefix = "Recommended Levels: ";
                if (!HasRecommendedLevel) return string.Empty;
                if (!MaxThreatLevel.HasValue) return string.Format("{0}{1}+", prefix, MinThreatLevel);
                return string.Format("{0}{1}-{2}", prefix, MinThreatLevel, MaxThreatLevel);
            }
        }

        public bool HasRecommendedLevel => MinThreatLevel.HasValue;
        public bool HasCompanion => Companions.Any();
        public bool HasWeapon => AllWeapons.Any();
        public bool HasBobblehead => Bobbleheads.Any();
        public bool HasMagazine => Magazines.Any();
        public bool HasArmor => AllArmor.Any();
        private List<Armor> _allArmor;
        private List<Weapon> _allWeapons;
        private bool? _hasKeyCollectables;
        private bool? _hasOtherCollectables;
    }
}
