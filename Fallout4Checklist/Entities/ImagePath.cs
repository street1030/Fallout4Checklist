using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class ImagePath
    {
        public ImagePath()
        {
            Bobbleheads = new List<Bobblehead>();
            Companions = new List<Companion>();
            Magazines = new List<Magazine>();
            Quests = new List<Quest>();
            Weapons = new List<Weapon>();
            Armor = new List<Armor>();
        }

        public int ID { get; set; }
        public string Path { get; set; }

        public virtual ICollection<Bobblehead> Bobbleheads { get; set; }
        public virtual ICollection<Companion> Companions { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
        public virtual ICollection<Quest> Quests { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
        public virtual ICollection<Armor> Armor { get; set; }
    }
}
