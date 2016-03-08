using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class QuestMap : MappingBase<Quest>
    {
        public QuestMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            Ignore(x => x.IsChecked);
            Ignore(x => x.IsNotifying);
            Ignore(x => x.XPReward);
            Ignore(x => x.Failed);
            Ignore(x => x.FirstStage);
            Ignore(x => x.ArmorRewards);
            Ignore(x => x.WeaponRewards);
            Ignore(x => x.CompanionRewards);
            Ignore(x => x.OtherRewards);
            Ignore(x => x.SettlementRewards);
           
            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(300);

            Property(t => t.QuestTypeID)
                .IsRequired()
                .HasMaxLength(100);

            // Relationships
            HasMany(t => t.PreviousQuests)
                .WithMany(t => t.NextQuests)
                .Map(m =>
                    {
                        m.ToTable("QuestChain");
                        m.MapLeftKey("NextQuestID");
                        m.MapRightKey("QuestID");
                    });

            HasMany(x => x.GivenByNPC)
                .WithMany(x => x.AvailableQuests)
                .Map(m =>
                {
                    m.ToTable("QuestNPC");
                    m.MapLeftKey("QuestID");
                    m.MapRightKey("CharacterID");
                });

            HasMany(x => x.Locations)
                .WithMany(x => x.Quests)
                .Map(m =>
                {
                    m.ToTable("QuestArea");
                    m.MapLeftKey("QuestID");
                    m.MapRightKey("AreaID");
                });

            HasOptional(t => t.ImagePath)
                .WithMany(t => t.Quests)
                .HasForeignKey(d => d.ImagePathID);

            HasRequired(t => t.QuestType)
                .WithMany(t => t.Quests)
                .HasForeignKey(d => d.QuestTypeID);
        }
    }
}
