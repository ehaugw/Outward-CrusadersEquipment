using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using HolyDamageManager;
    using HarmonyLib;
    using System;
    using TinyHelper;
    using System.Linq;

    public class HeavyPlateArmor
    {
        public const string SubfolderName = "HeavyPlateArmor";
        
        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name = "Heavy Plate Armor",
                Target_ItemID = IDs.plateArmorID,
                New_ItemID = IDs.heavyPlateArmorID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "Heavy armor that adds weight to your weapon swings, passed down by your ancestors.",
                Tags = TinyTagManager.GetOrMakeTags(new string[]
                {
                    IDs.ArmorTag
                }),
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 700,
                    RawWeight = 18.0f,
                    MaxDurability = 530,

                    //Physical = 0,
                    //Ethereal = 1,
                    //Decay = 2,
                    //Electric = 3,
                    //Frost = 4,
                    //Fire = 5,
                    //DarkOLD = 6,
                    //LightOLD = 7,
                    //Raw = 8,
                    //Count = 9

                    Damage_Resistance = new float[]
                    {
                        28, 0, 0,
                        0, 0, 0,
                        0, 0, 0
                    },
                    Damage_Bonus = new float[]
                    {
                        5, 0, 0,
                        0, 0, 0,
                        0, 0, 0
                    },
                    Impact_Resistance = 26,
                    Impact_Bonus = 5,
                    Damage_Protection = 5,
                    Stamina_Use_Penalty = 6f,
                    Mana_Use_Modifier = 0,
                    Movement_Penalty = 4f,
                    Pouch_Bonus = 0,
                    Heat_Protection = 0,
                    Cold_Protection = -8,
                    Corruption_Protection = 0,
                },
                
                SLPackName = CrusadersEquipment.sideloaderFolder,
                SubfolderName = SubfolderName,
            };
            myitem.ApplyTemplate();

            TinyItemManager.SetLegacyResult(IDs.plateArmorID, IDs.heavyPlateArmorID);
            TinyItemManager.AddEnchantingOption(IDs.heavyPlateArmorID, IDs.warmasterEnchantID);
            return ResourcesPrefabManager.Instance.GetItemPrefab(IDs.heavyPlateArmorID);
        }
    }
}
