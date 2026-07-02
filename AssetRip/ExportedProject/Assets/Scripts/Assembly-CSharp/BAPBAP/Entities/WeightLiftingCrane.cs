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
	public class WeightLiftingCrane : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CDropWeightCoroutine_003Ed__80 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WeightLiftingCrane _003C_003E4__this;

			public int teamId;

			public int ownerPlayerId;

			[NonSerialized]
			public Quaternion _003CstartRot_003E5__2;

			[NonSerialized]
			public Quaternion _003CdropRot_003E5__3;

			[NonSerialized]
			public float _003Ctimer_003E5__4;

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
			public _003CDropWeightCoroutine_003Ed__80(int _003C_003E1__state)
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

		[CompilerGenerated]
		public sealed class _003CWaitToClearOperator_003Ed__79 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WeightLiftingCrane _003C_003E4__this;

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
			public _003CWaitToClearOperator_003Ed__79(int _003C_003E1__state)
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
		public Animator animator;

		[SerializeField]
		public TextMesh cdTimerText;

		[SerializeField]
		public GameObject panelActiveObj;

		[SerializeField]
		public Transform cranePivot;

		[SerializeField]
		public Transform dropLandingTransform;

		[SerializeField]
		public Transform dropObject;

		[SerializeField]
		public AudioSource dropSuccessAudioSource;

		[SerializeField]
		public IndicatorMouse mouseIndicator;

		[SerializeField]
		public AudioSource voiceSource;

		[SerializeField]
		public AudioSource extraSource;

		[SerializeField]
		[Header("Indicators")]
		public GameObject visibleIndicatorPrefab;

		[SerializeField]
		public GameObject visibleIndicatorEnemyPrefab;

		[Header("Properties")]
		[SerializeField]
		public float activateCastDuration;

		[SerializeField]
		public float dropWeightCastDuration;

		[Min(0.01f)]
		[SerializeField]
		public float turnDuration;

		[SerializeField]
		[Min(0f)]
		public float dropDuration;

		[SerializeField]
		[Min(0f)]
		public float waitResetOperatorDuration;

		[SerializeField]
		[Min(0f)]
		public float cooldownDuration;

		[SerializeField]
		public CommandId targetInputAbility;

		[SerializeField]
		public float dropRadius;

		[SerializeField]
		public float rangeRadius;

		[SerializeField]
		public float visibilityRadius;

		[SerializeField]
		public float zoomOutMultiplier;

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
		public float hitboxActivateTime;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public GameObject wallBlockPrefab;

		[SerializeField]
		[Header("Animation")]
		public string animUseCraneState;

		[SerializeField]
		public string animDropWeightState;

		[SerializeField]
		public string animResetState;

		[SerializeField]
		public AnimationCurve rotationCurve;

		[Header("Interactable Inputs Info")]
		[SerializeField]
		public UIGameMode.InteractableInputInfo[] interactableInputInfo;

		[Header("Translation Keys")]
		[SerializeField]
		public string interactTranslationKey;

		[SerializeField]
		public string dropWeightTranslationKey;

		[SerializeField]
		public string inCooldownTranslationKey;

		[SerializeField]
		public string alreadyOperatedTranslationKey;

		[Header("Sfx")]
		[SerializeField]
		public AudioClipData sfxThree;

		[SerializeField]
		public AudioClipData sfxTwo;

		[SerializeField]
		public AudioClipData sfxOne;

		[SerializeField]
		public AudioClipData sfxReady;

		[SerializeField]
		public AudioClipData sfxActivating;

		[SerializeField]
		public AudioClipData sfxSelect;

		[SerializeField]
		public AudioClip sfxCraneStart;

		[SerializeField]
		public AudioClip sfxCraneMove;

		[SerializeField]
		public AudioClip sfxCraneStop;

		[SerializeField]
		public AudioClipData targetHitAudioClipData;

		[SyncVar(hook = "OnCooldownTimerSyncChanged")]
		[NonSerialized]
		public short cooldownTimerSync;

		[SyncVar(hook = "OnCurrentCharChanged")]
		[NonSerialized]
		public EntityManager currentChar;

		[NonSerialized]
		public bool isInUse;

		[NonSerialized]
		public float cooldownTime;

		[NonSerialized]
		public bool _isClient;

		[NonSerialized]
		public bool playerTargetHit;

		[NonSerialized]
		public string interactStr;

		[NonSerialized]
		public string dropWeightStr;

		[NonSerialized]
		public string inCooldownStr;

		[NonSerialized]
		public string alreadyOperatedStr;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___currentCharNetId;

		public Action<short, short> _Mirror_SyncVarHookDelegate_cooldownTimerSync;

		public Action<EntityManager, EntityManager> _Mirror_SyncVarHookDelegate_currentChar;

		public short NetworkcooldownTimerSync
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public EntityManager NetworkcurrentChar
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

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void OnDestroy()
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
		public void SvActivateCrane(EntityManager entity)
		{
		}

		[Server]
		public void SvDeactivateCrane(EntityManager entity)
		{
		}

		public void SvAddOperatorChar(EntityManager entity)
		{
		}

		public void SvResetOperatorChar()
		{
		}

		[Server]
		public void SvDropWeightCrane(EntityManager entity)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToClearOperator_003Ed__79))]
		public IEnumerator WaitToClearOperator()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDropWeightCoroutine_003Ed__80))]
		public IEnumerator DropWeightCoroutine(int teamId, int ownerPlayerId)
		{
			return null;
		}

		[Server]
		public void SpawnDropHitbox(int teamId, int ownerPlayerId)
		{
		}

		public void OnHitSuccess(EntityManager hittedEntity, HitboxBase hitbox)
		{
		}

		[ClientRpc]
		public void RpcOnUseCrane(EntityManager cM)
		{
		}

		[ClientRpc]
		public void RpcOnStopUseCrane()
		{
		}

		[ClientRpc]
		public void RpcOnStartDropWeight(Vector3 position, int teamId, int ownerId)
		{
		}

		[ClientRpc]
		public void RpcOnTargetHit(int teamId, Vector3 hitPosition)
		{
		}

		[ClientRpc]
		public void RpcOnDropWeight()
		{
		}

		public override void OnLocalAuthPlayerChanged(EntityManager entity, InteractableCollider slot)
		{
		}

		public void ClApplyAuth(EntityManager entity, bool instant = false)
		{
		}

		public void ClRemoveAuth(EntityManager entity, bool instant = false)
		{
		}

		public void ClUpdateCooldownTimer()
		{
		}

		public void OnCooldownTimerSyncChanged(short oldValue, short newValue)
		{
		}

		public void OnCurrentCharChanged(EntityManager oldValue, EntityManager newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnUseCrane__EntityManager(EntityManager cM)
		{
		}

		public static void InvokeUserCode_RpcOnUseCrane__EntityManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnStopUseCrane()
		{
		}

		public static void InvokeUserCode_RpcOnStopUseCrane(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnStartDropWeight__Vector3__Int32__Int32(Vector3 position, int teamId, int ownerId)
		{
		}

		public static void InvokeUserCode_RpcOnStartDropWeight__Vector3__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnTargetHit__Int32__Vector3(int teamId, Vector3 hitPosition)
		{
		}

		public static void InvokeUserCode_RpcOnTargetHit__Int32__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnDropWeight()
		{
		}

		public static void InvokeUserCode_RpcOnDropWeight(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static WeightLiftingCrane()
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
