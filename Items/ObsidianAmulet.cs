using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;

    public class ObsidianAmulet
    {
        public const string SubfolderName = "ObsidianAmulet";

        public static Item MakeItem()
        {

            var myitem = new SL_Item()
            {
                Name = "Obsidian Amulet",
                Target_ItemID = IDs.lexiconID,
                New_ItemID = IDs.obsidianAmuletID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "An ornament crafted from fire-infused glass. Causes spark to apply and spread Impending Doom.",
                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    "Trinket",
                    "Item",
                    "HandsFreeTag"
                }),
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID) as Equipment;
            item.IKType = Equipment.IKMode.None;

            return item as Item;
        }
    }
}
