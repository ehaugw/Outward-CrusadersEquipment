using System.Collections.Generic;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;

    public class ThickWhitePaint
    {
        public const string SubfolderName = "ThickWhitePaint";
        
        public static Item MakeItem()
        {
            var myitem = new SL_Item()
            {
                Name = "Thick White Paint",
                Target_ItemID = IDs.thickOilID,
                New_ItemID = IDs.thickWhitePaintID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "Thick white paint that can easily be applied to objects.",
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
                StationType = Recipe.CraftingType.Alchemy,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() {Quantity = 1, ItemID = IDs.thickWhitePaintID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.aquamarineID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.saltID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.thickOilID},
                },
                UID = newUID
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Alchemy: Thick White Paint",
                Target_ItemID = IDs.arbitraryAlchemyRecipeID,
                New_ItemID = IDs.thickWhitePaintRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
