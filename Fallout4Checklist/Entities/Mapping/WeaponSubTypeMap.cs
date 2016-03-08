using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class WeaponSubTypeMap : MappingBase<WeaponSubType>
    {
        public WeaponSubTypeMap()
        {
            // Primary Key
            HasKey(t => new { t.ID, t.WeaponTypeID });

            // Properties
            Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.WeaponTypeID)
                .IsRequired()
                .HasMaxLength(100);

            // Relationships
            HasRequired(t => t.WeaponType)
                .WithMany(t => t.WeaponSubTypes)
                .HasForeignKey(d => d.WeaponTypeID);
        }
    }
}
