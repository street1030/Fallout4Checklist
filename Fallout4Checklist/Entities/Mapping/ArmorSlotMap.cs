using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ArmorSlotMap : MappingBase<ArmorSlot>
    {
        public ArmorSlotMap()
        {
            HasKey(x => x.ID);
            Property(x => x.ID).HasMaxLength(20);
        }
    }
}
