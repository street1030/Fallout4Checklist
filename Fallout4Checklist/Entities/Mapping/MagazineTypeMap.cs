using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class MagazineTypeMap : MappingBase<MagazineType>
    {
        public MagazineTypeMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
