using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class WeaponMap : MappingBase<Weapon>
    {
        public WeaponMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            Ignore(x => x.IsChecked);
            Ignore(x => x.Location);
            Ignore(x => x.AreaID);
            Ignore(x => x.Quests);
            Ignore(x => x.DisplayActionPointCost);
            Ignore(x => x.DisplayRange);
            Ignore(x => x.Damage);
            Ignore(x => x.DPS);
            Ignore(x => x.AttackSpeed);
            Ignore(x => x.CriticalHit);
            Ignore(x => x.AmmoCapacity);
            Ignore(x => x.DisplayWeight);
            Ignore(x => x.IsWornByNPC);
            Ignore(x => x.IsPurchased);

            // Properties
            Property(t => t.Name)
                .HasMaxLength(100);

            Property(t => t.WeaponTypeID)
                .HasMaxLength(100);

            Property(t => t.WeaponSubTypeID)
                .HasMaxLength(100);

            Property(t => t.AttacksPerSecond)
                .HasMaxLength(20);

            Property(t => t.AmmoID)
                .HasMaxLength(100);

            // Relationships
            HasOptional(t => t.Ammo)
                .WithMany(t => t.Weapons)
                .HasForeignKey(d => d.AmmoID);

            HasOptional(t => t.ImagePath)
                .WithMany(t => t.Weapons)
                .HasForeignKey(d => d.ImagePathID);

            HasOptional(t => t.WeaponSubType)
                .WithMany(t => t.Weapons)
                .HasForeignKey(d => new { d.WeaponSubTypeID, d.WeaponTypeID });

            HasMany(x => x.Merchants)
                .WithMany(x => x.WeaponsSold)
                .Map(m =>
                {
                    m.ToTable("WeaponMerchant");
                    m.MapLeftKey("WeaponID");
                    m.MapRightKey("CharacterID");
                });

            HasMany(x => x.WornByCharacters)
                .WithMany(x => x.WeaponsWorn)
                .Map(m =>
                {
                    m.ToTable("WeaponWornByCharacter");
                    m.MapLeftKey("WeaponID");
                    m.MapRightKey("CharacterID");
                });
        }
    }
}
