using System.Collections.Generic;
using TinyHelper;
using InstanceIDs;
using SideLoader;
using UnityEngine;
using System.Linq;
using EffectSourceConditions;
using System;
using TinyHelper.Interfaces;

namespace CrusadersEquipment
{
    using UnityEngine;
    class EffectInitializer
    {
        public static ImbueEffectPreset MakeDivineFlameImbue()
        {
            //var requireDivineFavour = false;
            float flatDamage = 7;
            float scalingDamage = 0.25f;
            DamageType.Types secondaryDamageType = HolyDamageManager.HolyDamageManager.GetDamageType();

            ImbueEffectPreset effectPreset = TinyEffectManager.MakeImbuePreset(
                imbueID: IDs.divineFlameImbueID,
                name: "Divine Flame Imbue",
                description: "Weapon deals some Fire Damage, some " + secondaryDamageType.ToString() + " Damage based on your Fire Damage Bonus, and inflicts Burning on enemies.",
                //iconFileName: SwampWitch.ModFolderName + @"\SideLoader\Texture2D\chaosImbueIcon.png",
                visualEffectID: IDs.fireVarnishImbueID
            );

            Transform effectTransform;

            effectTransform = TinyGameObjectManager.MakeFreshObject("Effects", true, true, effectPreset.transform).transform;
            TinyEffectManager.MakeWeaponDamage(effectTransform, flatDamage, scalingDamage, DamageType.Types.Fire, 0);
            TinyEffectManager.MakeWeaponDamage(effectTransform, 0, 0, secondaryDamageType, 0);
            TinyEffectManager.MakeStatusEffectBuildup(effectTransform, IDs.burningNameID, 49);

            effectTransform = TinyGameObjectManager.MakeFreshObject("HitEffects", true, true, effectPreset.transform).transform;
            
            var fx = effectPreset.ImbueFX;
            fx = Object.Instantiate(fx);
            fx.gameObject.SetActive(false);
            Object.DontDestroyOnLoad(fx);
            effectPreset.ImbueFX = fx;

            var main = fx.Find("FireParticlesLargeCore").GetComponent<ParticleSystem>().main;
            main.startColor = new ParticleSystem.MinMaxGradient(new Color(1f, 1f, 1f, 0.7f), new Color(0.8f, 0.8f, 1f, 0.7f));

            BaseDamageModifiers.BaseDamageModifiers.WeaponDamageModifiers += delegate (Weapon weapon, DamageList original, ref DamageList result)
            {
                if (weapon?.HasImbuePreset(IDs.divineFlameImbueID) ?? false)
                {
                    var fireDamage = (original.TotalDamage * scalingDamage + flatDamage);
                    var fireDamageList = new DamageList(DamageType.Types.Fire, fireDamage);
                    weapon?.OwnerCharacter?.Stats?.GetAmplifiedDamage(new Tag[] { }, ref fireDamageList);
                    var lightningDamage = fireDamageList.TotalDamage - fireDamage;

                    result.Add(new DamageList(secondaryDamageType, lightningDamage));
                }
            };

            return effectPreset;
        }
    }
}
