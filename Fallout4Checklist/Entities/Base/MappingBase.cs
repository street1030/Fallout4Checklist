using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Fallout4Checklist.Entities.Base
{
    public class MappingBase<T> : EntityTypeConfiguration<T> where T : class
    {
        public MappingBase()
        {
            ToTable(typeof(T).Name);
        }
    }
}
