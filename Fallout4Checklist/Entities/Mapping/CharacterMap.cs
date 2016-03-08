using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class CharacterMap : MappingBase<Character>
    {
        public CharacterMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(x => x.Areas)
                .WithMany(x => x.NPCS)
                .Map(m =>
                {
                    m.ToTable("CharacterArea");
                    m.MapLeftKey("CharacterID");
                    m.MapRightKey("AreaID");
                });
        }
    }
}
