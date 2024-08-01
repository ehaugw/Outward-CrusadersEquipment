using InstanceIDs;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

namespace CrusadersEquipment
{
    using NodeCanvas.Framework;
    using SideLoader;
    using SynchronizedWorldObjects;
    using System.Collections.Generic;
    using TinyHelper;

    public class RangerHermitNPC : SynchronizedNPC
    {
        public const string Name = "Ranger Hermit";
        public static void Init()
        {
            var syncedNPC = new RangerHermitNPC(
                identifierName:     Name,
                rpcListenerID:      IDs.NPCID_RangerHermit,
                defaultEquipment:   new int[] { IDs.wolfRangerArmorID, IDs.rangersHoodID, IDs.rangersBootsID, },
                visualData: new SL_Character.VisualData()
                {
                    Gender = Character.Gender.Male,
                    SkinIndex = (int)SL_Character.Ethnicities.White,
                    HeadVariationIndex = 2,
                    HairStyleIndex = (int)HairStyles.PonyTailBraids,
                    HairColorIndex = (int)HairColors.Blonde
                }
            );

            syncedNPC.AddToScene(new SynchronizedNPCScene(
                scene: "EmercarDungeonsSmall",
                position: new Vector3(600.1177f, 0.8192f, 6.6126f),
                rotation: new Vector3(0, 175, 0),
                rpcMeta: "emercar_dungeons_small",
                pose: Character.SpellCastType.Sit,
                shouldSpawnInScene: delegate () { return ShouldSpawnOutside(); }
            ));
        }

        public static bool ShouldSpawnOutside()
        {
            return
                true;
                //QuestRequirements.HasQuestKnowledge(CharacterManager.Instance.GetWorldHostCharacter(), new int[] { IDs.whiteFangOutsideTrackerID }, LogicType.All, requireCompleted: true)
                //|| QuestRequirements.HasQuestEvent(WhiteFangOutsideTracker.QE_MoveOrderToEmercar.EventUID);
        }

        public RangerHermitNPC(string identifierName, int rpcListenerID, int[] defaultEquipment = null, int[] moddedEquipment = null, Vector3? scale = null, Character.Factions? faction = null, SL_Character.VisualData visualData = null) :
            base(identifierName, rpcListenerID, defaultEquipment: defaultEquipment, moddedEquipment: moddedEquipment, scale: scale, faction: faction, visualData: visualData)
        { }

        override public object SetupClientSide(int rpcListenerID, string instanceUID, int sceneViewID, int recursionCount, string rpcMeta)
        {
            Character instanceCharacter = base.SetupClientSide(rpcListenerID, instanceUID, sceneViewID, recursionCount, rpcMeta) as Character;
            if (instanceCharacter == null) return null;

            GameObject instanceGameObject = instanceCharacter.gameObject;

            var merchantTemplate = TinyDialogueManager.AssignMerchantTemplate(instanceGameObject.transform);
            var actor = TinyDialogueManager.SetDialogueActorName(merchantTemplate, IdentifierName);
            var merchantComponent = TinyDialogueManager.SetMerchant(merchantTemplate, null);
            var graph = TinyDialogueManager.GetDialogueGraph(merchantTemplate);
            TinyDialogueManager.SetActorReference(graph, actor);
            graph.allNodes.Clear();

            //Actions
            var openMerchant = TinyDialogueManager.MakeMerchantDialogueAction(graph, merchantComponent);

            //Trainer Statements
            var greetBeforeTrade = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "I cannot remember inviting you?");
            var noWorries = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "No worries.");
            var beforeOpeningShop = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "I may have something of interest.");

            //Player Statements
            var willLeaveText = "I did not realize anyone lived here. No offense, and please forgive me.";
            var requestShopText = "Do you have anything for sale?";

            //Player Choices
            var leaveOrShop = TinyDialogueManager.MakeMultipleChoiceNode(graph, new string[] { willLeaveText, requestShopText });

            if (rpcMeta == "emercar_dungeons_small")
            {
                //set up dialogue
                graph.primeNode = greetBeforeTrade;
                TinyDialogueManager.ChainNodes(graph, new Node[] { greetBeforeTrade, leaveOrShop });
                TinyDialogueManager.ConnectMultipleChoices(graph, leaveOrShop, new Node[] { noWorries, beforeOpeningShop });
                TinyDialogueManager.ChainNodes(graph, new Node[] { beforeOpeningShop, openMerchant });

                //set up shop
                var priceModifier = merchantComponent.gameObject.AddComponent<PriceModifier>();
                priceModifier.SellMultiplierAdded = -0.5f; // from player perspective
                priceModifier.BuyMultiplierAdded = 0.5f;

                var inventoryTable = TinyGameObjectManager.GetOrMake(merchantComponent.transform, "InventoryTable", true, true);
                var dropTable = inventoryTable.gameObject.AddComponent<DropTable>();
                var dropable = inventoryTable.gameObject.AddComponent<Dropable>();
                dropable.UID = new UID();
                var guaranteedDrop = inventoryTable.gameObject.AddComponent<GuaranteedDrop>();
                guaranteedDrop.ItemGenatorName = "DropTable";

                if (SideLoader.At.GetField<GuaranteedDrop>(guaranteedDrop, "m_itemDrops") is List<BasicItemDrop> drops)
                {
                    foreach (int itemId in new int[] { IDs.rangersBootsID, IDs.wolfRangerArmorID, IDs.rangersHoodID })
                    {
                        drops.Add(new BasicItemDrop() { ItemRef = ResourcesPrefabManager.Instance.GetItemPrefab(itemId), MaxDropCount = 1, MinDropCount = 1 });
                        Debug.Log("Added item to shop");
                    }
                }

                //if (obj.GetComponentsInChildren<GuaranteedDrop>()?.FirstOrDefault(table => table.ItemGenatorName == "Recipes") is GuaranteedDrop recipeTableBlacksmith)
                //{
                //    if (SideLoader.At.GetField<GuaranteedDrop>(recipeTableBlacksmith, "m_itemDrops") is List<BasicItemDrop> drops)
                //    {
                //        foreach (Item item in new Item[] { puresteelLongswordRecipeInstance, adamantineIngotRecipeInstance, crusadersArmorRecipeInstance, crusadersPlateArmorRecipeInstance, crusadersShieldRecipeInstance, crusadersRoundShieldRecipeInstance, crusadersHoodRecipeInstance, crusadersBootsRecipeInstance })
                //        {
                //            //Used to say DroppedItem = item
                //            drops.Add(new BasicItemDrop() { ItemRef = item, MaxDropCount = 1, MinDropCount = 1 });
                //        }
                //    }
                //}
            }


            var obj = instanceGameObject.transform.parent.gameObject;
            obj.SetActive(true);

            return instanceCharacter;
        }
    }
}