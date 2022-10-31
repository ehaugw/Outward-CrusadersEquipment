using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;

    public class Capitalizer
    {
        public const string SubfolderName = "Capitalizer";

        public static Item MakeItem()
        {

            var myitem = new SL_Item()
            {
                Name = "Capitalizer",
                Target_ItemID = IDs.lexiconID,
                New_ItemID = IDs.purgingFlameTrinketID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "A trinket that causes the cooldown of Wrathful Smite to reset if used on a prone target.",
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
