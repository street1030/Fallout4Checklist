using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class CompanionMap : MappingBase<Companion>
    {
        public CompanionMap()
        {
            // Primary Key
            HasKey(t => t.Name);
            Ignore(x => x.IsChecked);
            Ignore(x => x.FullImagePath);
            Ignore(x => x.Location);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Perk)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.PerkDescription)
                .IsRequired()
                .HasMaxLength(300);

            Property(t => t.PerkRequirement)
                .IsRequired()
                .HasMaxLength(300);

            // Relationships
            HasRequired(t => t.Area)
                .WithMany(t => t.Companions)
                .HasForeignKey(d => d.AreaID);
            HasOptional(t => t.ImagePath)
                .WithMany(t => t.Companions)
                .HasForeignKey(d => d.ImagePathID);

        }
    }
}
