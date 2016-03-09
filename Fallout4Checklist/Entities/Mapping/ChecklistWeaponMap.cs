using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ChecklistWeaponMap : MappingBase<ChecklistWeapon>
    {
        public ChecklistWeaponMap()
        {
            HasKey(x => new { x.ChecklistID, x.WeaponID });

            HasRequired(x => x.Checklist)
                .WithMany(x => x.WeaponCollectedStatus)
                .HasForeignKey(x => x.ChecklistID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Weapon)
                .WithMany(x => x.ChecklistCollectedStatus)
                .HasForeignKey(x => x.WeaponID)
                .WillCascadeOnDelete(false);
        }
    }
}
