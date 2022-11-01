using System.Collections.Generic;
using TinyHelper;

namespace CrusadersEquipment
{
    using InstanceIDs;
    using SideLoader;
    using EffectSourceConditions;

    public class TalismanOfRecovery
    {
        public const string SubfolderName = "TalismanOfRecovery";

        public static Item MakeItem()
        {

            var myitem = new SL_Item()
            {
                Name = "Talisman of Recovery",
                Target_ItemID = IDs.lexiconID,
                New_ItemID = IDs.talismanOfRecoveryID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "A trinket that causes cure wounds to restore some burnt health.",
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

            var skill = ResourcesPrefabManager.Instance.GetItemPrefab(IDs.cureWoundsID);


            
            var effects = TinyGameObjectManager.MakeFreshObject(EffectSourceConditions.EFFECTS_CONTAINER, true, true, skill.transform);
            var burntHealthRestore = effects.gameObject.AddComponent<AffectBurntHealth>();
            burntHealthRestore.AffectQuantity = 1;
            burntHealthRestore.IsModifier = false;

            var requirementTransform = TinyGameObjectManager.GetOrMake(effects.transform, EffectSourceConditions.SOURCE_CONDITION_CONTAINER, true, true);
            var skillReq = requirementTransform.gameObject.AddComponent<SourceConditionEquipment>();
            skillReq.RequiredItemID = IDs.talismanOfRecoveryID;


            return item as Item;
        }
    }
}
