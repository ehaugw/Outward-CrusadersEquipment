using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using ImpendingDoom;
    using InstanceIDs;
    using SideLoader;
    using System;

    public class Expertise
    {
        public const string ItemName = "Expertise";
        public const int EnchantID = IDs.expertiseEnchantID;
        public static void MakeEnchant()
        {
            var myEnchant = new SL_EnchantmentRecipe()
            {
                Name = ItemName,
                Description = "Increases attack speed by 0.1 and increases the scaling of miscellaneous skills and effects.",
                EnchantmentID = EnchantID,
                IncenseItemID = IDs.apolloIncenseID,
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
                    },
                    new SL_EnchantmentRecipe.PillarData()
                    {
                        Direction = SL_EnchantmentRecipe.Directions.East,
                        IsFar = true
                    },
                    new SL_EnchantmentRecipe.PillarData()
                    {
                        Direction = SL_EnchantmentRecipe.Directions.West,
                        IsFar = true
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
                            SelectorValue = TinyTagManager.GetOrMakeTag(IDs.ExpertiseCompatibleTag).TagName,
                        }
                    }
                },
                TimeOfDay = new UnityEngine.Vector2[] { },
                Areas = new AreaManager.AreaEnum[] { },
                Temperature = new TemperatureSteps[] { },
                WindAltarActivated = false,
                IsEnchantingGuildRecipe = false,
                EnchantTime = 5,
                Effects = new SL_EffectTransform[] { },
                AddedDamages = new SL_EnchantmentRecipe.AdditionalDamage[] { },
                StatModifications = new SL_EnchantmentRecipe.StatModification[] {
                    new SL_EnchantmentRecipe.StatModification()
                    {
                        Stat = Enchantment.Stat.AttackSpeed,
                        Value = 0.1f,
                        Type = Enchantment.StatModification.BonusType.Bonus,
                    }
                },
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
    }
}
