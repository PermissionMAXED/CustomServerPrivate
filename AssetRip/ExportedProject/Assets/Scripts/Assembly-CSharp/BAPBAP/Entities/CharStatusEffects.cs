using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharStatusEffects : NetworkBehaviour, INetworkPredicted
	{
		public struct StatusEffectSyncObj
		{
			public int id;

			public float duration;

			public float multiplier;
		}

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public EntityMovement charMove;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIPopUp uiPopUp;

		[NonSerialized]
		public StatusEffectManager statusEffectManager;

		[NonSerialized]
		public List<StatusEffect> statusEffects;

		[NonSerialized]
		public int immuneToStatusEffects;

		[NonSerialized]
		public int immuneToSlows;

		[NonSerialized]
		public int immuneToMovementDebuffs;

		[SerializeField]
		public bool ignoreAllStatusEffects;

		[NonSerialized]
		public List<StatusEffectSyncObj> newStatusEffects;

		[NonSerialized]
		public List<StatusEffect> nextStatusEffectsList;

		[NonSerialized]
		public List<StatusEffect> tmpStatusEffects;

		public void PreAwake(EntityManager e)
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void ManagedUpdate()
		{
		}

		[Server]
		public void ActivateStatusEffect(StatusEffectInfo statusEffectInfo, int otherPlayerId = -1, Vector3 direction = default(Vector3), bool forceApply = false)
		{
		}

		[Server]
		public void ActivateStatusEffect(int statusEffectId, float duration, float multiplier = 1f, int otherPlayerId = -1, Vector3 direction = default(Vector3), bool forceApply = false)
		{
		}

		[Server]
		public void DeactivateStatusEffect(int statusEffectId)
		{
		}

		[Server]
		public void ForceDeactivateAtDuration(int statusEffectId, float targetDuration)
		{
		}

		public void SvRemoveAllStatusEffects()
		{
		}

		public void ClRemoveAllStatusEffects()
		{
		}

		public void Cleanse()
		{
		}

		public float GetStatusEffectDuration(int id)
		{
			return 0f;
		}

		public SE_Shield FindOldestShield()
		{
			return null;
		}

		public void OnShieldDamaged(int dmg)
		{
		}

		public void RemoveShield(SE_Shield shield, int leftOverDmg)
		{
		}

		public SE_Shield GetShield(float multiplier)
		{
			return null;
		}

		public Vector3 ApplyInputDirModifications(Vector3 inputDir)
		{
			return default(Vector3);
		}

		public bool IsStatusEffectApplied(int id)
		{
			return false;
		}

		public float[] GetMultipliersOfEffect(int id)
		{
			return null;
		}

		public bool IsNonImmuneStatusEffect(int id)
		{
			return false;
		}

		public bool isMovementDebuff(int id)
		{
			return false;
		}

		public int GetStatusEffectPriority(int statusEffectId)
		{
			return 0;
		}

		public bool CanEntityInteractWithStatusEffect(int id)
		{
			return false;
		}

		public bool TryFindStatusEffect<T>(out T se)
		{
			se = default(T);
			return false;
		}

		public int GetActivatedCount(int statusEffectId)
		{
			return 0;
		}

		[TargetRpc]
		public void TargetRpcShowStatusEffectPopUp(NetworkConnection conn, int statusEffectId)
		{
		}

		[ClientRpc]
		public void RpcShowStatusEffectPopUp(int statusEffectId)
		{
		}

		[ClientRpc]
		public void RpcShowStatusEffectHpBarProgress(int statusEffectId, float duration)
		{
		}

		[ClientRpc]
		public void RpcRemoveStatusEffectHpBarProgress(int statusEffectId)
		{
		}

		[TargetRpc]
		public void TargetRpcSetHpBarStackProgress(NetworkConnection conn, float normProgress)
		{
		}

		[TargetRpc]
		public void TargetRpcSetHpBarStackDisabled(NetworkConnection conn)
		{
		}

		[ClientRpc]
		public void RpcSpawnCementedVfx()
		{
		}

		[ClientRpc]
		public void RpcOnCementedMove()
		{
		}

		public void ShowStatusEffectHpBar(int statusEffectId, float duration)
		{
		}

		public void UpdateStatusEffectHpBar(int statusEffectId, float totalDuration, float duration)
		{
		}

		public void RemoveStatusEffectHpBar(int statusEffectId, bool removeAll = false)
		{
		}

		public void ShowStatusEffectPopUp(int statusEffectId)
		{
		}

		[ClientRpc]
		public void RpcSpawnStatusText(string status, UIPopUp.PointType color)
		{
		}

		public void SpawnStatusText(string status, UIPopUp.PointType color = UIPopUp.PointType.Critical)
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

		public void UserCode_TargetRpcShowStatusEffectPopUp__NetworkConnection__Int32(NetworkConnection conn, int statusEffectId)
		{
		}

		public static void InvokeUserCode_TargetRpcShowStatusEffectPopUp__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcShowStatusEffectPopUp__Int32(int statusEffectId)
		{
		}

		public static void InvokeUserCode_RpcShowStatusEffectPopUp__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcShowStatusEffectHpBarProgress__Int32__Single(int statusEffectId, float duration)
		{
		}

		public static void InvokeUserCode_RpcShowStatusEffectHpBarProgress__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcRemoveStatusEffectHpBarProgress__Int32(int statusEffectId)
		{
		}

		public static void InvokeUserCode_RpcRemoveStatusEffectHpBarProgress__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcSetHpBarStackProgress__NetworkConnection__Single(NetworkConnection conn, float normProgress)
		{
		}

		public static void InvokeUserCode_TargetRpcSetHpBarStackProgress__NetworkConnection__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcSetHpBarStackDisabled__NetworkConnection(NetworkConnection conn)
		{
		}

		public static void InvokeUserCode_TargetRpcSetHpBarStackDisabled__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnCementedVfx()
		{
		}

		public static void InvokeUserCode_RpcSpawnCementedVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnCementedMove()
		{
		}

		public static void InvokeUserCode_RpcOnCementedMove(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnStatusText__String__PointType(string status, UIPopUp.PointType color)
		{
		}

		public static void InvokeUserCode_RpcSpawnStatusText__String__PointType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static CharStatusEffects()
		{
		}
	}
}
