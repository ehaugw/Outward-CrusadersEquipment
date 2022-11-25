using HarmonyLib;
using InstanceIDs;
using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;
    using EffectSourceConditions;

    public class WoodooCharm
    {
        public const string SubfolderName = "WoodooCharm";
        public const string ItemName = "Woodoo Charm";

        public static Item MakeItem()
        {

            var myitem = new SL_Item()
            {
                Name = ItemName,
                Target_ItemID = IDs.lexiconID,
                New_ItemID = IDs.woodooCharmID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "Woodoo Charm for Woodooing uncharming creatures.",
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

            var skill = ResourcesPrefabManager.Instance.GetItemPrefab(IDs.wrathfulSmiteID);

            

            return item as Item;
        }
    }
}

[HarmonyPatch(typeof(Item), "GetCastSheathRequired")]
public class Item_GetCastSheathRequired
{
    [HarmonyPostfix]
    public static void Postfix(Item __instance, ref int __result)
    {
        if (__instance.ItemID == IDs.tormentID && (__instance.OwnerCharacter?.Inventory?.Equipment?.ItemEquippedCount(IDs.woodooCharmID) ?? 0) > 0)
        {
            __result = 0;
        }
    }
}
