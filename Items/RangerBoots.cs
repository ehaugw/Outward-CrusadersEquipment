﻿using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using HolyDamageManager;
    using TinyHelper;
    using System.Linq;

    public class RangerBoots
    {
        public const string SubfolderName = "RangerBoots";

        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name = "Ranger's Boots",
                Target_ItemID = IDs.masterTraderBootsID,
                New_ItemID = IDs.rangersBootsID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "",
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 250,
                    RawWeight = 1.0f,
                    MaxDurability = 200,

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
                        7,  0,  0,
                        0,  0,  0,
                        0,  0,  0,
                    },

                    Impact_Resistance = 6,
                    Damage_Protection = 1,
                    Stamina_Use_Penalty = 0f,
                    Mana_Use_Modifier = 0f,
                    Movement_Penalty = -15f,
                    Pouch_Bonus = 2,
                    Heat_Protection = 5,
                    Cold_Protection = 5,
                    Corruption_Protection = 5,
                },
                VisualDetectabilityAdd = -3,

                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
            CustomItems.SetItemTags(item, TinyTagManager.GetSafeTags(new string[] {IDs.WeaponProficiency1Tag, IDs.FootworkCompatibleTag, }),false);
            return item;
        }

        public static Item MakeRecipes()
        {

            string newUID = CrusadersEquipment.GUID + "." + SubfolderName.ToLower() + "recipe";

            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Survival,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() {Quantity = 1, ItemID = IDs.rangersBootsID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.masterTraderBootsID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.thickOilID},
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: Ranger's Boots",
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.rangersBootsRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            //TinyItemManager.AddEnchantingOption(myitem.New_ItemID, IDs.elattsSanctityHelmID);
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
