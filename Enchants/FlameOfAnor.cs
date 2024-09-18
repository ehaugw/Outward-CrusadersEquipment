using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using ImpendingDoom;
    using InstanceIDs;
    using SideLoader;
    using System;

    public class FlameOfAnor
    {
        public const string ItemName = "Flame of Anor";
        public const int EnchantID = IDs.flameOfAnorEnchantID;
        public static void MakeEnchant()
        {
            var myEnchant = new SL_EnchantmentRecipe()
            {
                Name = ItemName,
                Description = "",
                EnchantmentID = EnchantID,
                IncenseItemID = IDs.flashMossID,
                PillarDatas = new SL_EnchantmentRecipe.PillarData[]
                {
                    new SL_EnchantmentRecipe.PillarData()
                    {
                        Direction = SL_EnchantmentRecipe.Directions.North,
                        IsFar = false
                    },
                },
                CompatibleEquipment = new SL_EnchantmentRecipe.EquipmentData()
                {
                    RequiredTag = IDs.StaffOffHandTag,
                    Equipments = new SL_EnchantmentRecipe.IngredientData[]
                    {
                        new SL_EnchantmentRecipe.IngredientData()
                        {
                            SelectorType = SL_EnchantmentRecipe.IngredientTypes.Tag,
                            SelectorValue = TinyTagManager.GetOrMakeTag(IDs.FlameOfAnorCompatibleTag).TagName,
                        }
                    }
                },
                TimeOfDay = new UnityEngine.Vector2[] {
                },
                Areas = new AreaManager.AreaEnum[] {
                    AreaManager.AreaEnum.NewSirocco,
                },
                Temperature = new TemperatureSteps[] { },
                WindAltarActivated = false,
                IsEnchantingGuildRecipe = true,
                EnchantTime = 5,
                Effects = new SL_EffectTransform[] {
                    new SL_EffectTransform() {
                        TransformName = "HitEffects",
                        Effects = new SL_Effect[] {
                            new SL_AddStatusEffectBuildUp()
                            {
                                StatusEffect = "Blaze",
                                Buildup = 49,
                            }
                        }
                    }
                },
                AddedDamages = new SL_EnchantmentRecipe.AdditionalDamage[] { },
                StatModifications = new SL_EnchantmentRecipe.StatModification[] {
                    new SL_EnchantmentRecipe.StatModification()
                    {
                        Stat = Enchantment.Stat.Impact,
                        Value = 20f,
                        Type = Enchantment.StatModification.BonusType.Bonus,
                    }
                },
                FlatDamageAdded = new SL_Damage[] { },
                DamageModifierBonus = new SL_Damage[] { new SL_Damage() { Type = DamageType.Types.Fire, Damage = 15 } },
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

        //public static void MakeEnchantEffect()
        //{
        //    var enchant = ResourcesPrefabManager.Instance.GetEnchantmentPrefab(EnchantID);

        //    if (ResourcesPrefabManager.Instance.GetStatusEffectPrefab(ModTheme.ImpendingDoomEffectIdentifierName) is StatusEffect impendingDoomInstance)
        //    {
        //        var addAndSpread = TinyGameObjectManager.GetOrMake(enchant.transform, "HitEffects", true, true).gameObject.AddComponent<AddStatusEffectBuildUp>();
        //        addAndSpread.Status = impendingDoomInstance;
        //        addAndSpread.Range = 3;
        //        addAndSpread.BaseChancesToContract = 20;
        //    }
        //    Console.WriteLine("created doomsayer enchant");
        //}
    }
}
