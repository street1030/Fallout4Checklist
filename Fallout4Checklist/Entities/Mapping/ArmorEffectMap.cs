using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ArmorEffectMap : MappingBase<ArmorEffect>
    {
        public ArmorEffectMap()
        {
            HasKey(x => x.ID);
            Property(x => x.Effect).HasMaxLength(200);
        }
    }
}
