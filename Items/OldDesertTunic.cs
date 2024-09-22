using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using HolyDamageManager;
    using TinyHelper;

    public class OldDesertTunic
    {
        public const string SubfolderName = "OldDesertTunic";
        public const string ItemName = "Old Desert Tunic";
        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name = ItemName,
                Target_ItemID = IDs.desertTunicID,
                New_ItemID = IDs.oldDesertTunicID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "The color of this tunic is lost to time.",
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 550,
                    RawWeight = 4.0f,
                    MaxDurability = 420,
 
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
                        7,  0,  0,
                        0,  0,  0,
                        0,  0,  0,
                    },
                    Impact_Resistance = 10,
                    Damage_Protection = 0,
                    Stamina_Use_Penalty = -10f,
                    Mana_Use_Modifier = -10f,
                    Movement_Penalty = -5f,
                    Pouch_Bonus = 0,
                    Cold_Protection = 0,
                    Heat_Protection = 20,
                    Corruption_Protection = 0,
                },
                VisualDetectabilityAdd = -6,

                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,
            };
            myitem.ApplyTemplate();
            var item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);

            TinyItemManager.SetLegacyResult(IDs.desertTunicID, myitem.New_ItemID);

            return item;
        }
    }
}
