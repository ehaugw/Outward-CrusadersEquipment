using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using Crusader;
    using InstanceIDs;
    using SideLoader;
    using System;

    public class Lingering
    {
        public const string ItemName = "Lingering";
        public const int EnchantID = IDs.lingeringID;
        public static void MakeEnchant()
        {
            var myEnchant = new SL_EnchantmentRecipe()
            {
                Name = ItemName,
                Description = "Increases the duration of weapon infusions by 10 seconds.",
                EnchantmentID = EnchantID,
                IncenseItemID = IDs.sylphinaIncenseID,
                PillarDatas = new SL_EnchantmentRecipe.PillarData[]
                {
                    new SL_EnchantmentRecipe.PillarData()
                    {
                        Direction = SL_EnchantmentRecipe.Directions.East,
                        IsFar = false
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
                            SelectorValue = TinyTagManager.GetOrMakeTag(IDs.HolyTag).TagName,
                        }
                    }
                },
                TimeOfDay = new UnityEngine.Vector2[] { },
                Areas = new AreaManager.AreaEnum[]
                {
                    AreaManager.AreaEnum.EmercarDungeon5
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
    }
}
