using InstanceIDs;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

namespace CrusadersEquipment
{
    using NodeCanvas.Framework;
    using SideLoader;
    using SynchronizedWorldObjects;
    using System.Collections.Generic;
    using System.Linq;
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

            var merchantTemplate = TinyDialogueManager.AssignTrainerTemplate(instanceGameObject.transform);
            var actor = TinyDialogueManager.SetDialogueActorName(merchantTemplate, IdentifierName);
            var merchantComponent = TinyDialogueManager.SetMerchant(merchantTemplate, null);
            var graph = TinyDialogueManager.GetDialogueGraph(merchantTemplate);
            TinyDialogueManager.SetActorReference(graph, actor);
            graph.allNodes.Clear();

            //Actions
            //var openMerchant = TinyDialogueManager.MakeMerchantDialogueAction(graph, merchantComponent);
            var giveWolfRangerArmor = TinyDialogueManager.MakeGiveItemReward(graph, IDs.wolfRangerArmorID, GiveReward.Receiver.Instigator);
            var giveUpGoldBars = TinyDialogueManager.MakeResignItem(graph, IDs.goldIngotID, GiveReward.Receiver.Instigator, quantity: 10);

            //Trainer Statements
            var greetBeforeTrade = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "I cannot remember inviting you?");
            var noWorries = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "No worries.");
            var thankForTrade = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "Thank you!");
            var beforeOpeningShop = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "I may have something of interest. I could sell you a Wolf Ranger Armor for only ten gold ingots.");

            //Player Statements
            var willLeaveText = "I did not realize anyone lived here. No offense, and please forgive me.";
            var requestShopText = "Do you have anything for sale?";
            var acceptTradeText = "Sure thing!";
            var refuseTradeText = "No, but thank you for offering.";

            //Inventory Item conditions
            var playerHasGoldBars = TinyDialogueManager.MakeHasItemConditionSimple(graph, IDs.goldIngotID, 10);

            //Player Choices
            var leaveOrShop = TinyDialogueManager.MakeMultipleChoiceNode(graph, new string[] { willLeaveText, requestShopText });
            var responseToTrades = TinyDialogueManager.MakeMultipleChoiceNode(graph, new string[] { acceptTradeText, refuseTradeText});
            var brokeResponseToTrade = TinyDialogueManager.MakeMultipleChoiceNode(graph, new string[] { refuseTradeText });

            if (rpcMeta == "emercar_dungeons_small")
            {
                //set up dialogue
                graph.primeNode = greetBeforeTrade;
                TinyDialogueManager.ChainNodes(graph, new Node[] { greetBeforeTrade, leaveOrShop });
                TinyDialogueManager.ConnectMultipleChoices(graph, leaveOrShop, new Node[] { noWorries, beforeOpeningShop });
                TinyDialogueManager.ChainNodes(graph, new Node[] { beforeOpeningShop, playerHasGoldBars });
                TinyDialogueManager.ConnectMultipleChoices(graph, playerHasGoldBars, new Node[] { responseToTrades, brokeResponseToTrade });
                TinyDialogueManager.ConnectMultipleChoices(graph, responseToTrades, new Node[] { thankForTrade, noWorries });
                TinyDialogueManager.ConnectMultipleChoices(graph, brokeResponseToTrade, new Node[] { noWorries });
                TinyDialogueManager.ChainNodes(graph, new Node[] { thankForTrade, giveUpGoldBars, giveWolfRangerArmor});

                //set up shop
                var priceModifier = merchantComponent.gameObject.AddComponent<PriceModifier>();
                priceModifier.SellMultiplierAdded = -0.5f; // from player perspective
                priceModifier.BuyMultiplierAdded = 0.5f;

                ////SHOULD PROBABLY NOT BE HERE. THIS IS CREATED IN Merchant.InitDropTableGameObject
                //var inventoryTable = TinyGameObjectManager.GetOrMake(merchantComponent.transform, "InventoryTable", true, true);
                //var itemContainer = inventoryTable.gameObject.AddComponent<ItemContainer>();
                //itemContainer.UID = instanceUID + "ItemContainer";

                //SIDELOADER
                //var droptable = new SL_DropTable() { UID = instanceUID + "_Droptable" };
                //droptable.GuaranteedDrops.Append(new SL_ItemDrop()
                //{
                //    DroppedItemID = IDs.wolfRangerArmorID,
                //    MaxQty = 1,
                //    MinQty = 1,
                //});
                //droptable.AddAsDropableToGameObject(inventoryTable.gameObject, false, instanceUID + "_Dropable");

                ////MANUAL
                //var dropTable = inventoryTable.gameObject.AddComponent<DropTable>();
                //var dropable = inventoryTable.gameObject.AddComponent<Dropable>();
                //var guaranteedDrop = inventoryTable.gameObject.AddComponent<GuaranteedDrop>();
                //guaranteedDrop.ItemGenatorName = "DropTable";

                //if (SideLoader.At.GetField<GuaranteedDrop>(guaranteedDrop, "m_itemDrops") is List<BasicItemDrop> drops)
                //{
                //    foreach (int itemId in new int[] { IDs.rangersBootsID, IDs.wolfRangerArmorID, IDs.rangersHoodID })
                //    {
                //        drops.Add(new BasicItemDrop() { ItemRef = ResourcesPrefabManager.Instance.GetItemPrefab(itemId), MaxDropCount = 1, MinDropCount = 1 });
                //        Debug.Log("Added item to shop");
                //    }
                //}
            }


            var obj = instanceGameObject.transform.parent.gameObject;
            obj.SetActive(true);

            return instanceCharacter;
        }
    }
}