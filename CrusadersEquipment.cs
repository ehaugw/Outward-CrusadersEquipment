namespace CrusadersEquipment
{
    using System.Collections.Generic;
    using UnityEngine;
    using SideLoader;
    using HarmonyLib;
    using BepInEx;
    using Crusader;
    using System.Linq;
    using NodeCanvas.Tasks.Actions;
    using NodeCanvas.Framework;

    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency(Crusader.GUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(HolyDamageManager.HolyDamageManager.GUID, HolyDamageManager.HolyDamageManager.VERSION)]

    public class CrusadersEquipment : BaseUnityPlugin
    {
        public static CrusadersEquipment Instance;

        public const string GUID = "com.ehaugw.crusadersequipment";
        public const string VERSION = "3.0.0";
        public const string NAME = "Crusaders Equipment";

        public const string sideloaderFolder = "CrusadersEquipment";

        public Item holyWaterInstance;
        public Item holyWaterRecipeInstance;

        public Item divineLongswordInstance;
        public Item holyAvengerInstance;
        public Item lightMendersRelicInstance;
        public Item adamantineIngotInstance;

        public Item divineLongswordRecipeInstance;
        public Item blessedLongswordRecipeInstance;
        public Item holyAvengerRecipeInstance;
        public Item adamantineIngotRecipeInstance;

        public Item crusadersArmorInstance;
        public Item crusadersRoundShieldInstance;
        public Item crusadersShieldInstance;
        public Item thickWhitePaintInstance;
        public Item crusadersHoodInstance;
        public Item crusadersBootsInstance;

        public Item thickWhitePaintRecipeInstance;
        public Item crusadersShieldRecipeInstance;
        public Item crusadersRoundShieldRecipeInstance;
        public Item crusadersArmorRecipeInstance;
        public Item crusadersHoodRecipeInstance;
        public Item crusadersBootsRecipeInstance;
        public Item zealotsArmorInstance;
        public Item zealotsBootsInstance;

        public Item purgingFlameInstance;
        public Item capitalizerInstance;
        public Item talismanOfRecoveryInstance;

        internal void Awake()
        {
            Instance = this;

            SL.OnPacksLoaded += OnPackLoaded;
            SL.OnSceneLoaded += OnSceneLoaded;

            SL.OnPacksLoaded += OnPackLoadedEquipment;
            SL.OnSceneLoaded += OnSceneLoadedEquipment;

            var harmony = new Harmony(GUID);
            harmony.PatchAll();
        }

        public Trainer altarTrainer;

        private void OnPackLoaded()
        {
            divineLongswordInstance = DivineLongsword.MakeItem();
            holyAvengerInstance = HolyAvenger.MakeItem();
            lightMendersRelicInstance = AncientRelic.MakeItem();
            adamantineIngotInstance = AdamantineIngot.MakeItem();

            purgingFlameInstance = ObsidianAmulet.MakeItem();
            capitalizerInstance = AlphaTuanosaurTrinket.MakeItem();
            talismanOfRecoveryInstance = TalismanOfRecovery.MakeItem();

            divineLongswordRecipeInstance = DivineLongsword.MakeRecipes();
            holyAvengerRecipeInstance = HolyAvenger.MakeRecipes();
            adamantineIngotRecipeInstance = AdamantineIngot.MakeRecipes();

            holyWaterInstance = HolyWaterItem.MakeItem();
            holyWaterRecipeInstance = HolyWaterItem.MakeRecipe();
        }

        private void OnSceneLoaded()
        {
            if (GameObject.Find("UNPC_LaineAberforthA")?.GetComponentsInChildren<GuaranteedDrop>()?.FirstOrDefault(table => table.ItemGenatorName == "Recipes") is GuaranteedDrop recipeTableLaine)
            {
                if (At.GetField<GuaranteedDrop>(recipeTableLaine, "m_itemDrops") is List<BasicItemDrop> drops)
                {
                    foreach (Item item in new Item[] { holyWaterRecipeInstance })
                    {
                        //Used to say DroppedItem = item
                        drops.Add(new BasicItemDrop() { ItemRef = item, MaxDropCount = 1, MinDropCount = 1 });
                    }
                }
            }

            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                // Add holy sword recipes to Vyzyrinthrix
                if (obj.name == "HumanSNPC_Blacksmith" && (obj.GetComponentInChildren<Merchant>()?.ShopName ?? "") == "Vyzyrinthrix the Blacksmith")
                {
                    if (obj.GetComponentsInChildren<GuaranteedDrop>()?.FirstOrDefault(table => table.ItemGenatorName == "Recipes") is GuaranteedDrop recipes)
                    {
                        if (At.GetField<GuaranteedDrop>(recipes, "m_itemDrops") is List<BasicItemDrop> drops)
                        {
                            foreach (var item in new Item[] { holyAvengerRecipeInstance, divineLongswordRecipeInstance, adamantineIngotRecipeInstance })
                            {
                                //Used to say DroppedItem = item
                                drops.Add(new BasicItemDrop() { ItemRef = item, MaxDropCount = 1, MinDropCount = 1 });
                            }
                        }
                    }
                }
            }
        }

        private void OnPackLoadedEquipment()
        {
            crusadersArmorInstance = CrusadersArmor.MakeItem();
            crusadersHoodInstance = CrusadersHood.MakeItem();
            crusadersBootsInstance = CrusadersBoots.MakeItem();
            crusadersRoundShieldInstance = CrusadersRoundShield.MakeItem();
            crusadersShieldInstance = CrusadersShield.MakeItem();
            thickWhitePaintInstance = ThickWhitePaint.MakeItem();
            zealotsArmorInstance = ZealotsArmor.MakeItem();
            zealotsBootsInstance = ZealotsBoots.MakeItem();

            crusadersArmorRecipeInstance = CrusadersArmor.MakeRecipes();
            crusadersHoodRecipeInstance = CrusadersHood.MakeRecipes();
            crusadersBootsRecipeInstance = CrusadersBoots.MakeRecipes();
            crusadersRoundShieldRecipeInstance = CrusadersRoundShield.MakeRecipes();
            crusadersShieldRecipeInstance = CrusadersShield.MakeRecipes();
            thickWhitePaintRecipeInstance = ThickWhitePaint.MakeRecipes();

            RadiantSpark.Init();
        }

        private void OnSceneLoadedEquipment()
        {
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(x => x.name == "HumanSNPC_Blacksmith" && (x.GetComponentInChildren<Merchant>()?.ShopName ?? "") == "Vyzyrinthrix the Blacksmith"))
            {
                if (obj.GetComponentsInChildren<GuaranteedDrop>()?.FirstOrDefault(table => table.ItemGenatorName == "Recipes") is GuaranteedDrop recipeTableBlacksmith)
                {
                    if (At.GetField<GuaranteedDrop>(recipeTableBlacksmith, "m_itemDrops") is List<BasicItemDrop> drops)
                    {
                        foreach (Item item in new Item[] { crusadersArmorRecipeInstance, crusadersShieldRecipeInstance, crusadersRoundShieldRecipeInstance, crusadersHoodRecipeInstance, crusadersBootsRecipeInstance })
                        {
                            //Used to say DroppedItem = item
                            drops.Add(new BasicItemDrop() { ItemRef = item, MaxDropCount = 1, MinDropCount = 1 });
                        }
                    }
                }
            }

            if (GameObject.Find("UNPC_LaineAberforthA")?.GetComponentsInChildren<GuaranteedDrop>()?.FirstOrDefault(table => table.ItemGenatorName == "Recipes") is GuaranteedDrop recipeTableLaine)
            {
                if (At.GetField<GuaranteedDrop>(recipeTableLaine, "m_itemDrops") is List<BasicItemDrop> drops)
                {
                    foreach (Item item in new Item[] { thickWhitePaintRecipeInstance })
                    {
                        //Used to say DroppedItem = item
                        drops.Add(new BasicItemDrop() { ItemRef = item, MaxDropCount = 1, MinDropCount = 1 });
                    }
                }
            }

            foreach (var transform in new GameObject[] { GameObject.Find("UNPC_MathiasA (1)"), GameObject.Find("UNPC_MathiasA (2)") })
            {
                if (transform?.GetComponentsInChildren<GuaranteedDrop>()?.FirstOrDefault(table => table.ItemGenatorName == "Recipes") is GuaranteedDrop recipeTableMathias)
                {
                    if (At.GetField<GuaranteedDrop>(recipeTableMathias, "m_itemDrops") is List<BasicItemDrop> drops)
                    {
                        foreach (Item item in new Item[] { zealotsArmorInstance, zealotsBootsInstance, crusadersArmorInstance, crusadersBootsInstance, crusadersHoodInstance })
                        {
                            //Used to say DroppedItem = item
                            drops.Add(new BasicItemDrop() { ItemRef = item, MaxDropCount = 1, MinDropCount = 1 });
                        }
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(GiveReward), "OnExecute")]
    public class GiveReward_OnExecute
    {
        [HarmonyPrefix]
        public static void Prefix(GiveReward __instance)
        {
            //Debug.Log("SHOULD TRY TO GIVE");
            if (__instance.ItemReward.Count(x => new int[] { 3000210, 3000212, 3000211, 2130060 }.Contains(x.Item.value.ItemID)) >= 4)
            {
                //Debug.Log("Tried");
                var relicReward = new ItemQuantity();
                var relicRef = new ItemReference();
                relicRef.ItemID = CrusadersEquipment.Instance.lightMendersRelicInstance.ItemID;
                relicReward.Item = new BBParameter<ItemReference>(relicRef);
                relicReward.Quantity = 1;
                __instance.ItemReward.Add(relicReward);
            }
        }
    }
}