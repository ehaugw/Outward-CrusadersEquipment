using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using HolyDamageManager;
    using TinyHelper;

    public class CrusadersPlateArmor
    {
        public const string SubfolderName = "CrusadersPlateArmor";
        public const string ItemName = "Crusader's Plate Armor";
        
        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name =ItemName,
                Target_ItemID = IDs.runicArmorID,
                New_ItemID = IDs.crusadersPlateArmorID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "",
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 1000,
                    RawWeight = 18.0f,
                    MaxDurability = 375,

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
                        20, 0, 0,
                        0, 0, 0,
                        0, 0, 0
                    },
                    Impact_Resistance = 23,
                    Damage_Protection = 3,
                    BarrierProtection = 3,
                    Damage_Bonus = HolyDamageManager.GetHolyDamageBonusArray(10),
                    Stamina_Use_Penalty = 11f,
                    Mana_Use_Modifier = -10,
                    Movement_Penalty = 6f,
                    Pouch_Bonus = 0,
                    Heat_Protection = -10,
                    Cold_Protection = 0,
                    Corruption_Protection = 10,
                },
                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }

        public static Item MakeRecipes()
        {

            string newUID = CrusadersEquipment.GUID + "." + SubfolderName.ToLower() + "recipe";

            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Survival,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() {Quantity = 1, ItemID = IDs.crusadersPlateArmorID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.runicArmorID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.whitePriestRobesID},
                    //new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.thickWhitePaintID},
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.crusadersPlateArmorRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            TinyItemManager.AddEnchantingOption(myitem.New_ItemID, IDs.elattsSanctityChestID);
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
