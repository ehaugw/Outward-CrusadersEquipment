using InstanceIDs;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

namespace CrusadersEquipment
{
    using NodeCanvas.Framework;
    using SideLoader;
    using SynchronizedWorldObjects;
    using TinyHelper;

    public class NamelessManNPC : SynchronizedNPC
    {
        public const string Name = "Nameless man";
        public static void Init()
        {
            var syncedNPC = new NamelessManNPC(
                identifierName:     Name,
                rpcListenerID:      IDs.NPCID_WhiteFang,
                defaultEquipment: new int[] { IDs.desertTunicID, IDs.shadowKaziteLightBootsID, IDs.tatteredHood1},
                visualData: new SL_Character.VisualData()
                {
                    Gender = Character.Gender.Male,
                    SkinIndex = (int)SL_Character.Ethnicities.Asian,
                    HeadVariationIndex = 2,
                    HairStyleIndex = (int)HairStyles.PonyTailBraids,
                    HairColorIndex = (int)HairColors.BrownDark
                }
            );
            syncedNPC.AddToScene(new SynchronizedNPCScene(
                scene: "Levant",
                position: new Vector3(-150.8948f, 4.4318f, 29.976f),
                rotation: new Vector3(0, 28.3112f, 0),
                rpcMeta: "slums",
                shouldSpawnInScene: delegate () { return ShouldSpawnOutside(); }
            ));
        }

        public static bool ShouldSpawnOutside()
        {
            return true;
        }

        public NamelessManNPC(string identifierName, int rpcListenerID, int[] defaultEquipment = null, int[] moddedEquipment = null, Vector3? scale = null, Character.Factions? faction = null, SL_Character.VisualData visualData = null) :
            base(identifierName, rpcListenerID, defaultEquipment: defaultEquipment, moddedEquipment: moddedEquipment, scale: scale, faction: faction, visualData: visualData)
        { }

        override public object SetupClientSide(int rpcListenerID, string instanceUID, int sceneViewID, int recursionCount, string rpcMeta)
        {
            Character instanceCharacter = base.SetupClientSide(rpcListenerID, instanceUID, sceneViewID, recursionCount, rpcMeta) as Character;
            if (instanceCharacter == null) return null;

            GameObject instanceGameObject = instanceCharacter.gameObject;
            var trainerTemplate = TinyDialogueManager.AssignTrainerTemplate(instanceGameObject.transform);
            var actor = TinyDialogueManager.SetDialogueActorName(trainerTemplate, IdentifierName);
            var graph = TinyDialogueManager.GetDialogueGraph(trainerTemplate);
            TinyDialogueManager.SetActorReference(graph, actor);
            graph.allNodes.Clear();

            //Actions
            var giveFaraamLongsword = TinyDialogueManager.MakeGiveItemReward(graph, IDs.faraamLongswordID, GiveReward.Receiver.Instigator);
            var giveUpIronCoin = TinyDialogueManager.MakeResignItem(graph, IDs.ironCoinID, GiveReward.Receiver.Instigator);
            var giveUpGoldBar = TinyDialogueManager.MakeResignItem(graph, IDs.goldIngotID, GiveReward.Receiver.Instigator, quantity: 10);

            //Trainer Statements
            var npcStatesAllMenMustDie = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "All men must die.");
            var npcDispleased = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "A person should leave.");
            var npcRequestsToSeeCoin = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "Show me the faceless coin.");
            var offerToSell = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "I am willing to part with my sword for that iron coin and ten gold bars. What do you say?");
            var excellentChoice = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "Excellent choice.");
            var aManHasNoName = TinyDialogueManager.MakeStatementNode(graph, IdentifierName, "A man has no name.");

            //Player Statements
            var allMenMustDieText = "All men must die!";
            var allMenMustServeText = "All men must... serve?";
            var exitDialogueWithInsult = "I get why you're banished to the slums.";
            var whatCoinText = "What coin?";
            var showCoinText = "I was curious if this would ever serve a purpose!";
            var hideCoinText = "No, the coin is mine!";
            var buySwordText = "Better be a good sword!";
            var cantBeWorthText = "No sword is possibly worth that much.";
            var whatIsYourName = "What is your name?";

            //Inventory Item conditions
            var playerHasIronCoin = TinyDialogueManager.MakeHasItemConditionSimple(graph, IDs.ironCoinID, 1);
            var playerHasGoldBars = TinyDialogueManager.MakeHasItemConditionSimple(graph, IDs.goldIngotID, 10);


            //Player Choices
            var playerRespondToAllMenMustDie = TinyDialogueManager.MakeMultipleChoiceNode(graph, new string[] { allMenMustDieText, allMenMustServeText, exitDialogueWithInsult });
            var playerCanShowCoinOrRefuse = TinyDialogueManager.MakeMultipleChoiceNode(graph, new string[] { whatCoinText, showCoinText, hideCoinText, whatIsYourName });
            var playerCanNotShowCoinOrRefuse = TinyDialogueManager.MakeMultipleChoiceNode(graph, new string[] { whatCoinText, hideCoinText, whatIsYourName });

            var playerCanBuyOrRefuse = TinyDialogueManager.MakeMultipleChoiceNode(graph, new string[] { buySwordText, exitDialogueWithInsult });
            var playerCanNotBuyOrRefuse = TinyDialogueManager.MakeMultipleChoiceNode(graph, new string[] { cantBeWorthText, exitDialogueWithInsult });

            if (rpcMeta == "slums")
            {
                // player must respond "all men must serve"
                graph.primeNode = npcStatesAllMenMustDie;
                TinyDialogueManager.ChainNodes(             graph, new Node[] { npcStatesAllMenMustDie, playerRespondToAllMenMustDie });
                TinyDialogueManager.ConnectMultipleChoices( graph, playerRespondToAllMenMustDie, new Node[] { npcDispleased, npcRequestsToSeeCoin, npcDispleased });

                //player must show iron coin
                TinyDialogueManager.ChainNodes(             graph, new Node[] { npcRequestsToSeeCoin, playerHasIronCoin });
                TinyDialogueManager.ConnectMultipleChoices( graph, playerHasIronCoin, new Node[] { playerCanShowCoinOrRefuse, playerCanNotShowCoinOrRefuse});
                TinyDialogueManager.ConnectMultipleChoices( graph, playerCanShowCoinOrRefuse, new Node[] { npcDispleased, offerToSell, npcDispleased, aManHasNoName });
                TinyDialogueManager.ConnectMultipleChoices( graph, playerCanNotShowCoinOrRefuse, new Node[] { npcDispleased, npcDispleased, aManHasNoName });
                
                //player can buy
                TinyDialogueManager.ChainNodes(             graph, new Node[] { offerToSell, playerHasGoldBars });
                TinyDialogueManager.ConnectMultipleChoices( graph, playerHasGoldBars, new Node[] { playerCanBuyOrRefuse, playerCanNotBuyOrRefuse });
                TinyDialogueManager.ConnectMultipleChoices( graph, playerCanBuyOrRefuse, new Node[] { excellentChoice, npcDispleased });
                TinyDialogueManager.ConnectMultipleChoices( graph, playerCanNotBuyOrRefuse, new Node[] { npcDispleased, npcDispleased });
                
                //player is rewarded
                TinyDialogueManager.ChainNodes(             graph, new Node[] { excellentChoice, giveUpIronCoin, giveUpGoldBar, giveFaraamLongsword });
                
            }

            var obj = instanceGameObject.transform.parent.gameObject;
            obj.SetActive(true);

            return instanceCharacter;
        }
    }
}