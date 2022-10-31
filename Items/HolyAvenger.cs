﻿using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using TinyHelper;
    using Crusader;
    using System.Linq;
    using UnityEngine;

    public class HolyAvenger
    {
        public const string SubfolderName = "HolyAvenger";
        public const string ItemName = "Crusader's Bastard Sword";

        //private static Item[] testItem;
        
        public static Item MakeItem()
        {
            float[] weaponData = new[] { 4.8f, 30f, 0.9f, 48f };
            var myitem = new SL_Weapon()
            {
                Name = ItemName,
                Target_ItemID = IDs.ironSwordID,
                New_ItemID = IDs.holyAvengerID,
                Description = "Has a small chance to inflict and even spread Impending Doom among your foes.",

                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    IDs.BastardTag,
                    IDs.HolyTag,
                    IDs.BladeTag,
                    IDs.WeaponTag,
                    IDs.ItemTag
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
                        }
                    }
                },
                SwingSound = SwingSoundWeapon.Weapon_2H,
                
                SLPackName = CrusadersEquipment.sideloaderFolder,
                SubfolderName = SubfolderName,

                ItemVisuals = new SL_ItemVisual() { Prefab_Name = "holyavenger_Prefab", Prefab_AssetBundle = "holyavenger", Prefab_SLPack = CrusadersEquipment.sideloaderFolder, PositionOffset = new UnityEngine.Vector3(-0.03f, 0,0)},
            };

            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            var bonusDamage = TinyGameObjectManager.GetOrMake(item.transform, "Effects", true, true).gameObject.AddComponent<AffectStat>();

            var tagSelectorList = new TagSourceSelector[] {new TagSourceSelector(TagSourceManager.Instance.GetTag("359"))};
            bonusDamage.AffectedStat = new TagSourceSelector(TagSourceManager.Instance.GetTag("96"));

            bonusDamage.Tags = tagSelectorList;
            bonusDamage.IsModifier = true;
            bonusDamage.Value = 10;

            if (ResourcesPrefabManager.Instance.GetStatusEffectPrefab(ModTheme.ImpendingDoomEffectIdentifierName) is StatusEffect impendingDoomInstance)
            {
                var addAndSpread = TinyGameObjectManager.GetOrMake(item.transform, "HitEffects", true, true).gameObject.AddComponent<AddThenSpreadStatus>();
                addAndSpread.Status = impendingDoomInstance;
                addAndSpread.Range = 3;
                addAndSpread.BaseChancesToContract = 20;
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
                    new SL_Recipe.ItemQty() { Quantity = 1, ItemID = IDs.holyAvengerID },
                },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.ancientRelicID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.goldIngotID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.adamantineID },
                    new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.adamantineID}
                },
                UID = newUID,
            }.ApplyTemplate();

            var myitem = new SL_RecipeItem()
            {
                Name = "Crafting: " + ItemName,
                Target_ItemID = IDs.arbitrarySurvivalRecipeID,
                New_ItemID = IDs.holyAvengerRecipeID,
                EffectBehaviour = EditBehaviours.Override,
                RecipeUID = newUID
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            //var prefab = SL.GetSLPack("Crusader").AssetBundles["divinesmite"].LoadAsset<GameObject>("divineinfusion_Prefab").transform;
            //UnityEngine.Object.DontDestroyOnLoad(prefab.gameObject);
            //prefab.parent = item.gameObject.transform;

            return item;
        }
    }
}
