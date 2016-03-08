using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class MagazineMap : MappingBase<Magazine>
    {
        public MagazineMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            Ignore(x => x.IsChecked);
            Ignore(x => x.Location);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.MagazineTypeID)
                .IsRequired()
                .HasMaxLength(100);

            // Relationships
            HasOptional(t => t.Area)
                .WithMany(t => t.Magazines)
                .HasForeignKey(d => d.AreaID);
            HasOptional(t => t.ImagePath)
                .WithMany(t => t.Magazines)
                .HasForeignKey(d => d.ImagePathID);
            HasRequired(t => t.MagazineType)
                .WithMany(t => t.Magazines)
                .HasForeignKey(d => d.MagazineTypeID);
        }
    }
}
