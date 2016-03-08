using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fallout4Checklist.Entities.Mapping
{
    public class AmmoMap : EntityTypeConfiguration<Ammo>
    {
        public AmmoMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("Ammo");
            Property(t => t.ID).HasColumnName("ID");
        }
    }
}
