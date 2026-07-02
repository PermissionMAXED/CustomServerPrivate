using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Network.EventData;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharPassives : NetworkBehaviour, INetworkPredicted
	{
		[CompilerGenerated]
		public sealed class _003CWaitToActivatePassive_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public CharPassives _003C_003E4__this;

			public int passiveId;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitToActivatePassive_003Ed__21(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIPassives uiPassives;

		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public PassiveManager passiveManager;

		[NonSerialized]
		public bool _isServer;

		[NonSerialized]
		public bool _isClient;

		[NonSerialized]
		public List<Passive> passives;

		[NonSerialized]
		public List<VFXStopParticles> vfxFollowElements;

		[NonSerialized]
		public float followFxSpreadAngle;

		[NonSerialized]
		public float followFxMaxTotalSpread;

		[NonSerialized]
		public bool initialized;

		[NonSerialized]
		public List<int> newPassiveIds;

		[NonSerialized]
		public List<Passive> nextPassives;

		[NonSerialized]
		public List<Passive> tmpPassives;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public Passive ActivatePassive(PassiveSO passive)
		{
			return null;
		}

		public Passive ActivatePassive(int passiveId)
		{
			return null;
		}

		public void DeactivatePassiveId(int passiveId)
		{
		}

		public void DeactivatePassiveAll(int passiveId)
		{
		}

		public void DeactivatePassive(Passive passiveInstance)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToActivatePassive_003Ed__21))]
		public IEnumerator WaitToActivatePassive(int passiveId)
		{
			return null;
		}

		public void OnDisable()
		{
		}

		public void OnDestroy()
		{
		}

		public void ClStartAuth()
		{
		}

		public void ClStopAuth()
		{
		}

		[Client]
		public void TryUpdateFollowVfxElements()
		{
		}

		public bool IsPassiveActive(int passiveId)
		{
			return false;
		}

		public int GetPassiveStacks(int passiveId)
		{
			return 0;
		}

		public Passive GetPassiveInstance(int passiveId)
		{
			return null;
		}

		public void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public void OnBonusHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public void OnAbilityTriggered(EntityManager cM, int abilityId)
		{
		}

		public void OnHealedTrigger(EntityManager cM)
		{
		}

		public void OnConsumeConsumableTrigger(EntityManager cM, int consumableItemId)
		{
		}

		public void OnItemsChanged(EntityManager cM)
		{
		}

		public void OnStatsChanged(bool added, ItemStat stat)
		{
		}

		public void OnHitTrigger(EntityManager hittedEntity, HitboxBase hitboxBase, int abilityId)
		{
		}

		public void OnDealtDamageTrigger(EntityManager otherCharManager, int damage, bool isCrit, Vector3 hitDir)
		{
		}

		public void OnDealtDamageInteractableTrigger(EntityManager otherEntityManager, int damage, bool isCrit, Vector3 hitDir)
		{
		}

		public void OnTakeDamageTrigger(int damage, Vector3 hitDir)
		{
		}

		public void OnImmuneDamageTrigger(int damage)
		{
		}

		public void OnKillTrigger(EntityManager otherCharManager)
		{
		}

		public void OnKilledTrigger(EntityManager killerCharManager)
		{
		}

		public void OnAssistTrigger(EntityManager otherCharManager, float timer)
		{
		}

		public void OnMinHpTrigger()
		{
		}

		public void OnPickUpTrigger()
		{
		}

		public void OnStatusEffectAppliedToEnemyTrigger(int statusEffectId, bool alreadyApplied)
		{
		}

		public void OnStatusEffectAppliedToSelfTrigger(int statusEffectId)
		{
		}

		public void OnCastCompleteTrigger()
		{
		}

		public void OnZoneEnter()
		{
		}

		public void OnZoneExit()
		{
		}

		public Vector3 ApplyInputDirModifications(Vector3 inputDir)
		{
			return default(Vector3);
		}

		[ClientRpc]
		public void RpcSpawnVfx(int passiveId, int vfxId, VfxTarget vfxTarget)
		{
		}

		[ClientRpc]
		public void RpcSpawnLoopVfx(int passiveId, int vfxId, VfxTarget vfxTarget)
		{
		}

		[ClientRpc]
		public void RpcDestroyLoopVfx(int passiveId, int id)
		{
		}

		[ClientRpc]
		public void RpcPlaySfx(SFXData sfxData)
		{
		}

		[ClientRpc]
		public void RpcPlaySfx(AudioManager.SFX sfxId, float volume, float randomPitch)
		{
		}

		[ClientRpc]
		public void RpcPlaySfxAuth(AudioManager.SFX sfxId, float volume, float randomPitch)
		{
		}

		[ClientRpc]
		public void RpcPlaySfx3D(SfxEventData sfxEventData, float distMultiplier, float minDist)
		{
		}

		[ClientRpc]
		public void RpcAddStack(int passiveId)
		{
		}

		[ClientRpc]
		public void RpcRemoveStacks(int passiveId, int numberToRemove)
		{
		}

		[ClientRpc]
		public void RpcCustomEvent(byte eventId, int passiveId)
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

		public void UserCode_RpcSpawnVfx__Int32__Int32__VfxTarget(int passiveId, int vfxId, VfxTarget vfxTarget)
		{
		}

		public static void InvokeUserCode_RpcSpawnVfx__Int32__Int32__VfxTarget(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnLoopVfx__Int32__Int32__VfxTarget(int passiveId, int vfxId, VfxTarget vfxTarget)
		{
		}

		public static void InvokeUserCode_RpcSpawnLoopVfx__Int32__Int32__VfxTarget(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyLoopVfx__Int32__Int32(int passiveId, int id)
		{
		}

		public static void InvokeUserCode_RpcDestroyLoopVfx__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPlaySfx__SFXData(SFXData sfxData)
		{
		}

		public static void InvokeUserCode_RpcPlaySfx__SFXData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPlaySfx__SFX__Single__Single(AudioManager.SFX sfxId, float volume, float randomPitch)
		{
		}

		public static void InvokeUserCode_RpcPlaySfx__SFX__Single__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPlaySfxAuth__SFX__Single__Single(AudioManager.SFX sfxId, float volume, float randomPitch)
		{
		}

		public static void InvokeUserCode_RpcPlaySfxAuth__SFX__Single__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPlaySfx3D__SfxEventData__Single__Single(SfxEventData sfxEventData, float distMultiplier, float minDist)
		{
		}

		public static void InvokeUserCode_RpcPlaySfx3D__SfxEventData__Single__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcAddStack__Int32(int passiveId)
		{
		}

		public static void InvokeUserCode_RpcAddStack__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcRemoveStacks__Int32__Int32(int passiveId, int numberToRemove)
		{
		}

		public static void InvokeUserCode_RpcRemoveStacks__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcCustomEvent__Byte__Int32(byte eventId, int passiveId)
		{
		}

		public static void InvokeUserCode_RpcCustomEvent__Byte__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static CharPassives()
		{
		}
	}
}
