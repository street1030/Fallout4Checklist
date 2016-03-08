using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ImagePathMap : MappingBase<ImagePath>
    {
        public ImagePathMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            Ignore(x => x.FullPath);

            // Properties
            Property(t => t.Path)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
