using Fallout4Checklist.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Fallout4Checklist.ViewModels;
using Fallout4Checklist.Models.Menu;
using System;

namespace Fallout4Checklist.Repositories
{
    public static class Repository
    {
        public static List<Area> Areas { get; set; }
        public static List<AreaPath> AreaPaths { get; set; }
        public static List<QuestType> QuestTypes { get; set; }
        public static List<Quest> Quests { get; set; }
        public static List<MenuGroup> MenuItems { get; set; }

        public static void Initialize()
        {
            MenuItems = new List<MenuGroup>();
            using (var context = new Fallout4ChecklistContext())
            {
                SetAreas(context);
                SetAreaPaths(context);
                SetQuests(context);
                SetBobbleheadMenuItems(context);
                SetMagazineMenuItems(context);
                SetWeaponMenuItems(context);
                SetArmorMenuItems(context);
                SetPowerArmorMenuItems(context);
                SetCompanionMenuItems(context);
            }
        }

        private static void SetAreaPaths(Fallout4ChecklistContext context)
        {
            AreaPaths = context.Set<AreaPath>()
                .Include(x => x.Area.Quests)
                .Include(x => x.Area.Armor)
                .Include(x => x.Area.Bobbleheads)
                .Include(x => x.Area.Magazines)
                .Include(x => x.Area.Companions)
                .Include(x => x.Area.Weapons)
                .Include(x => x.Area.NPCS.Select(y => y.ArmorSold))
                .Include(x => x.Area.NPCS.Select(y => y.ArmorWorn))
                .Include(x => x.Area.NPCS.Select(y => y.WeaponsSold))
                .Include(x => x.Area.NPCS.Select(y => y.WeaponsWorn))
                .ToList();
        }

        private static void SetQuests(Fallout4ChecklistContext context)
        {
            QuestTypes = context.QuestTypes
                    .Include(x => x.Quests.Select(y => y.QuestStages))
                    .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.Armor.Select(a => a.Slots))))
                    .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.Armor.Select(a => a.Effects))))
                    .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.Companions)))
                    .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.NPCs)))
                    .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.OtherRewards)))
                    .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.Settlements)))
                    .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.Weapons)))
                    .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.NextQuestStages)))
                    .OrderBy(x => x.DisplayOrder)
                    .ToList();

            Quests = QuestTypes.SelectMany(x => x.Quests).OrderBy(x => x.DisplayOrder).ToList();
        }

        private static void SetAreas(Fallout4ChecklistContext context)
        {
            Areas = context.Areas
                .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.Armor.Select(a => a.ImagePath))))
                .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.Companions.Select(a => a.ImagePath))))
                .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.OtherRewards)))
                .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.Settlements)))
                .Include(x => x.Quests.Select(y => y.QuestStages.Select(z => z.Weapons.Select(a => a.ImagePath))))
                .Include(x => x.Companions.Select(y => y.ImagePath))
                .Include(x => x.Weapons.Select(y => y.ImagePath))
                .Include(x => x.Weapons.Select(y => y.QuestStages))
                .Include(x => x.Bobbleheads.Select(y => y.ImagePath))
                .Include(x => x.Magazines.Select(y => y.ImagePath))
                .Include(x => x.Armor.Select(y => y.Slots))
                .Include(x => x.Armor.Select(y => y.Effects))
                .Include(x => x.NPCS.Select(y => y.WeaponsSold.Select(z => z.ImagePath)))
                .Include(x => x.NPCS.Select(y => y.WeaponsWorn.Select(z => z.ImagePath)))
                .Include(x => x.NPCS.Select(y => y.ArmorSold.Select(z => z.Effects)))
                .Include(x => x.NPCS.Select(y => y.ArmorSold.Select(z => z.Slots)))
                .Include(x => x.NPCS.Select(y => y.ArmorWorn.Select(z => z.Effects)))
                .Include(x => x.NPCS.Select(y => y.ArmorWorn.Select(z => z.Slots)))
                .ToList();

            foreach (var area in Areas)
            {
                foreach (var npc in area.NPCS)
                {
                    npc.ArmorSold.ForEach(x => x.IsPurchased = true);
                    npc.ArmorWorn.ForEach(x => x.IsWornByNPC = true);
                    npc.WeaponsSold.ForEach(x => x.IsPurchased = true);
                    npc.WeaponsWorn.ForEach(x => x.IsWornByNPC = true);
                }
            }
        }

        private static void SetArmorMenuItems(Fallout4ChecklistContext context)
        {
            var armor = context.Set<Armor>().Where(x => x.IsMenuItem && !x.IsPowerArmor).ToList();
            var subItems = new List<MenuItem>();

            foreach (var item in armor)
                subItems.Add(new MenuItem(item));

            var menuSubGroup = new MenuSubGroup("All", subItems);
            var menuItem = new MenuGroup("Armor", menuSubGroup);
            MenuItems.Add(menuItem);
        }

        private static void SetPowerArmorMenuItems(Fallout4ChecklistContext context)
        {
            var armor = context.Set<Armor>().Where(x => x.IsMenuItem && x.IsPowerArmor).ToList();
            var subItems = new List<MenuItem>();

            foreach (var item in armor)
                subItems.Add(new MenuItem(item));

            var menuSubGroup = new MenuSubGroup("All", subItems);
            var menuItem = new MenuGroup("Power Armor", menuSubGroup);
            MenuItems.Add(menuItem);
        }

        private static void SetBobbleheadMenuItems(Fallout4ChecklistContext context)
        {
            var bobbleheads = context.Set<Bobblehead>().ToList();
            var bTypes = context.Set<BobbleheadType>().ToList();
            var subGroups = new List<MenuSubGroup>();

            foreach (var bType in bTypes)
            {
                var items = bobbleheads.Where(x => x.BobbleheadTypeID == bType.ID);
                var subItems = new List<MenuItem>();

                foreach (var item in items)
                    subItems.Add(new MenuItem(item));

                var menuSubGroup = new MenuSubGroup(bType.ID, subItems);
                subGroups.Add(menuSubGroup);
            }

            var menuItem = new MenuGroup("Bobbleheads", subGroups);
            MenuItems.Add(menuItem);
        }

        private static void SetCompanionMenuItems(Fallout4ChecklistContext context)
        {
            var companions = context.Companions.Include(x => x.Area).ToList();
            var subItems = new List<MenuItem>();

            foreach (var item in companions)
            {
                var menuSubItem = new MenuItem(item);
                subItems.Add(menuSubItem);
            }

            var menuSubGroup = new MenuSubGroup("All", subItems);
            var menuItem = new MenuGroup("Companions", menuSubGroup);
            MenuItems.Add(menuItem);
        }

        private static void SetWeaponMenuItems(Fallout4ChecklistContext context)
        {
            var weapons = context.Weapons
                .Include(x => x.Merchants)
                .Include(x => x.WornByCharacters)
                .Include(x => x.QuestStages)
                .Include(x => x.Areas)
                .Where(x => x.IsMenuItem).ToList();

            var wTypes = context.Set<WeaponSubType>().ToList();
            var subGroups = new List<MenuSubGroup>();

            foreach (var wType in wTypes)
            {
                var items = weapons.Where(x => x.WeaponSubTypeID == wType.ID && x.WeaponTypeID == wType.WeaponTypeID);
                var subItems = new List<MenuItem>();

                foreach (var item in items)
                    subItems.Add(new MenuItem(item));

                var menuSubGroup = new MenuSubGroup(wType.WeaponTypeID + " - " + wType.ID, subItems);
                subGroups.Add(menuSubGroup);
            }

            var menuItem = new MenuGroup("Weapons", subGroups);
            MenuItems.Add(menuItem);
        }

        private static void SetMagazineMenuItems(Fallout4ChecklistContext context)
        {
            var magazines = context.Set<Magazine>().ToList();
            var mTypes = context.Set<MagazineType>().ToList();
            var subGroups = new List<MenuSubGroup>();

            foreach (var mType in mTypes)
            {
                var items = magazines.Where(x => x.MagazineTypeID == mType.ID);
                var subItems = new List<MenuItem>();

                foreach (var item in items)
                    subItems.Add(new MenuItem(item));

                var menuSubGroup = new MenuSubGroup(mType.ID, subItems);
                subGroups.Add(menuSubGroup);
            }

            var menuItem = new MenuGroup("Magazines", subGroups);
            MenuItems.Add(menuItem);
        }
    }
}
