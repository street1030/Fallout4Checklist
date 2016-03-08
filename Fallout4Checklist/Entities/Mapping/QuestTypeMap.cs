using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class QuestTypeMap : MappingBase<QuestType>
    {
        public QuestTypeMap()
        {
            // Primary Key
            HasKey(t => t.Type);

            // Properties
            Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Description)
                .HasMaxLength(1000);
        }
    }
}
