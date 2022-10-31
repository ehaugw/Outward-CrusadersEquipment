using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;
    using EffectSourceConditions;

    public class Capitalizer
    {
        public const string SubfolderName = "Capitalizer";

        public static Item MakeItem()
        {

            var myitem = new SL_Item()
            {
                Name = "Capitalizer",
                Target_ItemID = IDs.lexiconID,
                New_ItemID = IDs.capitalizerTrinketID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "A trinket that causes the cooldown of Wrathful Smite to reset if used on a prone target.",
                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    "Trinket",
                    "Item",
                    "HandsFreeTag"
                }),
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID) as Equipment;
            item.IKType = Equipment.IKMode.None;

            var skill = ResourcesPrefabManager.Instance.GetItemPrefab(IDs.wrathfulSmiteID);

            var hitEffects = TinyGameObjectManager.MakeFreshObject("HitEffects", true, true, skill.transform);
            var cooldownChanger = hitEffects.AddComponent<CooldownChangeEffect>();
            cooldownChanger.HitKnockbackCooldown = 0;

            var requirementTransform = TinyGameObjectManager.GetOrMake(hitEffects.transform, EffectSourceConditions.SOURCE_CONDITION_CONTAINER, true, true);
            var skillReq = requirementTransform.gameObject.AddComponent<SourceConditionEquipment>();
            skillReq.RequiredItemID = IDs.capitalizerTrinketID;


            return item as Item;
        }
    }
}
