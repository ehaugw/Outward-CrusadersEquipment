namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using TinyHelper;

    public class AshFilterMask
    {
        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Target_ItemID = IDs.ashFilterMaskID,
                New_ItemID = -1,
                Description = "Fully prevents Plague",

                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform() {
                        TransformName = "Effect",
                        Effects = new SL_Effect[] {
                            new SL_AffectStatusEffectBuildUpResistance()
                            {
                                Duration=-1,
                                Value=9999,
                                StatusEffectIdentifier="Plague",
                            }
                        }
                    }
                }
            };

            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
            return item;
        }
    }
}
