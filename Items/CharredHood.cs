using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using HolyDamageManager;
    using TinyHelper;

    public class CharredHood
    {
        public const string SubfolderName = "CharredHood";
        public const string ItemName = "Charred Hood";
        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name = ItemName,
                Target_ItemID = IDs.tatteredHood1,
                New_ItemID = IDs.charredHoodID,
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
                        8,   0, 15,
                        15, 15,  0,
                        0,   0,  0,
                    },
                    Impact_Resistance = 3,
                    Damage_Protection = 1,
                    Stamina_Use_Penalty = 0f,
                    Mana_Use_Modifier = 15f,
                    Movement_Penalty = 0f,
                    Pouch_Bonus = 0,
                    Cold_Protection = 0,
                    Heat_Protection = 0,
                    Corruption_Protection = 0,
                },
                VisualDetectabilityAdd = -6,

                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
            CustomItems.SetItemTags(item, TinyTagManager.GetSafeTags(new string[] { IDs.WeaponProficiency1Tag }), false);
            return item;
        }

        public static Item MakeRecipes()
        {

            string newUID = CrusadersEquipment.GUID + "." + SubfolderName.ToLower() + "recipe";

            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Survival,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() {Quantity = 1, ItemID = IDs.charredHoodID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.whitePriestHoodID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.obsidianShardID},
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.charredHoodRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            //TinyItemManager.AddEnchantingOption(myitem.New_ItemID, IDs.elattsSanctityHelmID);
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
