﻿using TinyHelper;
using InstanceIDs;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace Crusader
{
    using EffectSourceConditions;

    public class RadiantSpark
    {
        public static void Init()
        {
            var spark = ResourcesPrefabManager.Instance.GetItemPrefab(IDs.sparkID) as Skill;
            var damagingBlast = spark.transform.Find("Effects").gameObject.GetComponents<ShootBlast>()[0].BaseBlast;

            var extraEffects = TinyGameObjectManager.MakeFreshObject(EffectSourceConditions.EFFECTS_CONTAINER, true, true, damagingBlast.transform).transform;
            //UnityEngine.Object.DontDestroyOnLoad(damagingBlast.gameObject);

            //var punctualDamage = extraEffects.gameObject.AddComponent<PunctualDamage>();
            //punctualDamage.DamageAmplifiedByOwner = true;
            //punctualDamage.BasePotencyValue = 1;
            //punctualDamage.NoDealer = false;
            //punctualDamage.Damages = new DamageType[] { new DamageType(HolyDamageManager.HolyDamageManager.GetDamageType(), 10) };
            //punctualDamage.Knockback = 5;
            //punctualDamage.HitInventory = false;

            var addThenSpread = extraEffects.gameObject.AddComponent<AddThenSpreadStatus>();
            addThenSpread.Status = Crusader.Instance.impendingDoomInstance;
            addThenSpread.Range = Radiating.RANGE * 0.5f;

            //var condition = extraEffects.gameObject.AddComponent<StatusEffectCondition>();
            //condition.StatusEffectPrefab = Crusader.Instance.burstOfDivinityInstance;

            var requirementTransform = TinyGameObjectManager.GetOrMake(addThenSpread.transform, EffectSourceConditions.SOURCE_CONDITION_CONTAINER, true, true);
            var skillReq = requirementTransform.gameObject.AddComponent<SourceConditionEquipment>();
            skillReq.RequiredItemID = IDs.purgingFlameTrinketID;

            //need two stacks because one is consumed
            //var requirementTransform = TinyGameObjectManager.GetOrMake(addThenSpread.transform, EffectSourceConditions.SOURCE_CONDITION_CONTAINER, true, true);
            //var statusReq = requirementTransform.gameObject.AddComponent<SourceConditionStatusEffect>();
            //statusReq.RequiredStatusEffect = Crusader.Instance.burstOfDivinityInstance;
        }
    }
}
