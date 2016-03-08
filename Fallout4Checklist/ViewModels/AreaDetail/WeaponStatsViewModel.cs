using Fallout4Checklist.Entities;

namespace Fallout4Checklist.ViewModels
{
    public class WeaponStatsViewModel
    {
        public WeaponStatsViewModel(Weapon weapon)
        {
            Weapon = weapon;
        }

        public Weapon Weapon { get; set; }
    }
}
