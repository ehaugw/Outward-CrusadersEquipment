using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using TinyHelper;

    public class PuresteelLongsword
    {
        public const string SubfolderName = "PuresteelLongsword";
        public const string ItemName = "Ornate Longsword";

        //private static Item[] testItem;
        
        public static Item MakeItem()
        {
            float[] weaponData = new[] { 5.2f, 30f, 0.9f, 48f };
            var myitem = new SL_Weapon()
            {
                Name = ItemName,
                Target_ItemID = IDs.ironSwordID,
                New_ItemID = IDs.puresteelLongswordID,
                Description = "Increases weapon skills damage by 10%",

                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    IDs.BastardTag,
                    IDs.HolyTag,
                    IDs.BladeTag,
                    IDs.WeaponTag,
                    IDs.ItemTag,
                    IDs.MaulShoveTag,
                    IDs.LingeringEligibleTag,
                }),
                StatsHolder = new SL_WeaponStats()
                {
                    BaseValue = 2000,
                    RawWeight = 4.5f,
                    MaxDurability = 650,
                    AttackSpeed = weaponData[2],
                    BaseDamage = new List<SL_Damage>() { new SL_Damage() { Damage = weaponData[3], Type = DamageType.Types.Physical } },
                    Impact = weaponData[1],
                    AutoGenerateAttackData = true,
                    StamCost = weaponData[0],
                },
                EffectTransforms = new SL_EffectTransform[] {
                    new SL_EffectTransform() {
                        TransformName = "HitEffects",
                        Effects = new SL_Effect[] {
                        }
                    }
                },
                SwingSound = SwingSoundWeapon.Weapon_2H,
                
                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,

                ItemVisuals = new SL_ItemVisual()
                {
                    Prefab_Name = "puresteel_longsword_Prefab",
                    Prefab_AssetBundle = "puresteel_longsword",
                    Prefab_SLPack = CrusadersEquipment.ModFolderName,
                    PositionOffset = new UnityEngine.Vector3(-0.03f, 0,0)
                },
            };

            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            var bonusDamage = TinyGameObjectManager.GetOrMake(item.transform, "Effects", true, true).gameObject.AddComponent<AffectStat>();

            var tagSelectorList = new TagSourceSelector[] {new TagSourceSelector(TagSourceManager.Instance.GetTag(IDs.weaponSkilllDamageModifier))};
            bonusDamage.AffectedStat = new TagSourceSelector(TagSourceManager.Instance.GetTag(IDs.allDamagesTag));

            bonusDamage.Tags = tagSelectorList;
            bonusDamage.IsModifier = true;
            bonusDamage.Value = 10;

            return item;
        }
        public static Item MakeRecipes()
        {
            string newUID = CrusadersEquipment.GUID + "." + SubfolderName.ToLower() + "recipe";
            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Survival,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() { Quantity = 1, ItemID = IDs.puresteelLongswordID },
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.ancientRelicID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.goldIngotID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.purifyingQuartzID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.mysteriousBladeID },
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.puresteelLongswordRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            return item;
        }
    }
}
