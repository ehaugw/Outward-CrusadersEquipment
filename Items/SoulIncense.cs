using System.Collections.Generic;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;

    public class SoulIncense
    {
        public const string SubfolderName = "SoulIncense";
        public const string ItemName = "Soul Incense";
        
        public static Item MakeItem()
        {
            var myitem = new SL_Item()
            {
                Name = ItemName,
                Target_ItemID = IDs.monarchIncenseID,
                New_ItemID = IDs.soulIncenseID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "A special incense made by extracting souls from a curious relic.",
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
                StationType = Recipe.CraftingType.Alchemy,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() {Quantity = 4, ItemID = IDs.soulIncenseID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.lanternOfSouldID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.dreamersRootID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.dreamersRootID},
                },
                UID = newUID
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Alchemy: " + ItemName,
                Target_ItemID = IDs.arbitraryAlchemyRecipeID,
                New_ItemID = IDs.soulIncenseRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
