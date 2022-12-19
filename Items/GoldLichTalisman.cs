﻿using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;
    using EffectSourceConditions;

    public class GoldLichTalisman
    {
        public const string SubfolderName = "GoldLichTalisman";
        public const string ItemName = "Gold Lich Talisman";

        public static Item MakeItem()
        {

            var myitem = new SL_Equipment()
            {
                Name = ItemName,
                Target_ItemID = IDs.arbitraryTrinketID,
                New_ItemID = IDs.goldLichTalismanID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "Crafted from a mechanism from the Light Mender's minions. " + Crusader.CureWoundsSpell.ItemName + " to restore some burnt health.",
                StatsHolder = new SL_ItemStats()
                {
                    MaxDurability = 100,
                    BaseValue = 800 // gold lich equipment is also 800, but gold bars are easier to obtain than sword / shield while in hallowed marsh
                },
                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    IDs.TrinketTag,
                    IDs.HandsFreeTag,
                    IDs.RelicTag,
                    IDs.ItemTag,
                }),

                SLPackName = CrusadersEquipment.sideloaderFolder,
                SubfolderName = SubfolderName,
                ItemVisuals = new SL_ItemVisual()
                {
                    Prefab_Name = "basic_relic_Prefab",
                    Prefab_AssetBundle = "basic_relic",
                    Prefab_SLPack = CrusadersEquipment.sideloaderFolder,
                    RotationOffset = new UnityEngine.Vector3(30, 90, 180),
                    PositionOffset = new UnityEngine.Vector3(-0.03f, 0, 0)
                }
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID) as Equipment;
            item.IKType = Equipment.IKMode.None;

            var skill = ResourcesPrefabManager.Instance.GetItemPrefab(IDs.cureWoundsID);


            
            var effects = TinyGameObjectManager.MakeFreshObject(EffectSourceConditions.EFFECTS_CONTAINER, true, true, skill.transform);
            var burntHealthRestore = effects.gameObject.AddComponent<AffectBurntHealth>();
            burntHealthRestore.AffectQuantity = 1;
            burntHealthRestore.IsModifier = false;

            var requirementTransform = TinyGameObjectManager.GetOrMake(effects.transform, EffectSourceConditions.SOURCE_CONDITION_CONTAINER, true, true);
            var skillReq = requirementTransform.gameObject.AddComponent<SourceConditionEquipment>();
            skillReq.RequiredItemID = IDs.goldLichTalismanID;


            return item as Item;
        }

        public static Item MakeRecipe()
        {
            string newUID = CrusadersEquipment.GUID + "." + SubfolderName.ToLower() + "recipe";
            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Survival,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() { Quantity = 1, ItemID = IDs.goldLichTalismanID },
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.linenClothID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.goldIngotID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.goldlichMechanismID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.fireflyPowderID}
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.goldLichTalismanRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            return item;
        }
    }
}
