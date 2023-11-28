using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using HolyDamageManager;
    using TinyHelper;

    public class RangersHood
    {
        public const string SubfolderName = "RangersHood";

        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name = "Ranger's Hood",
                Target_ItemID = IDs.tatteredHood1,
                New_ItemID = IDs.rangersHoodID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "",
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 250,
                    RawWeight = 1.0f,
                    MaxDurability = 300,
 
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
                        8,  0,  20,
                        0,  20, 20,
                        0,   0,  0,
                    },
                    Impact_Resistance = 3,
                    Damage_Protection = 0,
                    Damage_Bonus = HolyDamageManager.GetHolyDamageBonusArray(10),
                    Stamina_Use_Penalty = 0f,
                    Mana_Use_Modifier = 0f,
                    Movement_Penalty = 0f,
                    Pouch_Bonus = 0,
                    Heat_Protection = 5,
                    Cold_Protection = 5,
                    Corruption_Protection = 0,
                },
                VisualDetectabilityAdd = -15,

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
                    new SL_Recipe.ItemQty() {Quantity = 1, ItemID = IDs.rangersHoodID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.whitePriestHoodID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.thickOilID},
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: Ranger's Hood",
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.rangersHoodRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            //TinyItemManager.AddEnchantingOption(myitem.New_ItemID, IDs.elattsSanctityHelmID);
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
