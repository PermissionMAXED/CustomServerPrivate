using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Network.EventData;
using BAPBAP.Player;
using BAPBAP.Systems;
using BAPBAP.UI;
using Mirror.Discovery;
using UnityEngine;

namespace Mirror
{
	[StructLayout((LayoutKind)3, CharSet = CharSet.Auto)]
	public static class GeneratedNetworkCode
	{
		public static TimeSnapshotMessage _Read_Mirror_002ETimeSnapshotMessage(NetworkReader reader)
		{
			return default(TimeSnapshotMessage);
		}

		public static void _Write_Mirror_002ETimeSnapshotMessage(NetworkWriter writer, TimeSnapshotMessage value)
		{
		}

		public static ReadyMessage _Read_Mirror_002EReadyMessage(NetworkReader reader)
		{
			return default(ReadyMessage);
		}

		public static void _Write_Mirror_002EReadyMessage(NetworkWriter writer, ReadyMessage value)
		{
		}

		public static NotReadyMessage _Read_Mirror_002ENotReadyMessage(NetworkReader reader)
		{
			return default(NotReadyMessage);
		}

		public static void _Write_Mirror_002ENotReadyMessage(NetworkWriter writer, NotReadyMessage value)
		{
		}

		public static AddPlayerMessage _Read_Mirror_002EAddPlayerMessage(NetworkReader reader)
		{
			return default(AddPlayerMessage);
		}

		public static void _Write_Mirror_002EAddPlayerMessage(NetworkWriter writer, AddPlayerMessage value)
		{
		}

		public static SceneMessage _Read_Mirror_002ESceneMessage(NetworkReader reader)
		{
			return default(SceneMessage);
		}

		public static SceneOperation _Read_Mirror_002ESceneOperation(NetworkReader reader)
		{
			return default(SceneOperation);
		}

		public static void _Write_Mirror_002ESceneMessage(NetworkWriter writer, SceneMessage value)
		{
		}

		public static void _Write_Mirror_002ESceneOperation(NetworkWriter writer, SceneOperation value)
		{
		}

		public static CommandMessage _Read_Mirror_002ECommandMessage(NetworkReader reader)
		{
			return default(CommandMessage);
		}

		public static void _Write_Mirror_002ECommandMessage(NetworkWriter writer, CommandMessage value)
		{
		}

		public static RpcMessage _Read_Mirror_002ERpcMessage(NetworkReader reader)
		{
			return default(RpcMessage);
		}

		public static void _Write_Mirror_002ERpcMessage(NetworkWriter writer, RpcMessage value)
		{
		}

		public static SpawnMessage _Read_Mirror_002ESpawnMessage(NetworkReader reader)
		{
			return default(SpawnMessage);
		}

		public static void _Write_Mirror_002ESpawnMessage(NetworkWriter writer, SpawnMessage value)
		{
		}

		public static ChangeOwnerMessage _Read_Mirror_002EChangeOwnerMessage(NetworkReader reader)
		{
			return default(ChangeOwnerMessage);
		}

		public static void _Write_Mirror_002EChangeOwnerMessage(NetworkWriter writer, ChangeOwnerMessage value)
		{
		}

		public static ObjectSpawnStartedMessage _Read_Mirror_002EObjectSpawnStartedMessage(NetworkReader reader)
		{
			return default(ObjectSpawnStartedMessage);
		}

		public static void _Write_Mirror_002EObjectSpawnStartedMessage(NetworkWriter writer, ObjectSpawnStartedMessage value)
		{
		}

		public static ObjectSpawnFinishedMessage _Read_Mirror_002EObjectSpawnFinishedMessage(NetworkReader reader)
		{
			return default(ObjectSpawnFinishedMessage);
		}

		public static void _Write_Mirror_002EObjectSpawnFinishedMessage(NetworkWriter writer, ObjectSpawnFinishedMessage value)
		{
		}

		public static ObjectDestroyMessage _Read_Mirror_002EObjectDestroyMessage(NetworkReader reader)
		{
			return default(ObjectDestroyMessage);
		}

		public static void _Write_Mirror_002EObjectDestroyMessage(NetworkWriter writer, ObjectDestroyMessage value)
		{
		}

		public static ObjectHideMessage _Read_Mirror_002EObjectHideMessage(NetworkReader reader)
		{
			return default(ObjectHideMessage);
		}

		public static void _Write_Mirror_002EObjectHideMessage(NetworkWriter writer, ObjectHideMessage value)
		{
		}

		public static EntityStateMessage _Read_Mirror_002EEntityStateMessage(NetworkReader reader)
		{
			return default(EntityStateMessage);
		}

		public static void _Write_Mirror_002EEntityStateMessage(NetworkWriter writer, EntityStateMessage value)
		{
		}

		public static NetworkPingMessage _Read_Mirror_002ENetworkPingMessage(NetworkReader reader)
		{
			return default(NetworkPingMessage);
		}

		public static void _Write_Mirror_002ENetworkPingMessage(NetworkWriter writer, NetworkPingMessage value)
		{
		}

		public static NetworkPongMessage _Read_Mirror_002ENetworkPongMessage(NetworkReader reader)
		{
			return default(NetworkPongMessage);
		}

		public static void _Write_Mirror_002ENetworkPongMessage(NetworkWriter writer, NetworkPongMessage value)
		{
		}

		public static ServerRequest _Read_Mirror_002EDiscovery_002EServerRequest(NetworkReader reader)
		{
			return default(ServerRequest);
		}

		public static void _Write_Mirror_002EDiscovery_002EServerRequest(NetworkWriter writer, ServerRequest value)
		{
		}

		public static ServerResponse _Read_Mirror_002EDiscovery_002EServerResponse(NetworkReader reader)
		{
			return default(ServerResponse);
		}

		public static void _Write_Mirror_002EDiscovery_002EServerResponse(NetworkWriter writer, ServerResponse value)
		{
		}

		public static StateSyncMessage _Read_BAPBAP_002ESystems_002EStateSyncMessage(NetworkReader reader)
		{
			return default(StateSyncMessage);
		}

		public static void _Write_BAPBAP_002ESystems_002EStateSyncMessage(NetworkWriter writer, StateSyncMessage value)
		{
		}

		public static GameNetworkManager.ClInitMsg _Read_BAPBAP_002ENetwork_002EGameNetworkManager_002FClInitMsg(NetworkReader reader)
		{
			return default(GameNetworkManager.ClInitMsg);
		}

		public static void _Write_BAPBAP_002ENetwork_002EGameNetworkManager_002FClInitMsg(NetworkWriter writer, GameNetworkManager.ClInitMsg value)
		{
		}

		public static GameNetworkManager.SvInitMsg _Read_BAPBAP_002ENetwork_002EGameNetworkManager_002FSvInitMsg(NetworkReader reader)
		{
			return default(GameNetworkManager.SvInitMsg);
		}

		public static int[] _Read_System_002EInt32_005B_005D(NetworkReader reader)
		{
			return null;
		}

		public static void _Write_BAPBAP_002ENetwork_002EGameNetworkManager_002FSvInitMsg(NetworkWriter writer, GameNetworkManager.SvInitMsg value)
		{
		}

		public static void _Write_System_002EInt32_005B_005D(NetworkWriter writer, int[] value)
		{
		}

		public static void _Write_BAPBAP_002EGame_002EBotDifficulty(NetworkWriter writer, BotDifficulty value)
		{
		}

		public static BotDifficulty _Read_BAPBAP_002EGame_002EBotDifficulty(NetworkReader reader)
		{
			return default(BotDifficulty);
		}

		public static void _Write_BAPBAP_002EGame_002EGameModes(NetworkWriter writer, GameModes value)
		{
		}

		public static GameModes _Read_BAPBAP_002EGame_002EGameModes(NetworkReader reader)
		{
			return default(GameModes);
		}

		public static void _Write_BAPBAP_002EPlayer_002EPlayerManager_002FDownedState(NetworkWriter writer, PlayerManager.DownedState value)
		{
		}

		public static PlayerManager.DownedState _Read_BAPBAP_002EPlayer_002EPlayerManager_002FDownedState(NetworkReader reader)
		{
			return default(PlayerManager.DownedState);
		}

		public static void _Write_BAPBAP_002ELocal_002ECommand(NetworkWriter writer, Command value)
		{
		}

		public static Command _Read_BAPBAP_002ELocal_002ECommand(NetworkReader reader)
		{
			return null;
		}

		public static void _Write_BAPBAP_002EPlayer_002EPlayerPing_002FPositionType(NetworkWriter writer, PlayerPing.PositionType value)
		{
		}

		public static PlayerPing.PositionType _Read_BAPBAP_002EPlayer_002EPlayerPing_002FPositionType(NetworkReader reader)
		{
			return default(PlayerPing.PositionType);
		}

		public static void _Write_BAPBAP_002EPlayer_002EPlayerPing_002FCharType(NetworkWriter writer, PlayerPing.CharType value)
		{
		}

		public static PlayerPing.CharType _Read_BAPBAP_002EPlayer_002EPlayerPing_002FCharType(NetworkReader reader)
		{
			return default(PlayerPing.CharType);
		}

		public static void _Write_BAPBAP_002EPlayer_002EPlayerSpectate_002FCycleAction(NetworkWriter writer, PlayerSpectate.CycleAction value)
		{
		}

		public static PlayerSpectate.CycleAction _Read_BAPBAP_002EPlayer_002EPlayerSpectate_002FCycleAction(NetworkReader reader)
		{
			return default(PlayerSpectate.CycleAction);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(NetworkWriter writer, List<int> value)
		{
		}

		public static List<int> _Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(NetworkReader reader)
		{
			return null;
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CBAPBAP_002EGame_002EGameMode_002FEntityMapIconSync_003E(NetworkWriter writer, List<GameMode.EntityMapIconSync> value)
		{
		}

		public static void _Write_BAPBAP_002EGame_002EGameMode_002FEntityMapIconSync(NetworkWriter writer, GameMode.EntityMapIconSync value)
		{
		}

		public static List<GameMode.EntityMapIconSync> _Read_System_002ECollections_002EGeneric_002EList_00601_003CBAPBAP_002EGame_002EGameMode_002FEntityMapIconSync_003E(NetworkReader reader)
		{
			return null;
		}

		public static GameMode.EntityMapIconSync _Read_BAPBAP_002EGame_002EGameMode_002FEntityMapIconSync(NetworkReader reader)
		{
			return default(GameMode.EntityMapIconSync);
		}

		public static void _Write_BAPBAP_002ENetwork_002EEventData_002ESfxEventData(NetworkWriter writer, SfxEventData value)
		{
		}

		public static void _Write_BAPBAP_002ENetwork_002EEventData_002ESfxEventAction(NetworkWriter writer, SfxEventAction value)
		{
		}

		public static void _Write_BAPBAP_002ELocal_002ESfxTarget(NetworkWriter writer, SfxTarget value)
		{
		}

		public static void _Write_BAPBAP_002ELocal_002ESfxTeamTarget(NetworkWriter writer, SfxTeamTarget value)
		{
		}

		public static SfxEventData _Read_BAPBAP_002ENetwork_002EEventData_002ESfxEventData(NetworkReader reader)
		{
			return default(SfxEventData);
		}

		public static SfxEventAction _Read_BAPBAP_002ENetwork_002EEventData_002ESfxEventAction(NetworkReader reader)
		{
			return default(SfxEventAction);
		}

		public static SfxTarget _Read_BAPBAP_002ELocal_002ESfxTarget(NetworkReader reader)
		{
			return default(SfxTarget);
		}

		public static SfxTeamTarget _Read_BAPBAP_002ELocal_002ESfxTeamTarget(NetworkReader reader)
		{
			return default(SfxTeamTarget);
		}

		public static void _Write_BAPBAP_002ELocal_002EAugmentManager_002FSelectionData_002FSelectionType(NetworkWriter writer, AugmentManager.SelectionData.SelectionType value)
		{
		}

		public static AugmentManager.SelectionData.SelectionType _Read_BAPBAP_002ELocal_002EAugmentManager_002FSelectionData_002FSelectionType(NetworkReader reader)
		{
			return default(AugmentManager.SelectionData.SelectionType);
		}

		public static void _Write_BAPBAP_002ENetwork_002EQueueMatchedData(NetworkWriter writer, QueueMatchedData value)
		{
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CBAPBAP_002ENetwork_002EMatchmakingPlayerData_003E(NetworkWriter writer, List<MatchmakingPlayerData> value)
		{
		}

		public static void _Write_BAPBAP_002ENetwork_002EMatchmakingPlayerData(NetworkWriter writer, MatchmakingPlayerData value)
		{
		}

		public static QueueMatchedData _Read_BAPBAP_002ENetwork_002EQueueMatchedData(NetworkReader reader)
		{
			return null;
		}

		public static List<MatchmakingPlayerData> _Read_System_002ECollections_002EGeneric_002EList_00601_003CBAPBAP_002ENetwork_002EMatchmakingPlayerData_003E(NetworkReader reader)
		{
			return null;
		}

		public static MatchmakingPlayerData _Read_BAPBAP_002ENetwork_002EMatchmakingPlayerData(NetworkReader reader)
		{
			return null;
		}

		public static void _Write_BAPBAP_002EGame_002EPreMatchManager_002FPreMatchState(NetworkWriter writer, PreMatchManager.PreMatchState value)
		{
		}

		public static PreMatchManager.PreMatchState _Read_BAPBAP_002EGame_002EPreMatchManager_002FPreMatchState(NetworkReader reader)
		{
			return default(PreMatchManager.PreMatchState);
		}

		public static void _Write_BAPBAP_002EUI_002EUIManager_002FEmotionState(NetworkWriter writer, UIManager.EmotionState value)
		{
		}

		public static UIManager.EmotionState _Read_BAPBAP_002EUI_002EUIManager_002FEmotionState(NetworkReader reader)
		{
			return default(UIManager.EmotionState);
		}

		public static void _Write_BAPBAP_002EUI_002EUIPopUp_002FPointType(NetworkWriter writer, UIPopUp.PointType value)
		{
		}

		public static UIPopUp.PointType _Read_BAPBAP_002EUI_002EUIPopUp_002FPointType(NetworkReader reader)
		{
			return default(UIPopUp.PointType);
		}

		public static void _Write_BAPBAP_002ELocal_002EVfxTarget(NetworkWriter writer, VfxTarget value)
		{
		}

		public static VfxTarget _Read_BAPBAP_002ELocal_002EVfxTarget(NetworkReader reader)
		{
			return default(VfxTarget);
		}

		public static void _Write_BAPBAP_002ELocal_002ESFXData(NetworkWriter writer, SFXData value)
		{
		}

		public static void _Write_BAPBAP_002ELocal_002EAudioManager_002FSFX(NetworkWriter writer, AudioManager.SFX value)
		{
		}

		public static SFXData _Read_BAPBAP_002ELocal_002ESFXData(NetworkReader reader)
		{
			return null;
		}

		public static AudioManager.SFX _Read_BAPBAP_002ELocal_002EAudioManager_002FSFX(NetworkReader reader)
		{
			return default(AudioManager.SFX);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void InitReadWriters()
		{
		}
	}
}
