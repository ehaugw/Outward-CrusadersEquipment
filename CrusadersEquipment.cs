namespace CrusadersEquipment
{
    using System.Collections.Generic;
    using UnityEngine;
    using SideLoader;
    using HarmonyLib;
    using BepInEx;
    using System.Linq;
    using NodeCanvas.Tasks.Actions;
    using NodeCanvas.Framework;
    using InstanceIDs;
    using ImpendingDoom;
    using System.IO;
    using TinyHelper;
    using Proficiencies;
    using RelicKeeper;
    using BaseDamageModifiers;
    using HolyDamageManager;
    using System;
    using RelicCondition;

    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency(SL.GUID, BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(TinyHelper.GUID, TinyHelper.VERSION)]
    [BepInDependency(Proficiencies.GUID, Proficiencies.VERSION)]
    [BepInDependency(ImpendingDoomMod.GUID, ImpendingDoomMod.VERSION)]
    [BepInDependency(HolyDamageManager.GUID, HolyDamageManager.VERSION)]
    [BepInDependency(BaseDamageModifiers.GUID, BaseDamageModifiers.VERSION)]
    [BepInDependency(RelicKeeper.GUID, BepInDependency.DependencyFlags.SoftDependency)]


    public class CrusadersEquipment : BaseUnityPlugin
    {
        public static CrusadersEquipment Instance;

        public const string GUID = "com.ehaugw.crusadersequipment";
        public const string VERSION = "3.1.1";
        public const string NAME = "Crusaders Equipment";

        public static string ModFolderName = Directory.GetParent(typeof(CrusadersEquipment).Assembly.Location).Name.ToString();

        public Item holyWaterInstance;
        public Item holyWaterRecipeInstance;

        public Item corruptedLongswordInstance;
        public Item puresteelLongswordInstance;
        public Item lightMendersRelicInstance;
        public Item adamantineIngotInstance;

        public Item blessedLongswordRecipeInstance;
        public Item corruptedLongswordRecipeInstance;
        public Item puresteelLongswordRecipeInstance;
        public Item adamantineIngotRecipeInstance;

        public Item crusadersArmorInstance;
        public Item crusadersPlateArmorInstance;
        public Item crusadersRoundShieldInstance;
        public Item crusadersShieldInstance;
        public Item thickWhitePaintInstance;
        public Item crusadersHoodInstance;
        public Item crusadersBootsInstance;

        public Item thickWhitePaintRecipeInstance;
        public Item crusadersShieldRecipeInstance;
        public Item crusadersRoundShieldRecipeInstance;
        public Item crusadersArmorRecipeInstance;
        public Item crusadersPlateArmorRecipeInstance; 
        public Item crusadersHoodRecipeInstance;
        public Item crusadersBootsRecipeInstance;
        public Item zealotsArmorInstance;
        public Item zealotsBootsInstance;
        public Item heavyPlateArmorInstance;

        internal void Awake()
        {
            Instance = this;

            NamelessManNPC.Init();
            RangerHermitNPC.Init();

            SL.BeforePacksLoaded += OnBeforePacksLoaded;
            SL.OnPacksLoaded += OnPackLoaded;
            SL.OnSceneLoaded += OnSceneLoadedEquipment;

            var harmony = new Harmony(GUID);
            harmony.PatchAll();

            Doomsayer.MakeEnchant();
            Lingering.MakeEnchant();
            Expertise.MakeEnchant();
            Footwork.MakeEnchant();
            AegisRing.MakeEnchant();
            FlameOfAnor.MakeEnchant();

            Proficiencies.IWeaponProfiencyFromItemSources.Add(new ExpertiseWeaponProficiencyModifier());
            Proficiencies.IWeaponProfiencyFromItemSources.Add(new FootworkWeaponProficiencyModifier());
            Proficiencies.IWeaponProfiencyFromItemSources.Add(new TagWeaponProficiencyModifier());
        }

        public Trainer altarTrainer;

        private void OnBeforePacksLoaded()
        {
            TinyTagManager.GetOrMakeTag(IDs.WeaponProficiency1Tag);
            TinyTagManager.GetOrMakeTag(IDs.WeaponProficiency2Tag);

        }
        private void OnPackLoaded()
        {
            EffectInitializer.MakeDivineFlameImbue();

            corruptedLongswordInstance = CorruptedLongsword.MakeItem();

            puresteelLongswordInstance = PuresteelLongsword.MakeItem();
            lightMendersRelicInstance = AncientRelic.MakeItem();

            corruptedLongswordRecipeInstance = CorruptedLongsword.MakeRecipes();
            puresteelLongswordRecipeInstance = PuresteelLongsword.MakeRecipes();

            holyWaterInstance = HolyWaterItem.MakeItem();
            holyWaterRecipeInstance = HolyWaterItem.MakeRecipe();

            
            crusadersArmorInstance = CrusadersArmor.MakeItem();
            crusadersPlateArmorInstance = CrusadersPlateArmor.MakeItem();
            crusadersHoodInstance = CrusadersHood.MakeItem();
            crusadersBootsInstance = CrusadersBoots.MakeItem();
            crusadersRoundShieldInstance = CrusadersRoundShield.MakeItem();
            crusadersShieldInstance = CrusadersShield.MakeItem();
            thickWhitePaintInstance = ThickWhitePaint.MakeItem();
            zealotsArmorInstance = ZealotsArmor.MakeItem();
            zealotsBootsInstance = ZealotsBoots.MakeItem();
            heavyPlateArmorInstance = HeavyPlateArmor.MakeItem();

            crusadersArmorRecipeInstance = CrusadersArmor.MakeRecipes();
            crusadersPlateArmorRecipeInstance = CrusadersPlateArmor.MakeRecipes();
            crusadersHoodRecipeInstance = CrusadersHood.MakeRecipes();
            crusadersBootsRecipeInstance = CrusadersBoots.MakeRecipes();
            crusadersRoundShieldRecipeInstance = CrusadersRoundShield.MakeRecipes();
            crusadersShieldRecipeInstance = CrusadersShield.MakeRecipes();
            thickWhitePaintRecipeInstance = ThickWhitePaint.MakeRecipes();
            MakeGoldToSilverRecipe();
            FaraamLongsword.MakeItem();
            FaraamHelmet.MakeItem();
            NobleMask.MakeItem();
            PathfinderMask.MakeItem();
            AshFilterMask.MakeItem();
            RangersHood.MakeItem();
            RangersHood.MakeRecipes();
            WolfRangerArmor.MakeItem();
            WolfRangerArmor.MakeRecipes();
            RangerBoots.MakeItem();
            RangerBoots.MakeRecipes();
            GoldRing.MakeItem();
            GoldRing.MakeRecipe();
            SoulIncense.MakeItem();
            SoulIncense.MakeRecipes();
            CharredHood.MakeItem();
            CharredHood.MakeRecipes();
            GnarledStaff.MakeItem();
            OldDesertTunic.MakeItem();

            Doomsayer.MakeEnchantEffect();
            RadiantSpark.Init();

            SoulWithin.MakeEnchant();

            // Relic Keeper stuff
            foreach (var id in new int[] { IDs.useRelicID, IDs.useRelic2ID })
            {
                if (ResourcesPrefabManager.Instance.GetItemPrefab(id) is Skill useRelic) AddDivineFlameMainHand.Apply(useRelic, IDs.gnarledStaffID);
            }
            if (ResourcesPrefabManager.Instance.GetItemPrefab(IDs.unleashID) is Skill unleash) StaffExplosion.Apply(unleash, IDs.gnarledStaffID);
        }

        private void MakeGoldToSilverRecipe()
        {
            string newUID = CrusadersEquipment.GUID + ".goldingottosilverrecipe";
            new SL_Recipe()
            {
                StationType = Recipe.CraftingType.Survival,
                Results = new List<SL_Recipe.ItemQty>() {
                new SL_Recipe.ItemQty() {Quantity = 100, ItemID = IDs.silverCoinID},
            },
                Ingredients = new List<SL_Recipe.Ingredient>() {
                new SL_Recipe.Ingredient() { Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, Ingredient_ItemID = IDs.goldIngotID},
            },
                UID = newUID,
            }.ApplyTemplate();
        }

        private void OnSceneLoadedEquipment()
        {
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(x => x.name == "HumanSNPC_Blacksmith" && (x.GetComponentInChildren<Merchant>()?.ShopName ?? "") == "Vyzyrinthrix the Blacksmith"))
            {
                if (obj.GetComponentsInChildren<GuaranteedDrop>()?.FirstOrDefault(table => table.ItemGenatorName == "Recipes") is GuaranteedDrop recipeTableBlacksmith)
                {
                    if (SideLoader.At.GetField<GuaranteedDrop>(recipeTableBlacksmith, "m_itemDrops") is List<BasicItemDrop> drops)
                    {
                        foreach (Item item in new Item[] { puresteelLongswordRecipeInstance, adamantineIngotRecipeInstance, crusadersArmorRecipeInstance, crusadersPlateArmorRecipeInstance, crusadersShieldRecipeInstance, crusadersRoundShieldRecipeInstance, crusadersHoodRecipeInstance, crusadersBootsRecipeInstance })
                        {
                            //Used to say DroppedItem = item
                            drops.Add(new BasicItemDrop() { ItemRef = item, MaxDropCount = 1, MinDropCount = 1 });
                        }
                    }
                }
            }

            if (GameObject.Find("UNPC_LaineAberforthA")?.GetComponentsInChildren<GuaranteedDrop>()?.FirstOrDefault(table => table.ItemGenatorName == "Recipes") is GuaranteedDrop recipeTableLaine)
            {
                if (SideLoader.At.GetField<GuaranteedDrop>(recipeTableLaine, "m_itemDrops") is List<BasicItemDrop> drops)
                {
                    foreach (Item item in new Item[] { holyWaterRecipeInstance, thickWhitePaintRecipeInstance })
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
                    if (SideLoader.At.GetField<GuaranteedDrop>(recipeTableMathias, "m_itemDrops") is List<BasicItemDrop> drops)
                    {
                        foreach (Item item in new Item[] { corruptedLongswordRecipeInstance, zealotsArmorInstance, zealotsBootsInstance, crusadersArmorInstance, crusadersBootsInstance, crusadersHoodInstance })
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

    [HarmonyPatch(typeof(Weapon), "AddImbueEffect")]
    public class Weapon_AddImbueEffect
    {
        [HarmonyPrefix]
        public static bool Prefix(Weapon __instance, ref float _lifespan)
        {
            if (__instance.HasTag(TinyTagManager.GetOrMakeTag(IDs.StaffOffHandTag)))
            {
                return false;
            }
            if (__instance.ActiveEnchantmentIDs.Contains(IDs.lingeringID))
            {
                _lifespan += 10;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Character), "ReceiveHit", new Type[] { typeof(UnityEngine.Object), typeof(DamageList), typeof(Vector3), typeof(Vector3), typeof(float), typeof(float), typeof(Character), typeof(float), typeof(bool) })]
    public class Character_ReceiveHit
    {
        [HarmonyPostfix]
        public static void Postfix(Character __instance, ref DamageList __result, UnityEngine.Object _damageSource, DamageList _damage, Vector3 _hitDir, Vector3 _hitPoint, float _angle, float _angleDir, Character _dealerChar, float _knockBack, bool _hitInventory)
        {
            Character ownerCharacter =
                (_damageSource as Item)?.OwnerCharacter ??
                (_damageSource as Effect)?.OwnerCharacter ??
                (_damageSource as EffectSynchronizer)?.OwnerCharacter;

            var fireDamage = __result?[DamageType.Types.Fire]?.Damage ?? 0;

            if (SkillRequirements.SafeHasSkillKnowledge(ownerCharacter, IDs.arcaneInfluenceID) && RelicCondition.HasRelicEquippedOrOnBackpack(ownerCharacter, RequiredEnchantID: IDs.flameOfAnorEnchantID) && fireDamage > 0)
            {
                if (__instance.StatusEffectMngr is StatusEffectManager statusEffectManager)
                {
                    statusEffectManager.AddStatusEffectBuildUp(ResourcesPrefabManager.Instance.GetStatusEffectPrefab(IDs.painNameID), fireDamage, ownerCharacter);
                }
            }
        }
    }
}
