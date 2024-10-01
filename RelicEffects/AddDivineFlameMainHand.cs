using InstanceIDs;
using SideLoader;
using System;
using UnityEngine;
using RelicCondition;


namespace RelicKeeper
{
    public static class AddDivineFlameMainHand
    {
        public static void Apply(Skill skill, int requiredItem)
        {
            var relicCondition = RelicConditionBuilder.Apply(
                skill, requiredItem, "Temporarly adds Fire and " + HolyDamageManager.HolyDamageManager.GetDamageType().ToString() + " Damage to your weapon, and inflicts Burning on enemies.",
                requiredEnchant: IDs.flameOfAnorEnchantID, manaCost: 14, durabilityCost: 10, cooldown: 60, relicLevel: 2,
                castType: Character.SpellCastType.SpellBindLight, mobileCastMovementMult: 0, castModifier: Character.SpellCastModifier.Immobilized, castSheatheRequired: 2
            );
            var addImbue = relicCondition.EffectsContainer.gameObject.AddComponent<ImbueWeapon>();
            addImbue.ImbuedEffect = ResourcesPrefabManager.Instance.GetEffectPreset(IDs.divineFlameImbueID) as ImbueEffectPreset;
            addImbue.AffectSlot = Weapon.WeaponSlot.MainHand;
            addImbue.SetLifespanImbue(60);
        }
    }
}
