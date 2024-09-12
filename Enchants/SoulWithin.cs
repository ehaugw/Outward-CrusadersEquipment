using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using ImpendingDoom;
    using InstanceIDs;
    using SideLoader;
    using System;

    public class SoulWithin
    {
        public const string ItemName = "Soul Within";
        public const int EnchantID = IDs.soulWithinEnchantID;
        public static void MakeEnchant()
        {
            var myEnchant = new SL_EnchantmentRecipe()
            {
                Name = ItemName,
                Description = "Souls within protect against elemental damage.",
                EnchantmentID = EnchantID,
                IncenseItemID = IDs.soulIncenseID,
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
                        Direction = SL_EnchantmentRecipe.Directions.West,
                        IsFar = false
                    },
                    new SL_EnchantmentRecipe.PillarData()
                    {
                        Direction = SL_EnchantmentRecipe.Directions.East,
                        IsFar = false
                    },
                },
                CompatibleEquipment = new SL_EnchantmentRecipe.EquipmentData()
                {
                    RequiredTag = IDs.EquipmentTag,
                    Equipments = new SL_EnchantmentRecipe.IngredientData[]
                    {
                        new SL_EnchantmentRecipe.IngredientData()
                        {
                            SelectorType = SL_EnchantmentRecipe.IngredientTypes.Tag,
                            SelectorValue = TinyTagManager.GetOrMakeTag(IDs.SoulWithinCompatibleTag).TagName,
                        }
                    }
                },
                TimeOfDay = new UnityEngine.Vector2[] { },
                Areas = new AreaManager.AreaEnum[] { AreaManager.AreaEnum.CalderaDungeon3 },
                Temperature = new TemperatureSteps[] { },
                WindAltarActivated = false,
                IsEnchantingGuildRecipe = false,
                EnchantTime = 5,
                Effects = new SL_EffectTransform[] { },
                AddedDamages = new SL_EnchantmentRecipe.AdditionalDamage[] { },
                StatModifications = new SL_EnchantmentRecipe.StatModification[] {
                    new SL_EnchantmentRecipe.StatModification()
                    {
                        Stat = Enchantment.Stat.CorruptionResistance,
                        Type = Enchantment.StatModification.BonusType.Bonus,
                        Value = -20,
                    }
                },
                FlatDamageAdded = new SL_Damage[] { },
                DamageModifierBonus = new SL_Damage[] { },
                DamageResistanceBonus= new SL_Damage[] {
                    new SL_Damage()
                    {
                        Type = DamageType.Types.Ethereal,
                        Damage = 20,
                    },
                    new SL_Damage()
                    {
                        Type = DamageType.Types.Electric,
                        Damage = 10,
                    },
                    new SL_Damage()
                    {
                        Type = DamageType.Types.Decay,
                        Damage = 10,
                    },
                    new SL_Damage()
                    {
                        Type = DamageType.Types.Fire,
                        Damage = 10,
                    },
                    new SL_Damage()
                    {
                        Type = DamageType.Types.Frost,
                        Damage = 10,
                    },
                },
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
