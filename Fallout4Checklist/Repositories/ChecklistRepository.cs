using Fallout4Checklist.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Fallout4Checklist.Repositories
{
    public static class ChecklistRepository
    {
        public static Checklist CurrentChecklist { get; set; }

        public static Checklist GetCurrentChecklist(int id)
        {
            CurrentChecklist = Repository.Checklists.FirstOrDefault(x => x.ID == id);
            return CurrentChecklist;
        }

        public static Checklist Add(string name)
        {
            var checklist = new Checklist();
            checklist.Name = name;
            checklist.DateCreated = DateTime.Now;
            checklist.DateDeleted = null;
            checklist.IsDeleted = false;

            using (var context = new Fallout4ChecklistContext())
            {
                checklist.ArmorCollectedStatus.AddRange(GetChecklistArmor(context));
                checklist.WeaponCollectedStatus.AddRange(GetChecklistWeapon(context));
                checklist.CompanionCollectedStatus.AddRange(GetChecklistCompanion(context));
                checklist.MagazineCollectedStatus.AddRange(GetChecklistMagazine(context));
                checklist.BobbleheadCollectedStatus.AddRange(GetChecklistBobblehead(context));
                checklist.QuestCollectedStatus.AddRange(GetChecklistQuest(context));
                context.Checklists.Add(checklist);
                context.SaveChanges();
            }

            return checklist;
        }

        private static List<ChecklistArmor> GetChecklistArmor(Fallout4ChecklistContext context)
        {
            var armor = context.Armor.Where(x => x.IsMenuItem);
            var result = new List<ChecklistArmor>();

            foreach (var item in armor)
                result.Add(new ChecklistArmor() { Armor = item });

            return result;
        }

        private static List<ChecklistWeapon> GetChecklistWeapon(Fallout4ChecklistContext context)
        {
            var weapons = context.Weapons.Where(x => x.IsMenuItem);
            var result = new List<ChecklistWeapon>();

            foreach (var item in weapons)
                result.Add(new ChecklistWeapon() { Weapon = item });

            return result;
        }

        private static List<ChecklistCompanion> GetChecklistCompanion(Fallout4ChecklistContext context)
        {
            var companions = context.Companions;
            var result = new List<ChecklistCompanion>();

            foreach (var item in companions)
                result.Add(new ChecklistCompanion() { Companion = item });

            return result;
        }

        private static List<ChecklistMagazine> GetChecklistMagazine(Fallout4ChecklistContext context)
        {
            var magazines = context.Set<Magazine>();
            var result = new List<ChecklistMagazine>();

            foreach (var item in magazines)
                result.Add(new ChecklistMagazine() { Magazine = item });

            return result;
        }

        private static List<ChecklistBobblehead> GetChecklistBobblehead(Fallout4ChecklistContext context)
        {
            var bobbleheads = context.Set<Bobblehead>();
            var result = new List<ChecklistBobblehead>();

            foreach (var item in bobbleheads)
                result.Add(new ChecklistBobblehead() { Bobblehead = item });

            return result;
        }

        private static List<ChecklistQuest> GetChecklistQuest(Fallout4ChecklistContext context)
        {
            var quests = context.Set<Quest>();
            var result = new List<ChecklistQuest>();

            foreach (var item in quests)
                result.Add(new ChecklistQuest() { Quest = item });

            return result;
        }
    }
}
