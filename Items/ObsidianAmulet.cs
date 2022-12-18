using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;

    public class ObsidianAmulet
    {
        public const string SubfolderName = "ObsidianAmulet";
        public const string ItemName = "Obsidian Amulet";

        public static Item MakeItem()
        {

            var myitem = new SL_Item()
            {
                Name = ItemName,
                Target_ItemID = IDs.arbitraryTrinketID,
                New_ItemID = IDs.obsidianAmuletID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "An ornament crafted from fire-infused glass. Causes spark to apply and spread Impending Doom.",
                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    IDs.TrinketTag,
                    IDs.HandsFreeTag,
                    IDs.RelicTag,
                    IDs.ItemTag,
                }),
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID) as Equipment;
            item.IKType = Equipment.IKMode.None;

            return item as Item;
        }

        public static Item MakeRecipe()
        {
            string newUID = CrusadersEquipment.GUID + "." + SubfolderName.ToLower() + "recipe";
            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Survival,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() { Quantity = 1, ItemID = IDs.obsidianAmuletID },
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.linenClothID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.goldIngotID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.obsidianShardID}
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.obsidianAmuletRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            return item;
        }
    }
}
