using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class BobbleheadMap : MappingBase<Bobblehead>
    {
        public BobbleheadMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            Ignore(x => x.IsChecked);

            // Properties
            Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Description)
                .HasMaxLength(300);

            Property(t => t.BobbleheadTypeID)
                .IsRequired()
                .HasMaxLength(30);

            // Relationships
            HasOptional(t => t.Area)
                .WithMany(t => t.Bobbleheads)
                .HasForeignKey(d => d.AreaID);

            HasRequired(t => t.BobbleheadType)
                .WithMany(t => t.Bobbleheads)
                .HasForeignKey(d => d.BobbleheadTypeID);

            HasRequired(t => t.ImagePath)
                .WithMany(t => t.Bobbleheads)
                .HasForeignKey(d => d.ImagePathID);
        }
    }
}
