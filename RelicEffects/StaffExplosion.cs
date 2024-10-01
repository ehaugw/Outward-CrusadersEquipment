using InstanceIDs;
using SideLoader;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using RelicCondition;


namespace RelicKeeper
{
    public static class StaffExplosion
    {
        public static void Apply(Skill skill, int requiredItem)
        {
            var relicCondition = RelicConditionBuilder.Apply(
                skill, requiredItem, "Creates an explosion that damages and inflicts Scorched on enemies.",
                requiredEnchant: IDs.flameOfAnorEnchantID, manaCost: 14, durabilityCost: 30, cooldown: 100, castType: Character.SpellCastType.PistolShotCheat, relicLevel: 2, mobileCastMovementMult: 0, castModifier: Character.SpellCastModifier.Immobilized
            );

            var damageBlast = new SL_ShootBlast()
            {
                CastPosition = Shooter.CastPositionType.Local,

                //BaseBlast = SL_ShootBlast.BlastPrefabs.AshPriestExplosion, //lightning explosion
                //BaseBlast = SL_ShootBlast.BlastPrefabs.BoozuProudBeastBlast, //purple lightning explosion
                //BaseBlast = SL_ShootBlast.BlastPrefabs.Fireblast, //typical fireball
                //BaseBlast = SL_ShootBlast.BlastPrefabs.GolemShieldedMortarBlast, //fireball
                //BaseBlast = SL_ShootBlast.BlastPrefabs.BurningBlast,
                //BaseBlast = SL_ShootBlast.BlastPrefabs.Dispersion, //stones on ground like predator leap
                //BaseBlast = SL_ShootBlast.BlastPrefabs.DispersionWind, //stones on ground with wind

                //BaseBlast = SL_ShootBlast.BlastPrefabs.CageBossBlastBig,          //big purple lightning explosion
                //BaseBlast = SL_ShootBlast.BlastPrefabs.ChimesReverbBlastLarge,    //hypernova
                //BaseBlast = SL_ShootBlast.BlastPrefabs.GrenadeBlast, //big fire blast

                LocalPositionAdd = new Vector3(-0.15f, 2.1f, 1.4f),
                BaseBlast = SL_ShootBlast.BlastPrefabs.GrenadeShrapnelBlast, //air blast rather than fire. perfect


                TargetType = Shooter.TargetTypes.Enemies,

                Radius = 3.5f,
                BlastLifespan = 1,
                RefreshTime = -1,
                InstantiatedAmount = 5,
                Interruptible = true,
                HitOnShoot = true,
                IgnoreShooter = true,
                ParentToShootTransform = false,
                ImpactSoundMaterial = EquipmentSoundMaterials.NONE,
                DontPlayHitSound = false,
                EffectBehaviour = EditBehaviours.Destroy,
                Delay = 0,
                BlastEffects = new SL_EffectTransform[] {
                    new SL_EffectTransform() {
                        TransformName = "Effects",
                        Effects = new SL_Effect[] {
                            new SL_AddStatusEffect()
                            {
                                StatusEffect = IDs.scorchedNameID,
                            },
                            new SL_AutoKnock()
                            {
                            },
                            new SL_PunctualDamage()
                            {
                                Knockback = 70,
                                Damage = new List<SL_Damage>{
                                    new SL_Damage()
                                    {
                                        Damage = 30,
                                        Type = DamageType.Types.Fire,
                                    },
                                    new SL_Damage()
                                    {
                                        Damage = 10,
                                        Type = HolyDamageManager.HolyDamageManager.GetDamageType(),
                                    },
                                    new SL_Damage()
                                    {
                                        Damage = 10,
                                        Type = DamageType.Types.Physical,
                                    }
                                },
                            }
                        }
                    }
                },
            }.ApplyToTransform(relicCondition.EffectsContainer) as ShootBlast;


            var smokeBlast = new SL_ShootBlast()
            {
                CastPosition = Shooter.CastPositionType.Local,
                LocalPositionAdd = new Vector3(-0.15f, 0f, 1.4f),

                TargetType = Shooter.TargetTypes.Any,

                BaseBlast = SL_ShootBlast.BlastPrefabs.EliteAshGiantAsh,
                Radius = 7,
                BlastLifespan = 5,
                RefreshTime = 0.5f,
                InstantiatedAmount = 5,
                Interruptible = false,
                HitOnShoot = true,
                IgnoreShooter = false,
                ParentToShootTransform = false,
                ImpactSoundMaterial = EquipmentSoundMaterials.NONE,
                DontPlayHitSound = true,
                EffectBehaviour = EditBehaviours.Destroy,
                Delay = 0,
                BlastEffects = new SL_EffectTransform[] {
                    new SL_EffectTransform() {
                        TransformName = "Effects",
                        Effects = new SL_Effect[] {
                        }
                    }
                },
            }.ApplyToTransform(relicCondition.EffectsContainer) as ShootBlast;

            if (smokeBlast?.BaseBlast?.transform?.Find("ExplosionFX/smokeSharp")?.GetComponent<ParticleSystem>()?.main is MainModule main)
            {
                //var main = particle.transform.Find("FireParticlesLargeCore").GetComponent<ParticleSystem>().main;
                main.startColor = new ParticleSystem.MinMaxGradient(new Color(0.5f, 0.5f, 0.5f, 0.7f), new Color(0.2f, 0.2f, 0.2f, 0.7f));

                //particle.main.startColor = new ParticleSystem.MinMaxGradient(new Color(1f, 1f, 1f, 0.7f), new Color(0.8f, 0.8f, 1f, 0.7f));
            }
        }
    }
}
