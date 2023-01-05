using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using HolyDamageManager;

    public class ZealotsArmor
    {
        public const string SubfolderName = "ZealotsArmor";

        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name = "Zealot's Armor",
                Target_ItemID = IDs.krypteiaArmorID,
                New_ItemID = IDs.zealotsArmorID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "",
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 1000,
                    RawWeight = 15.0f,
                    MaxDurability = 500,

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
                        25, 0, 25,
                        0, 0, 0,
                        0, 0, 0
                    },
                    Impact_Resistance = 18,
                    Damage_Protection = 2,
                    Damage_Bonus = HolyDamageManager.GetHolyDamageBonusArray(14),
                    Stamina_Use_Penalty = 6f,
                    Mana_Use_Modifier = 0,
                    Movement_Penalty = 6f,
                    Pouch_Bonus = 0,
                    Heat_Protection = 0,
                    Cold_Protection = -6,
                    Corruption_Protection = 10,
                },
                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
