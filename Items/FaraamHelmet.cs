using System.Collections.Generic;

namespace CrusadersEquipment
{
    using SideLoader;
    using InstanceIDs;
    using HolyDamageManager;
    using TinyHelper;

    public class FaraamHelmet
    {
        public const string SubfolderName = "FaraamHelmet";

        public static Item MakeItem()
        {
            var myitem = new SL_Equipment()
            {
                Name = "Faraam Helmet",
                Target_ItemID = IDs.tatteredHood1,
                New_ItemID = IDs.faraamHelmetID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "",
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 250,
                    RawWeight = 1.0f,
                    MaxDurability = 300,
 
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
                        10,  0,  10,
                        0,  0,  0,
                        0,   0,  0
                    },
                    Impact_Resistance = 10,
                    Damage_Protection = 3,
                    Stamina_Use_Penalty = 0f,
                    Mana_Use_Modifier = 0f,
                    Movement_Penalty = 0f,
                    Pouch_Bonus = 0,
                    Heat_Protection = 0,
                    Cold_Protection = 0,
                },
                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,

                ItemVisuals = new SL_ItemVisual()
                {
                    Prefab_Name = "faraam_helmet_Prefab",
                    Prefab_AssetBundle = "faraam_helmet",
                    Prefab_SLPack = CrusadersEquipment.ModFolderName,
                    PositionOffset = new UnityEngine.Vector3(-0.03f, 0, 0)
                },
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
