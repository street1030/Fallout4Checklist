using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ChecklistArmorMap : MappingBase<ChecklistArmor>
    {
        public ChecklistArmorMap()
        {
            HasKey(x => new { x.ChecklistID, x.ArmorID });

            HasRequired(x => x.Checklist)
                .WithMany(x => x.ArmorCollectedStatus)
                .HasForeignKey(x => x.ChecklistID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Armor)
                .WithMany(x => x.ChecklistCollectedStatus)
                .HasForeignKey(x => x.ArmorID)
                .WillCascadeOnDelete(false);
        }
    }
}
