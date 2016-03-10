using Fallout4Checklist.Entities.Base;

namespace Fallout4Checklist.Entities.Mapping
{
    public class ChecklistMap : MappingBase<Checklist>
    {
        public ChecklistMap()
        {
            HasKey(x => x.ID);
            Ignore(x => x.IsNotifying);
            Property(x => x.IsDeleted).IsRequired();
            Property(x => x.Name).HasMaxLength(100).IsRequired();
            Property(x => x.DateCreated).IsRequired();
            Property(x => x.DateDeleted).IsOptional();
        }
    }
}
