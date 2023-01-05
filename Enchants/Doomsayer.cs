using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using ImpendingDoom;
    using InstanceIDs;
    using SideLoader;
    using System;

    public class Doomsayer
    {
        public const string ItemName = "Doomsayer";
        public const int EnchantID = IDs.doomsayerID;
        public static void MakeEnchant()
        {
            var myEnchant = new SL_EnchantmentRecipe()
            {
                Name = ItemName,
                Description = "Has a small chance to inflict and spread Impending Doom among your foes.",
                EnchantmentID = EnchantID,
                IncenseItemID = IDs.lunaIncenseID,
                PillarDatas = new SL_EnchantmentRecipe.PillarData[]
                {
                    new SL_EnchantmentRecipe.PillarData()
                    {
                        Direction = SL_EnchantmentRecipe.Directions.North,
                        IsFar = false
                    },
                    new SL_EnchantmentRecipe.PillarData()
                    {
                        Direction = SL_EnchantmentRecipe.Directions.South,
                        IsFar = false
                    }
                },
                CompatibleEquipment = new SL_EnchantmentRecipe.EquipmentData()
                {
                    RequiredTag = IDs.WeaponTag,
                    Equipments = new SL_EnchantmentRecipe.IngredientData[]
                    {
                        new SL_EnchantmentRecipe.IngredientData()
                        {
                            SelectorType = SL_EnchantmentRecipe.IngredientTypes.Tag,
                            SelectorValue = TinyTagManager.GetOrMakeTag(IDs.HolyTag).TagName,
                        }
                    }
                },
                TimeOfDay = new UnityEngine.Vector2[] { },
                Areas = new AreaManager.AreaEnum[]
                {
                    AreaManager.AreaEnum.HallowedDungeon5
                },
                Temperature = new TemperatureSteps[] { },
                WindAltarActivated = false,
                IsEnchantingGuildRecipe = false,
                EnchantTime = 5,
                Effects = new SL_EffectTransform[] { },
                AddedDamages = new SL_EnchantmentRecipe.AdditionalDamage[] { },
                StatModifications = new SL_EnchantmentRecipe.StatModification[] { },
                FlatDamageAdded = new SL_Damage[] { },
                DamageModifierBonus = new SL_Damage[] { },
                DamageResistanceBonus= new SL_Damage[] { },
                HealthAbsorbRatio = 0,
                ManaAbsorbRatio = 0,
                StaminaAbsorbRatio= 0,
                Indestructible = false,
                TrackDamageRatio = -1,
                GlobalStatusResistance= 0,
            };
            myEnchant.ApplyTemplate();
        }

        public static void MakeEnchantEffect()
        {
            var enchant = ResourcesPrefabManager.Instance.GetEnchantmentPrefab(EnchantID);

            if (ResourcesPrefabManager.Instance.GetStatusEffectPrefab(ModTheme.ImpendingDoomEffectIdentifierName) is StatusEffect impendingDoomInstance)
            {
                var addAndSpread = TinyGameObjectManager.GetOrMake(enchant.transform, "HitEffects", true, true).gameObject.AddComponent<AddThenSpreadStatus>();
                addAndSpread.Status = impendingDoomInstance;
                addAndSpread.Range = 3;
                addAndSpread.BaseChancesToContract = 20;
            }
            Console.WriteLine("created doomsayer enchant");
        }
    }
}
