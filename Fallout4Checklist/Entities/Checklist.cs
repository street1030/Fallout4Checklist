﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;

namespace Fallout4Checklist.Entities
{
    public partial class Checklist : PropertyChangedBase
    {
        public Checklist()
        {
            MagazineCollectedStatus = new List<ChecklistMagazine>();
            BobbleheadCollectedStatus = new List<ChecklistBobblehead>();
            ArmorCollectedStatus = new List<ChecklistArmor>();
            WeaponCollectedStatus = new List<ChecklistWeapon>();
            CompanionCollectedStatus = new List<ChecklistCompanion>();
            QuestCollectedStatus = new List<ChecklistQuest>();
        }

        public int ID { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual List<ChecklistMagazine> MagazineCollectedStatus { get; set; }
        public virtual List<ChecklistBobblehead> BobbleheadCollectedStatus { get; set; }
        public virtual List<ChecklistArmor> ArmorCollectedStatus { get; set; }
        public virtual List<ChecklistWeapon> WeaponCollectedStatus { get; set; }
        public virtual List<ChecklistCompanion> CompanionCollectedStatus { get; set; }
        public virtual List<ChecklistQuest> QuestCollectedStatus { get; set; }
    }
}
