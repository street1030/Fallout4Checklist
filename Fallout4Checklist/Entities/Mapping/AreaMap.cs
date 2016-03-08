using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class AreaMap : MappingBase<Area>
    {
        public AreaMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            Ignore(x => x.AllArmor);
            Ignore(x => x.AllWeapons);
            Ignore(x => x.RecommendedLevel);
            Ignore(x => x.HasRecommendedLevel);
            Ignore(x => x.HasCompanion);
            Ignore(x => x.HasWeapon);
            Ignore(x => x.HasBobblehead);
            Ignore(x => x.HasMagazine);
            Ignore(x => x.HasArmor);
            Ignore(x => x.HasKeyCollectables);
            Ignore(x => x.HasOtherCollectables);
            Ignore(x => x.IsAllItemsCollected);
            Ignore(x => x.IsKeyItemsCollected);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Relationships
            HasMany(t => t.Factions)
                .WithMany(t => t.Areas)
                .Map(m =>
                    {
                        m.ToTable("AreaFaction");
                        m.MapLeftKey("AreaID");
                        m.MapRightKey("FactionID");
                    });

            HasMany(t => t.Weapons)
                .WithMany(t => t.Areas)
                .Map(m =>
                    {
                        m.ToTable("WeaponArea");
                        m.MapLeftKey("AreaID");
                        m.MapRightKey("WeaponID");
                    });
        }
    }
}
