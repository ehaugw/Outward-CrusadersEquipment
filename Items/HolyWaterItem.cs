
namespace CrusadersEquipment
{
    using System.Collections.Generic;
    using SideLoader;
    using InstanceIDs;
    using Crusader;
    using TinyHelper;

    public class HolyWaterItem
    {
        public const string SubfolderName = "HolyWater";
        public const string ItemName = "Holy Water";

        public static Item MakeItem()
        {
            var myitem = new SL_Item()
            {
                Name = ItemName,
                EffectBehaviour = EditBehaviours.Override,
                Target_ItemID = IDs.blessedPotionID,
                New_ItemID = IDs.holyWaterID,
                Description = "The drinker becomes Blessed and experiences a short Burst of Divinity.",
                //StatsHolder = new SL_WeaponStats()
                //{
                //    BaseValue = 30,
                //    RawWeight = 0.5f,
                //    MaxDurability = -1,
                //},
                StatsHolder = new SL_ItemStats()
                {
                    RawWeight = 0.3f,
                    BaseValue = 4,
                },
                EffectTransforms = new SL_EffectTransform[] {
                    new SL_EffectTransform() {
                        TransformName = "Effects",
                        Effects = new SL_Effect[] {
                            new SL_AddBoonEffect() { StatusEffect = "Bless", AmplifiedEffect = "Bless Amplified", ChanceToContract = 100},
                        }
                    }
                },
                SLPackName = CrusadersEquipment.sideloaderFolder,
                SubfolderName = SubfolderName
            };
            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            if (ResourcesPrefabManager.Instance.GetStatusEffectPrefab(ModTheme.BurstOfDivinityEffectIdentifierName) is StatusEffect burstOfDivinityInstance)
            {
                var addStatus = TinyGameObjectManager.GetOrMake(item.transform, "Effects", true, true).gameObject.AddComponent<AddStatusEffect>();
                addStatus.Status = burstOfDivinityInstance;
                addStatus.BaseChancesToContract = 100;
            }

            return item;
        }

        public static Item MakeRecipe()
        {
            string newUID = TinyUIDManager.MakeUID(ItemName, CrusadersEquipment.GUID, "Recipe");
            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Alchemy,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() { Quantity = 5, ItemID = IDs.holyWaterID},
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddGenericIngredient, Ingredient_Tag = "Water"},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.fireflyPowderID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.crystalPowderID},
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitraryAlchemyRecipeID,
                New_ItemID = IDs.holyWaterRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
            return item;
        }
    }
}
