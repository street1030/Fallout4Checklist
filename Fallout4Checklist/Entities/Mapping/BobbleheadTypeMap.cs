using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class BobbleheadTypeMap : MappingBase<BobbleheadType>
    {
        public BobbleheadTypeMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
