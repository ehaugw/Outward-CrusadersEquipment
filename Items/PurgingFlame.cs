using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;

    public class PurgingFlame
    {
        public const string SubfolderName = "PurgingFlame";

        public static Item MakeItem()
        {

            var myitem = new SL_Item()
            {
                Name = "Purging Flame",
                Target_ItemID = IDs.lexiconID,
                New_ItemID = IDs.purgingFlameTrinketID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "A trinket that causes spark to apply and spread Impending Doom.",
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
