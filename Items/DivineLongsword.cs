using System.Collections.Generic;
using SideLoader;
using InstanceIDs;
using TinyHelper;
using UnityEngine;
using Crusader;

namespace CrusadersEquipment
{

    public class DivineLongsword
    {
        public const string SubfolderName = "DivineLongsword";
        public const string ItemName = "Crusader's Longsword";

        public static Item MakeItem()
        {
            float[] ha = new[] { 4.0f, 25f, 1.1f, 35f };
            var myitem = new SL_Weapon()
            {
                Name = ItemName,
                Target_ItemID = IDs.ironSwordID,
                New_ItemID = IDs.divineLongswordID,
                Description = "Has a small chance to inflict and even spread Impending Doom among your foes.",
                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    IDs.FinesseTag,
                    IDs.HolyTag,
                    IDs.BladeTag,
                    IDs.WeaponTag,
                    IDs.ItemTag
                }),
                StatsHolder = new SL_WeaponStats()
                {
                    BaseValue = 1500,
                    RawWeight = 3.5f,
                    MaxDurability = 650,
                    AttackSpeed = ha[2],
                    BaseDamage = new List<SL_Damage>() { new SL_Damage() { Damage = ha[3], Type = DamageType.Types.Physical } },
                    Impact = ha[1],
                    AutoGenerateAttackData = true,
                    //Attacks = new[] {
                    //        HolyAvengerItemPack.MakeAttackData(ha[0], ha[1], ha[2],         ha[3], 1,       1),
                    //        HolyAvengerItemPack.MakeAttackData(ha[0], ha[1], ha[2],         ha[3], 1,       1),
                    //        HolyAvengerItemPack.MakeAttackData(ha[0], ha[1], ha[2] + 0.1f,  ha[3], 1.2f,    1.3f),
                    //        HolyAvengerItemPack.MakeAttackData(ha[0], ha[1], ha[2] + 0.1f,  ha[3], 1.1f,    1.1f),
                    //        HolyAvengerItemPack.MakeAttackData(ha[0], ha[1], ha[2] + 0.1f,  ha[3], 1.1f,    1.1f)
                    //    }
                },
                EffectTransforms = new SL_EffectTransform[] {
                    new SL_EffectTransform() {
                        TransformName = "HitEffects",
                        Effects = new SL_Effect[] {
                            //new SL_AddStatusEffectBuildUp() { StatusEffect = "Doom", Buildup = 60f },
                            //new SL_AddStatusEffect() {StatusEffect = "Radiating", ChanceToContract = 100},
                            //new SL_AddStatusEffectBuildUp() { StatusEffect = "Burning", Buildup = 60f },
                            //new SL_AddStatusEffectBuildUp() {StatusEffect = "Radiating", Buildup = 100f},
                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual() { Prefab_Name = "keenlongsword_Prefab", Prefab_AssetBundle = "keenlongsword", Prefab_SLPack = CrusadersEquipment.sideloaderFolder },
                SLPackName = CrusadersEquipment.sideloaderFolder,
                SubfolderName = SubfolderName,
                SwingSound = SwingSoundWeapon.Weapon_2H,

                //LegacyItemID = IDs.holyAvengerID
            };
            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);


            if (ResourcesPrefabManager.Instance.GetStatusEffectPrefab(ModTheme.ImpendingDoomEffectIdentifierName) is StatusEffect impendingDoomInstance)
            {
                var addAndSpread = TinyGameObjectManager.GetOrMake(item.transform, "HitEffects", true, true).gameObject.AddComponent<AddThenSpreadStatus>();
                addAndSpread.Status = impendingDoomInstance;
                addAndSpread.Range = 3;
                addAndSpread.BaseChancesToContract = 40;
            }
            return item;
        }

        public static Item MakeRecipes()
        {
            string newUID = CrusadersEquipment.GUID + "." + SubfolderName.ToLower() + "recipe";
            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Survival,
                Results = new List<SL_Recipe.ItemQty>() {
                    new SL_Recipe.ItemQty() { Quantity = 1, ItemID = IDs.divineLongswordID },
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.ancientRelicID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.goldIngotID},
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.adamantineID}

                    //new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.hauntedMemoryID },
                    //new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.elattsRelicID },
                    //new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.scourgesTearsID },

                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.divineLongswordRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
