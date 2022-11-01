using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;
    using EffectSourceConditions;

    public class AlphaTuanosaurTrinket
    {
        public const string SubfolderName = "AlphaTuanosaurTrinket";

        public static Item MakeItem()
        {

            var myitem = new SL_Item()
            {
                Name = "Alpha Tuanosaur Trinket",
                Target_ItemID = IDs.lexiconID,
                New_ItemID = IDs.alphaTuanosaurTrinketID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "A trinket made from a tail bone of an apex predator. Causes the cooldown of Wrathful Smite to reset if used on a prone target.",
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
            skillReq.RequiredItemID = IDs.alphaTuanosaurTrinketID;


            return item as Item;
        }
    }
}
