using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;

    public class CrusadersBoots
    {
        public const string SubfolderName = "CrusadersBoots";

        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name = "Crusader's Boots",
                Target_ItemID = IDs.whitePriestBootsID,
                New_ItemID = IDs.crusadersBootsID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "",
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 300,
                    RawWeight = 3.0f,
                    MaxDurability = 250,

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
                        10,  0,  10,
                        0,  0,  0,
                        0,  0,  0
                    },
                    Impact_Resistance = 6,
                    Damage_Protection = 0,
                    Damage_Bonus = new float[]
                    {
                        0,  0,  0,
                        0,  0,  0,
                        0,  0,  0
                    },
                    Stamina_Use_Penalty = 0,
                    Mana_Use_Modifier =  0,
                    Movement_Penalty = -10f,
                    Pouch_Bonus = 0,
                    Heat_Protection = 0,
                    Cold_Protection = 0,
                    Corruption_Protection = 0,
                },
                SLPackName = CrusadersEquipment.sideloaderFolder,
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
                    new SL_Recipe.ItemQty() {Quantity = 1, ItemID = IDs.crusadersBootsID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.desertBootsID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.whitePriestBootsID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.thickWhitePaintID},
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: Crusader's Boots",
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.crusadersBootsRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
