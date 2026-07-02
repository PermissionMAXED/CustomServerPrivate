using System;
using System.Text;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Player;
using BAPBAP.UI;
using FMOD.Studio;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharDowned : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharAbilities charAbilities;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public EntityMovement charMove;

		[NonSerialized]
		public CharFX charFx;

		[NonSerialized]
		public CharInteract charInteract;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public FMODManager fmodManager;

		[Header("Configs")]
		[SerializeField]
		[Range(0f, 1f)]
		public float reviveHealPercent;

		[Range(0f, 1f)]
		[SerializeField]
		public float executeHealPercent;

		[Min(0.01f)]
		[SerializeField]
		public float downedTime;

		[Min(0f)]
		[SerializeField]
		public float ghostDelay;

		[SerializeField]
		[Header("References")]
		public GameObject downedMesh;

		[Header("Prefabs")]
		[SerializeField]
		public GameObject downedStationPrefab;

		[Header("FX Prefabs")]
		[SerializeField]
		public GameObject finisherCompleteVfxPrefab;

		[SerializeField]
		public GameObject reviveCompleteVfxPrefab;

		[NonSerialized]
		public DownedStation currentDStation;

		[NonSerialized]
		public EntityManager killerCharManager;

		[NonSerialized]
		public UIHpBar hpBar;

		[NonSerialized]
		public MeshRenderer ghostMeshRenderer;

		[NonSerialized]
		public bool spawnedTombstone;

		[NonSerialized]
		public float ghostDelayTime;

		[NonSerialized]
		public bool respawning;

		[NonSerialized]
		public EventInstance clSnapshotInstance;

		[NonSerialized]
		public PlayerManager.DownedState downedState;

		[NonSerialized]
		public float currentDownedTime;

		[NonSerialized]
		public bool ghostSpawned;

		public bool IsDowned => false;

		public PlayerManager.DownedState DownedState => default(PlayerManager.DownedState);

		public bool GhostSpawned => false;

		public GameObject DownedMeshObj => null;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void FixedUpdate()
		{
		}

		public void OnDowned(EntityManager _killerCharManager)
		{
		}

		[Server]
		public void SetDowned(bool _isDowned)
		{
		}

		public void OnDownedEvent()
		{
		}

		public void SetDownedState(PlayerManager.DownedState newDownedState)
		{
		}

		public void ReviveChar(bool applyFullHeal = false)
		{
		}

		public void ExecuteChar(EntityManager otherChar)
		{
		}

		[Server]
		public bool TryKillDownedTeam()
		{
			return false;
		}

		[Server]
		public void KillChar()
		{
		}

		public void SetDownedStationActive(bool isActive)
		{
		}

		public void DestroyCurrentDownedStation()
		{
		}

		public GameObject GetCurrentDownedStationInteractableGameObject()
		{
			return null;
		}

		public void SetTeam(bool isAlly)
		{
		}

		public void ClSetDownedState()
		{
		}

		public void ClGhostSetSpawned(bool isSpawned)
		{
		}

		public void ClStartAuth()
		{
		}

		public void ClStopAuth()
		{
		}

		public void ClSetAuthDowned(bool _isDowned)
		{
		}

		[ClientRpc]
		public void RpcOnCharDowned()
		{
		}

		[ClientRpc]
		public void RpcSpawnFinisherCompleteVfx()
		{
		}

		[ClientRpc]
		public void RpcSpawnReviveCompleteVfx()
		{
		}

		[ClientRpc]
		public void RpcSetCurrentDownedStation(DownedStation dStation)
		{
		}

		public void SvTargetOnTeammateDowned()
		{
		}

		public void SvTargetRpcSyncDownedTime(float normTime)
		{
		}

		public void OnDownedStateChanged()
		{
		}

		public void OnGhostSpawnedChanged()
		{
		}

		public void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnCharDowned()
		{
		}

		public static void InvokeUserCode_RpcOnCharDowned(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnFinisherCompleteVfx()
		{
		}

		public static void InvokeUserCode_RpcSpawnFinisherCompleteVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnReviveCompleteVfx()
		{
		}

		public static void InvokeUserCode_RpcSpawnReviveCompleteVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetCurrentDownedStation__DownedStation(DownedStation dStation)
		{
		}

		public static void InvokeUserCode_RpcSetCurrentDownedStation__DownedStation(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static CharDowned()
		{
		}
	}
}
