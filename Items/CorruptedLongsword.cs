using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using TinyHelper;

    public class CorruptedLongsword
    {
        public const string SubfolderName = "CorruptedLongsword";
        public const string ItemName = "Corrupted Longsword";

        //private static Item[] testItem;
        
        public static Item MakeItem()
        {
            float[] weaponData = new[] { 6f, 34f, 0.8f, 57f };
            var myitem = new SL_Weapon()
            {
                Name = ItemName,
                Target_ItemID = IDs.ironSwordID,
                New_ItemID = IDs.corruptedLongswordID,
                Description = "",

                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    IDs.BastardTag,
                    IDs.BladeTag,
                    IDs.WeaponTag,
                    IDs.ItemTag,
                    IDs.LingeringEligibleTag,
                }),
                StatsHolder = new SL_WeaponStats()
                {
                    BaseValue = 2000,
                    RawWeight = 9f,
                    MaxDurability = 750,
                    AttackSpeed = weaponData[2],
                    BaseDamage = new List<SL_Damage>() { new SL_Damage() { Damage = weaponData[3], Type = DamageType.Types.Physical } },
                    Impact = weaponData[1],
                    AutoGenerateAttackData = true,
                    StamCost= weaponData[0],
                },
                HealthLeechRatio = 0.02f,
                HealthBurnLeechRatio = 0.01f,
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
                    Prefab_Name = "corrupted_longsword_Prefab",
                    Prefab_AssetBundle = "corrupted_longsword",
                    Prefab_SLPack = CrusadersEquipment.ModFolderName,
                    PositionOffset = new UnityEngine.Vector3(-0.025f, 0,0)
                },
            };

            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            //var bonusDamage = TinyGameObjectManager.GetOrMake(item.transform, "Effects", true, true).gameObject.AddComponent<AffectStat>();

            //var tagSelectorList = new TagSourceSelector[] {new TagSourceSelector(TagSourceManager.Instance.GetTag("359"))};
            //bonusDamage.AffectedStat = new TagSourceSelector(TagSourceManager.Instance.GetTag("96"));

            //bonusDamage.Tags = tagSelectorList;
            //bonusDamage.IsModifier = true;
            //bonusDamage.Value = 10;
            return item;
        }
        public static Item MakeRecipes()
        {
            string newUID = CrusadersEquipment.GUID + "." + SubfolderName.ToLower() + "recipe";
            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Survival,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() { Quantity = 1, ItemID = IDs.corruptedLongswordID },
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.ancientRelicID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.darkStoneID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.adamantineID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.adamantineID}
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.corruptedLongswordRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            return item;
        }
    }
}
