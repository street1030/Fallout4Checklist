using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class WeaponTypeMap : MappingBase<WeaponType>
    {
        public WeaponTypeMap()
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
