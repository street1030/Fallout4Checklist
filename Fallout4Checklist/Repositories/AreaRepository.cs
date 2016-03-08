using Fallout4Checklist.Entities;
using System.Linq;

namespace Fallout4Checklist.Repositories
{
    public static class AreaRepository
    {
        public static Area GetAreaByID(int id)
        {
            return Repository.Areas.FirstOrDefault(x => x.ID == id);
        }
    }
}
