using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using TinyHelper;

    public class GnarledStaff
    {
        public const string SubfolderName = "GnarledStaff";
        public const string ItemName = "Gnarled Staff";

        //private static Item[] testItem;
        
        public static Item MakeItem()
        {
            float[] weaponData = new[] { 5.5f, 40f, 1f, 5f };
            var myitem = new SL_Weapon()
            {
                Name = ItemName,
                Target_ItemID = IDs.rondelDaggerID,
                New_ItemID = IDs.gnarledStaffID,
                Description = "",

                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    IDs.WeaponTag,
                    IDs.ItemTag,
                    IDs.StaffOffHandTag,
                    IDs.FlameOfAnorCompatibleTag,
                }),
                StatsHolder = new SL_WeaponStats()
                {
                    BaseValue = 10,
                    RawWeight = 2f,
                    MaxDurability = 350,
                    AttackSpeed = weaponData[2],
                    BaseDamage = new List<SL_Damage>() { new SL_Damage() { Damage = weaponData[3], Type = DamageType.Types.Physical } },
                    Impact = weaponData[1],
                    AutoGenerateAttackData = true,
                    StamCost = weaponData[0],
                },
                EffectTransforms = new SL_EffectTransform[] {
                    new SL_EffectTransform() {
                        TransformName = "HitEffects",
                        Effects = new SL_Effect[] {
                        }
                    }
                },
                
                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,

                ItemVisuals = new SL_ItemVisual()
                {
                    Prefab_Name = "gnarled_staff_Prefab",
                    Prefab_AssetBundle = "gnarled_staff",
                    Prefab_SLPack = CrusadersEquipment.ModFolderName,
                    PositionOffset = new UnityEngine.Vector3(0, 0, 0)
                },
            };

            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            //TinyItemManager.AddEnchantingOption(myitem.New_ItemID, IDs.weightlessEnchantID);

            return item;
        }
    }
}
