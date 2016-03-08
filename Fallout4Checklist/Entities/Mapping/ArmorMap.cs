using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ArmorMap : MappingBase<Armor>
    {
        public ArmorMap()
        {
            HasKey(x => x.ID);
            Property(x => x.Name).HasMaxLength(100);

            Ignore(x => x.IsChecked);
            Ignore(x => x.IsWornByNPC);
            Ignore(x => x.IsPurchased);

            HasOptional(x => x.ImagePath)
                .WithMany(x => x.Armor)
                .HasForeignKey(x => x.ImagePathID);

            HasMany(x => x.Effects)
                .WithRequired(x => x.Armor)
                .HasForeignKey(x => x.ArmorID);

            HasMany(x => x.Slots)
                .WithMany(x => x.Armor)
                .Map(m =>
                {
                    m.MapLeftKey("ArmorID");
                    m.MapRightKey("SlotID");
                    m.ToTable("ArmorSlotArmor");
                });

            HasMany(x => x.Areas)
                .WithMany(x => x.Armor)
                .Map(m =>
                {
                    m.MapLeftKey("ArmorID");
                    m.MapRightKey("AreaID");
                    m.ToTable("ArmorArea");
                });

            HasMany(x => x.Merchants)
                .WithMany(x => x.ArmorSold)
                .Map(m =>
                {
                    m.ToTable("ArmorMerchant");
                    m.MapLeftKey("ArmorID");
                    m.MapRightKey("CharacterID");
                });

            HasMany(x => x.WornByCharacters)
                .WithMany(x => x.ArmorWorn)
                .Map(m =>
                {
                    m.ToTable("ArmorWornByCharacter");
                    m.MapLeftKey("ArmorID");
                    m.MapRightKey("CharacterID");
                });
        }
    }
}
