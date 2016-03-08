using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class FactionMap : MappingBase<Faction>
    {
        public FactionMap()
        {
            // Primary Key
            HasKey(t => t.Name);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
