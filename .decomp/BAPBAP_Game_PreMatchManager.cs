using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Network;
using BAPBAP.Player;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Game;

public class PreMatchManager : NetworkBehaviour
{
	public enum PreMatchState
	{
		WaitingForPlayers,
		CharSelect,
		SpawnSelect,
		SpawnLock,
		InGame
	}

	[NonSerialized]
	public GameManager _gameManager;

	[NonSerialized]
	public UIPreMatch _uiPreMatch;

	[NonSerialized]
	public Dictionary<int, int> _currentSelectedCharacters;

	[SyncVar(hook = "OnStateChange")]
	public PreMatchState CurrentState;

	[SyncVar]
	public bool SpawnsLocked;

	[SyncVar]
	public int[] SpawnPointsPerTeam;

	public Action<PreMatchState, PreMatchState> _Mirror_SyncVarHookDelegate_CurrentState;

	public PreMatchState NetworkCurrentState
	{
		get
		{
			return default(PreMatchState);
		}
		[param: In]
		set
		{
		}
	}

	public bool NetworkSpawnsLocked
	{
		get
		{
			return false;
		}
		[param: In]
		set
		{
		}
	}

	public int[] NetworkSpawnPointsPerTeam
	{
		get
		{
			return null;
		}
		[param: In]
		set
		{
		}
	}

	public void Awake()
	{
	}

	public void SetupPreMatch()
	{
	}

	public void AssignSpawnLeaders()
	{
	}

	public void AssignCharacters()
	{
	}

	public void AssignSpawnLocations()
	{
	}

	public void SetState(PreMatchState state)
	{
	}

	public void OnStateChange(PreMatchState oldValue, PreMatchState newValue)
	{
	}

	public void UpdateToState()
	{
	}

	public void SubscribeToSyncEvents()
	{
	}

	[TargetRpc]
	public void TargetSetupPreMatch(NetworkConnectionToClient conn, QueueMatchedData qmd)
	{
	}

	[TargetRpc]
	public void TargetUpdatePreMatch(NetworkConnectionToClient conn, QueueMatchedData qmd)
	{
	}

	public void TrySelectCharacter(PlayerManager player, int requestedCharId)
	{
	}

	public void TryLockCharacter(PlayerManager player)
	{
	}

	public void TrySelectSpawnLocation(PlayerManager player, Vector2 spawnLocation)
	{
	}

	public void OnLocalPlayerCharacterChanged()
	{
	}

	public void OnTeammateCharacterChanged(PlayerManager teammate)
	{
	}

	public void OnLocalPlayerCharacterLocked()
	{
	}

	public void OnTeammateCharacterLocked(PlayerManager teammate)
	{
	}

	public override bool Weaved()
	{
		return false;
	}

	public void UserCode_TargetSetupPreMatch__NetworkConnectionToClient__QueueMatchedData(NetworkConnectionToClient conn, QueueMatchedData qmd)
	{
	}

	public static void InvokeUserCode_TargetSetupPreMatch__NetworkConnectionToClient__QueueMatchedData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_TargetUpdatePreMatch__NetworkConnectionToClient__QueueMatchedData(NetworkConnectionToClient conn, QueueMatchedData qmd)
	{
	}

	public static void InvokeUserCode_TargetUpdatePreMatch__NetworkConnectionToClient__QueueMatchedData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	static PreMatchManager()
	{
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
	}
}
