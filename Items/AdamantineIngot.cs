using System.Collections.Generic;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;

    public class AdamantineIngot
    {
        public const string SubfolderName = "AdamantineIngot";
        public const string ItemName = "Adamantine Ingot";

        public static Item MakeItem()
        {
            var myitem = new SL_Item()
            {
                Name = ItemName,
                Target_ItemID = IDs.elattsRelicID,
                New_ItemID = IDs.adamantineID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "A sizable ignot made of pure adamantine.",
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
                    new SL_Recipe.ItemQty() { Quantity = 1, ItemID = IDs.adamantineID },
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.tsarStoneID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.purifyingQuartzID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.palladiumScrapsID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.palladiumScrapsID }
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.adamantineRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
