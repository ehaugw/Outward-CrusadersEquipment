using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using TinyHelper;

    public class FaraamLongsword
    {
        public const string SubfolderName = "FaraamLongsword";
        public const string ItemName = "Faraam Longsword";

        //private static Item[] testItem;
        
        public static Item MakeItem()
        {
            float[] weaponData = new[] { 5.5f, 35f, 0.8f, 57f };
            var myitem = new SL_Weapon()
            {
                Name = ItemName,
                Target_ItemID = IDs.ironSwordID,
                New_ItemID = IDs.faraamLongswordID,
                Description = "",

                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    IDs.MaulShoveTag,
                    IDs.BastardTag,
                    IDs.BladeTag,
                    IDs.WeaponTag,
                    IDs.ItemTag,
                }),
                StatsHolder = new SL_WeaponStats()
                {
                    BaseValue = 2000,
                    RawWeight = 8f,
                    MaxDurability = 750,
                    AttackSpeed = weaponData[2],
                    BaseDamage = new List<SL_Damage>() { new SL_Damage() { Damage = weaponData[3], Type = DamageType.Types.Physical } },
                    Impact = weaponData[1],
                    AutoGenerateAttackData = true,
                    StamCost= weaponData[0],
                },
                EffectTransforms = new SL_EffectTransform[] {
                    new SL_EffectTransform() {
                        TransformName = "HitEffects",
                        Effects = new SL_Effect[] {
                        }
                    }
                },
                SwingSound = SwingSoundWeapon.Weapon_2H,
                
                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,

                ItemVisuals = new SL_ItemVisual()
                {
                    Prefab_Name = "faraam_longsword_Prefab",
                    Prefab_AssetBundle = "faraam_longsword",
                    Prefab_SLPack = CrusadersEquipment.ModFolderName,
                    PositionOffset = new UnityEngine.Vector3(-0.03f, 0, 0)
                },
            };

            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            //TinyItemManager.AddEnchantingOption(myitem.New_ItemID, IDs.weightlessEnchantID);

            return item;
        }
    }
}
