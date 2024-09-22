using HarmonyLib;
using InstanceIDs;
using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;
    using System;
    using UnityEngine;

    public class GoldRing
    {
        public const string SubfolderName = "GoldRing";
        public const string ItemName = "Gold Ring";

        public static Item MakeItem()
        {

            var myitem = new SL_Equipment()
            {
                Name = ItemName,
                Target_ItemID = IDs.arbitraryTrinketID,
                New_ItemID = IDs.goldRingID,
                EffectBehaviour = EditBehaviours.Destroy,
                Description = "",
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 250,
                    RawWeight = 0.1f,
                    MaxDurability = -1,

                    //Physical = 0,
                    //Ethereal = 1,
                    //Decay = 2,
                    //Electric = 3,
                    //Frost = 4,
                    //Fire = 5,
                    //DarkOLD = 6,
                    //LightOLD = 7,
                    //Raw = 8,
                    //Count = 9
                    Damage_Resistance = new float[]
                    {
                        0,0,0,
                        0,0,0,
                        0,0,0,
                    },
                    Corruption_Protection = 0,
                },
                BehaviorOnNoDurability = Item.BehaviorOnNoDurabilityType.Destroy,
                RepairedInRest = false,

                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    IDs.HandsFreeTag,
                    IDs.ItemTag,
                    IDs.EquipmentTag,
                    IDs.RingTag,
                    IDs.SoulWithinCompatibleTag,
                }),

                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,
                ItemVisuals = new SL_ItemVisual()
                {
                    Prefab_Name = "gold_ring_Prefab",
                    Prefab_AssetBundle = "gold_ring",
                    Prefab_SLPack = CrusadersEquipment.ModFolderName,
                    Rotation = new Vector3(0, 0, 90),
                    PositionOffset = new Vector3(-0.065f, 0.03f, -0.06f),
                },
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID) as Equipment;
            item.IKType = Equipment.IKMode.None;

            return item as Item;
        }

        public static Item MakeRecipe()
        {
            string newUID = TinyUIDManager.MakeUID(ItemName, CrusadersEquipment.GUID, "Recipe");
            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Alchemy,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() { Quantity = 1, ItemID = IDs.goldRingID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.goldIngotID},
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.goldRingRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
            return item;
        }
    }
}