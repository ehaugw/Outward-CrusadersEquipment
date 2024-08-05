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
                    BaseValue = 500,
                    RawWeight = 12f,
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
                        20,  0,  0,
                        0,  0,  0,
                        0,  0,  0,
                    },

                    Impact_Resistance = 14,
                    Damage_Protection = 2,
                    Stamina_Use_Penalty = 0f,
                    Mana_Use_Modifier = 0f,
                    Movement_Penalty = -5f,
                    Pouch_Bonus = 8,
                    Heat_Protection = 5,
                    Cold_Protection = 8,
                    Corruption_Protection = 15,
                },
                VisualDetectabilityAdd = -600,
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
