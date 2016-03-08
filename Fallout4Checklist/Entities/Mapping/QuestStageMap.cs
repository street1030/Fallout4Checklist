using Fallout4Checklist.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fallout4Checklist.Entities.Mapping
{
    public class QuestStageMap : MappingBase<QuestStage>
    {
        public QuestStageMap()
        {
            // Primary Key
            HasKey(t => new { t.QuestID, t.Stage });

            // Properties
            Property(t => t.QuestID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Stage)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(4000);

            // Relationships
            HasRequired(t => t.Quest)
                .WithMany(t => t.QuestStages)
                .HasForeignKey(d => d.QuestID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Weapons)
                .WithMany(x => x.QuestStages)
                .Map(m =>
                {
                    m.MapLeftKey("QuestID", "StageID");
                    m.MapRightKey("WeaponID");
                    m.ToTable("QuestStageWeapon");
                });

            HasMany(x => x.Armor)
                .WithMany(x => x.QuestStages)
                .Map(m =>
                {
                    m.ToTable("QuestStageArmor");
                    m.MapLeftKey("QuestID", "StageID");
                    m.MapRightKey("ArmorID");
                });

            HasMany(x => x.NPCs)
                .WithMany(x => x.QuestStagesRewardedFrom)
                .Map(m =>
                {
                    m.ToTable("QuestStageNPC");
                    m.MapLeftKey("QuestID", "StageID");
                    m.MapRightKey("CharacterID");
                });

            HasMany(x => x.Settlements)
                .WithMany(x => x.QuestStagesRewardedFrom)
                .Map(m =>
                {
                    m.ToTable("QuestStageSettlement");
                    m.MapLeftKey("QuestID", "StageID");
                    m.MapRightKey("SettlementID");
                });

            HasMany(x => x.Companions)
                .WithMany(x => x.QuestStagesRewardedFrom)
                .Map(m =>
                {
                    m.ToTable("QuestStageCompanion");
                    m.MapLeftKey("QuestID", "StageID");
                    m.MapRightKey("CompanionID");
                });

            HasMany(x => x.OtherRewards)
                .WithRequired(x => x.QuestStage)
                .HasForeignKey(x => new { x.QuestID, x.StageID });
        }
    }
}
