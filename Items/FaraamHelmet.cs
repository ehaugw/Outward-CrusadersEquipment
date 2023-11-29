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
            var myitem = new SL_Armor()
            {
                Name = "Faraam Helmet",
                Target_ItemID = IDs.tatteredHood1,
                New_ItemID = IDs.faraamHelmetID,
                EffectBehaviour = EditBehaviours.Override,
                Description = "",
                StatsHolder = new SL_EquipmentStats()
                {
                    BaseValue = 1000,
                    RawWeight = 8.0f,
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
                        15,  0,  0,
                        0,   0,  0,
                        0,   0,  0
                    },
                    Impact_Resistance = 10,
                    Damage_Protection = 3,
                    BarrierProtection = 3,
                    Stamina_Use_Penalty = 4f,
                    Mana_Use_Modifier = 15f,
                    Movement_Penalty = 9f,
                    Pouch_Bonus = 0,
                    Heat_Protection = 0,
                    Cold_Protection = 0,
                    Corruption_Protection = 5,
                },
                SLPackName = CrusadersEquipment.ModFolderName,
                SubfolderName = SubfolderName,
                Class = Armor.ArmorClass.Heavy,
                //ItemVisuals = new SL_ArmorVisuals()
                //{
                //    HideFace = false,
                //    HideHair = true,
                //    Prefab_Name = "faraam_helmet_Prefab",
                //    Prefab_AssetBundle = "faraam_helmet",
                //    Prefab_SLPack = CrusadersEquipment.ModFolderName,
                //    Position = new UnityEngine.Vector3(0, 0, 0),
                //},
                //SpecialFemaleItemVisuals = new SL_ArmorVisuals()
                //{
                //    HideFace = false,
                //    HideHair = true,
                //    Prefab_Name = "faraam_helmet_Prefab",
                //    Prefab_AssetBundle = "faraam_helmet",
                //    Prefab_SLPack = CrusadersEquipment.ModFolderName,
                //    Position = new UnityEngine.Vector3(0,0,0)
                //},
                //SpecialItemVisuals = new SL_ArmorVisuals()
                //{
                //    HideFace = false,
                //    HideHair = true,
                //    Prefab_Name = "faraam_helmet_Prefab",
                //    Prefab_AssetBundle = "faraam_helmet",
                //    Prefab_SLPack = CrusadersEquipment.ModFolderName,
                //    Position = new UnityEngine.Vector3(0, 0, 0)
                //},
            };
            myitem.ApplyTemplate();
            return ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
        }
    }
}
