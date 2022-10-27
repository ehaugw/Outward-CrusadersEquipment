using System.Collections.Generic;
namespace CrusadersEquipment
{
    using HolyDamageManager;
    using SideLoader;
    using InstanceIDs;

    public class ZealotsBoots
    {
        public const string SubfolderName = "ZealotsBoots";

        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name = "Zealot's Boots",
                Target_ItemID = IDs.krypteiaBootsID,
                New_ItemID = IDs.zealotsBootsID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "",
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 700,
                    RawWeight = 10.0f,
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
                        18,  0,  15,
                        0,  0,  0,
                        0,  0,  0
                    },
                    Impact_Resistance = 10,
                    Damage_Protection = 2,
                    Damage_Bonus = HolyDamageManager.GetHolyDamageBonusArray(7),

                    Stamina_Use_Penalty = 4,
                    Mana_Use_Modifier =  0,
                    Movement_Penalty = 4f,
                    Pouch_Bonus = 0,
                    Heat_Protection = 0,
                    Cold_Protection = 0,
                    Corruption_Protection = 0,
                },
                SLPackName = CrusadersEquipment.sideloaderFolder,
                SubfolderName = SubfolderName,
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
