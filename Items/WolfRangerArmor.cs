using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using HolyDamageManager;
    using TinyHelper;

    public class WolfRangerArmor
    {
        public const string SubfolderName = "WolfRangerArmor";

        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name = "Wolf Ranger's Armor",
                Target_ItemID = IDs.wolfMedicArmorID,
                New_ItemID = IDs.wolfRangerArmorID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "",
                StatsHolder = new SL_EquipmentStats()
                {
                    Stamina_Use_Penalty = 0f,
                    Mana_Use_Modifier = 0f,
                    Movement_Penalty = 0f,
                    Pouch_Bonus = 2,

                    Heat_Protection = 7,
                    Cold_Protection = 7,
                },
                VisualDetectabilityAdd = -6,

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
                    new SL_Recipe.ItemQty() {Quantity = 1, ItemID = IDs.wolfRangerArmorID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.wolfMedicArmorID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.thickOilID},
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: Wolf Ranger Armor",
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.wolfRangerArmorRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            //TinyItemManager.AddEnchantingOption(myitem.New_ItemID, IDs.elattsSanctityHelmID);
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
