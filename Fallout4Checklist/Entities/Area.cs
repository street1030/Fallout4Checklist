using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fallout4Checklist.Entities
{
    public partial class Area
    {
        public Area()
        {
            AreaPaths = new List<AreaPath>();
            Bobbleheads = new List<Bobblehead>();
            Companions = new List<Companion>();
            Magazines = new List<Magazine>();
            Factions = new List<Faction>();
            Weapons = new List<Weapon>();
            Armor = new List<Armor>();
            Quests = new List<Quest>();
            NPCS = new List<Character>();
            QuestStagesRewardedFrom = new List<QuestStage>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int? MinThreatLevel { get; set; }
        public int? MaxThreatLevel { get; set; }

        public virtual List<AreaPath> AreaPaths { get; set; }
        public virtual ICollection<Bobblehead> Bobbleheads { get; set; }
        public virtual ICollection<Companion> Companions { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
        public virtual ICollection<Faction> Factions { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
        public virtual ICollection<Armor> Armor { get; set; }
        public virtual ICollection<Quest> Quests { get; set; }
        public virtual List<Character> NPCS { get; set; }
        public virtual ICollection<QuestStage> QuestStagesRewardedFrom { get; set; }
    }
}
