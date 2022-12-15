using HarmonyLib;
using InstanceIDs;
using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;
    using EffectSourceConditions;
    using System;

    public class WoodooCharm
    {
        public const string SubfolderName = "WoodooCharm";
        public const string ItemName = "Woodoo Charm";

        public static Item MakeItem()
        {

            var myitem = new SL_Item()
            {
                Name = ItemName,
                Target_ItemID = IDs.makeshiftTorchID,
                New_ItemID = IDs.woodooCharmID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "Woodoo Charm for Woodooing uncharming creatures.",
                StatsHolder = new SL_ItemStats()
                {
                    MaxDurability = 100,
                },
                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    "Trinket",
                    "Item",
                    "HandsFreeTag"
                }),

                SLPackName = CrusadersEquipment.sideloaderFolder,
                SubfolderName = SubfolderName,
                ItemVisuals = new SL_ItemVisual()
                {
                    //Prefab_Name = "puresteel_longsword_Prefab",
                    //Prefab_AssetBundle = "puresteel_longsword",

                    Prefab_Name = "basic_relic_Prefab",
                    Prefab_AssetBundle = "basic_relic",
                    Prefab_SLPack = CrusadersEquipment.sideloaderFolder,
                    RotationOffset = new UnityEngine.Vector3(0, 0, (float) Math.PI),
                    PositionOffset = new UnityEngine.Vector3(-0.03f, 0, 0)
                }
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
        if ((__instance.ItemID == IDs.tormentID || __instance.ItemID == IDs.ruptureID) && (__instance.OwnerCharacter?.Inventory?.Equipment?.ItemEquippedCount(IDs.woodooCharmID) ?? 0) > 0)
        {
            __result = 0;
        }
    }
}
