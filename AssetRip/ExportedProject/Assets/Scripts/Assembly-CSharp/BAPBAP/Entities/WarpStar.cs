using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class WarpStar : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CWarpLockedCoroutine_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WarpStar _003C_003E4__this;

			public int teamId;

			public int ownerPlayerId;

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
			public _003CWarpLockedCoroutine_003Ed__54(int _003C_003E1__state)
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
		public FogOfWarController fowController;

		[NonSerialized]
		public CameraController camController;

		[Header("References")]
		[SerializeField]
		public TextMesh cdTimerText;

		[SerializeField]
		public Transform warpLandingTransform;

		[SerializeField]
		public Transform windowTransform;

		[SerializeField]
		public AudioSource dropSuccessAudioSource;

		[SerializeField]
		public IndicatorMouse mouseIndicator;

		[Header("Indicators")]
		[SerializeField]
		public GameObject visibleIndicatorPrefab;

		[SerializeField]
		public GameObject visibleIndicatorEnemyPrefab;

		[Header("Hitbox")]
		[SerializeField]
		public GameObject hitboxPrefab;

		[SerializeField]
		public int flatDamage;

		[SerializeField]
		public float percentHpDamage;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("Properties")]
		[SerializeField]
		public float warpLockDuration;

		[SerializeField]
		public float warpDuration;

		[SerializeField]
		public float enableCharacterDelay;

		[SerializeField]
		public float dropRadius;

		[SerializeField]
		public float rangeRadius;

		[SerializeField]
		public float cooldownDuration;

		[SerializeField]
		public float visibilityRadius;

		[SerializeField]
		public float zoomOutMultiplier;

		[SerializeField]
		[Header("Translation Keys")]
		public string interactTranslationKey;

		[SerializeField]
		public string warpTranslationKey;

		[SerializeField]
		public string inCooldownTranslationKey;

		[SerializeField]
		public string alreadyOperatedTranslationKey;

		[SyncVar(hook = "OnCurrentControllingCharChanged")]
		[NonSerialized]
		public EntityManager currentControllingChar;

		[SyncVar(hook = "OnIsInUseChanged")]
		[NonSerialized]
		public bool isInUse;

		[SyncVar(hook = "OnIsInCooldownChanged")]
		[NonSerialized]
		public bool isInCooldown;

		[SyncVar(hook = "OnCooldownChanged")]
		[NonSerialized]
		public float cooldownTime;

		[SyncVar(hook = "OnWarpTimerChanged")]
		[NonSerialized]
		public float warpTimer;

		[NonSerialized]
		public string interactStr;

		[NonSerialized]
		public string warpStr;

		[NonSerialized]
		public string inCooldownStr;

		[NonSerialized]
		public string alreadyOperatedStr;

		[NonSerialized]
		public bool lockedIn;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___currentControllingCharNetId;

		public Action<EntityManager, EntityManager> _Mirror_SyncVarHookDelegate_currentControllingChar;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isInUse;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isInCooldown;

		public Action<float, float> _Mirror_SyncVarHookDelegate_cooldownTime;

		public Action<float, float> _Mirror_SyncVarHookDelegate_warpTimer;

		public EntityManager NetworkcurrentControllingChar
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

		public bool NetworkisInUse
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

		public bool NetworkisInCooldown
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

		public float NetworkcooldownTime
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public float NetworkwarpTimer
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		public override void OnSlotExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void ClOnExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public void UIShowDropWeightWindow()
		{
		}

		public void UIShowCooldownWindow()
		{
		}

		public void UIShowCraneOperatedWindow()
		{
		}

		[Server]
		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		[Server]
		public void SvActivate(EntityManager entity)
		{
		}

		[Server]
		public void SvDeactivate(EntityManager entity)
		{
		}

		[Server]
		public void SvWarpLockedIn(EntityManager entity)
		{
		}

		public void SvSetControllingChar(EntityManager entity)
		{
		}

		public void SvResetOperatorChar(EntityManager entity)
		{
		}

		[IteratorStateMachine(typeof(_003CWarpLockedCoroutine_003Ed__54))]
		public IEnumerator WarpLockedCoroutine(int teamId, int ownerPlayerId)
		{
			return null;
		}

		[Server]
		public void SpawnDropHitbox(int teamId, int ownerPlayerId)
		{
		}

		[ClientRpc]
		public void RpcOnUseWarp()
		{
		}

		[ClientRpc]
		public void RpcOnStopUseCrane()
		{
		}

		[ClientRpc]
		public void RpcOnWarpLockedIn(Vector3 position, int teamId)
		{
		}

		[ClientRpc]
		public void RpcEnableCharacter(EntityManager e)
		{
		}

		[ClientRpc]
		public void RpcOnDropWeight()
		{
		}

		[ClientRpc]
		public void RpcSetVisibilityRadius(float playerId)
		{
		}

		[ClientRpc]
		public void RpcResetVisibilityRadius(float playerId)
		{
		}

		public void ClResetVisibilityRadius(float playerId)
		{
		}

		public void OnIsInUseChanged(bool oldValue, bool newValue)
		{
		}

		public void OnIsInCooldownChanged(bool oldValue, bool newValue)
		{
		}

		public void OnCooldownChanged(float oldValue, float newValue)
		{
		}

		public void OnWarpTimerChanged(float oldValue, float newValue)
		{
		}

		public void OnCurrentControllingCharChanged(EntityManager oldValue, EntityManager newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnUseWarp()
		{
		}

		public static void InvokeUserCode_RpcOnUseWarp(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnStopUseCrane()
		{
		}

		public static void InvokeUserCode_RpcOnStopUseCrane(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnWarpLockedIn__Vector3__Int32(Vector3 position, int teamId)
		{
		}

		public static void InvokeUserCode_RpcOnWarpLockedIn__Vector3__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcEnableCharacter__EntityManager(EntityManager e)
		{
		}

		public static void InvokeUserCode_RpcEnableCharacter__EntityManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnDropWeight()
		{
		}

		public static void InvokeUserCode_RpcOnDropWeight(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetVisibilityRadius__Single(float playerId)
		{
		}

		public static void InvokeUserCode_RpcSetVisibilityRadius__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcResetVisibilityRadius__Single(float playerId)
		{
		}

		public static void InvokeUserCode_RpcResetVisibilityRadius__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static WarpStar()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
