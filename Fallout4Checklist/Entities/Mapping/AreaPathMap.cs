using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class AreaPathMap : MappingBase<AreaPath>
    {
        public AreaPathMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            Ignore(x => x.IsAnimating);
            Ignore(x => x.IsNotifying);
            Ignore(x => x.CollectedStatus);

            // Properties
            Property(t => t.Data)
                .IsRequired()
                .HasMaxLength(4000);

            Property(x => x.Height).HasPrecision(18, 4);
            Property(x => x.Width).HasPrecision(18, 4);
            Property(x => x.CanvasLeft).HasPrecision(18, 4);
            Property(x => x.CanvasTop).HasPrecision(18, 4);

            // Relationships
            HasRequired(t => t.Area)
                .WithMany(t => t.AreaPaths)
                .HasForeignKey(d => d.AreaID);
        }
    }
}
