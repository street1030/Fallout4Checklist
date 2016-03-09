using Fallout4Checklist.Entities.Mapping;
using Fallout4Checklist.Migrations;
using System.Data.Entity;

namespace Fallout4Checklist.Entities
{
    public partial class Fallout4ChecklistContext : DbContext
    {
        static Fallout4ChecklistContext()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<Fallout4ChecklistContext, Configuration>());
        }

        public Fallout4ChecklistContext() : base("Name=Fallout4ChecklistContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<AreaPath> AreaPaths { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestType> QuestTypes { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AmmoMap());
            modelBuilder.Configurations.Add(new AreaMap());
            modelBuilder.Configurations.Add(new AreaPathMap());
            modelBuilder.Configurations.Add(new ArmorMap());
            modelBuilder.Configurations.Add(new ArmorEffectMap());
            modelBuilder.Configurations.Add(new ArmorSlotMap());
            modelBuilder.Configurations.Add(new BobbleheadMap());
            modelBuilder.Configurations.Add(new BobbleheadTypeMap());
            modelBuilder.Configurations.Add(new CharacterMap());
            modelBuilder.Configurations.Add(new CompanionMap());
            modelBuilder.Configurations.Add(new FactionMap());
            modelBuilder.Configurations.Add(new ImagePathMap());
            modelBuilder.Configurations.Add(new MagazineMap());
            modelBuilder.Configurations.Add(new MagazineTypeMap());
            modelBuilder.Configurations.Add(new QuestMap());
            modelBuilder.Configurations.Add(new QuestStageMap());
            modelBuilder.Configurations.Add(new QuestStageChainMap());
            modelBuilder.Configurations.Add(new QuestTypeMap());
            modelBuilder.Configurations.Add(new QuestStageRewardMap());
            modelBuilder.Configurations.Add(new QuestStageRewardTypeMap());
            modelBuilder.Configurations.Add(new WeaponMap());
            modelBuilder.Configurations.Add(new WeaponSubTypeMap());
            modelBuilder.Configurations.Add(new WeaponTypeMap());
            modelBuilder.Configurations.Add(new ChecklistMap());
            modelBuilder.Configurations.Add(new ChecklistArmorMap());
            modelBuilder.Configurations.Add(new ChecklistBobbleheadMap());
            modelBuilder.Configurations.Add(new ChecklistCompanionMap());
            modelBuilder.Configurations.Add(new ChecklistMagazineMap());
            modelBuilder.Configurations.Add(new ChecklistQuestMap());
            modelBuilder.Configurations.Add(new ChecklistWeaponMap());
        }
    }
}
