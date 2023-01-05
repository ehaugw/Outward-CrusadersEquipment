using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;

    public class CrusadersShield
    {
        public const string SubfolderName = "CrusadersShield";
        public static Item MakeItem()
        {
            var myitem = new SL_Weapon()
            {
                Name = "Crusader's Shield",
                Target_ItemID = IDs.crimsonShieldID,
                New_ItemID = IDs.crusadersShieldID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "This was originally a Blood-red shield used by the leaders of northern tribes, but it was later painted to indicate affiliation to Elatt.",
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
                    new SL_Recipe.ItemQty() {Quantity = 1, ItemID = IDs.crusadersShieldID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.crimsonShieldID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.thickWhitePaintID},
                },
                UID = newUID
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: Crusader's Shield",
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.crusadersShieldRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
