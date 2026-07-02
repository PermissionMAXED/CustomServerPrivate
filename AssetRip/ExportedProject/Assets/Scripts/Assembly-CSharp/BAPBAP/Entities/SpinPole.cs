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
	public class SpinPole : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CSpinPush_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public SpinPole _003C_003E4__this;

			public EntityManager entity;

			[NonSerialized]
			public float _003CtimeElapsed_003E5__2;

			[NonSerialized]
			public bool _003Cdone_003E5__3;

			[NonSerialized]
			public float _003CchargeFactorDistance_003E5__4;

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
			public _003CSpinPush_003Ed__60(int _003C_003E1__state)
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

		[SerializeField]
		[Header("References")]
		public TextMesh cdTimerText;

		[SerializeField]
		public Transform warpLandingTransform;

		[SerializeField]
		public Transform windowTransform;

		[SerializeField]
		public AudioSource dropSuccessAudioSource;

		[Header("Indicator")]
		[SerializeField]
		public IndicatorDirectional mouseIndicator;

		[SerializeField]
		public Vector2 indicatorHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorDoCollision;

		[SerializeField]
		public bool indicatorClampToMouse;

		[SerializeField]
		public ParticleSystem maxChargeVfx;

		[Header("Hitbox")]
		[SerializeField]
		public GameObject hitboxPrefab;

		[SerializeField]
		public int flatDamage;

		[SerializeField]
		public float percentHpDamage;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("Visuals")]
		[SerializeField]
		public float orbitDistance;

		[SerializeField]
		public float orbitSpeed;

		[SerializeField]
		[Header("Properties")]
		public float jumpTime;

		[SerializeField]
		public float impulseSpeed;

		[SerializeField]
		public float impulseDeceleration;

		[SerializeField]
		public float minSpinDuration;

		[SerializeField]
		public float maxSpinDistanceDuration;

		[SerializeField]
		public float maxSpinDamageDuration;

		[SerializeField]
		public float maxSpinDuration;

		[SerializeField]
		public float cooldownDuration;

		[Header("Translation Keys")]
		[SerializeField]
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
		public Hitbox currentHitbox;

		[NonSerialized]
		public bool done;

		[NonSerialized]
		public float angle;

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

		public void SvFling(EntityManager entity)
		{
		}

		public void SvSetControllingChar(EntityManager entity)
		{
		}

		[IteratorStateMachine(typeof(_003CSpinPush_003Ed__60))]
		public IEnumerator SpinPush(EntityManager entity)
		{
			return null;
		}

		public void StartCooldown()
		{
		}

		public void Shoot(EntityManager entity, float chargeFactor)
		{
		}

		[ClientRpc]
		public void RpcResetCharHolder()
		{
		}

		public void ClStopCharSpin(EntityManager entity)
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
		public void RpcHideIndicator()
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

		public void UserCode_RpcResetCharHolder()
		{
		}

		public static void InvokeUserCode_RpcResetCharHolder(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
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

		public void UserCode_RpcHideIndicator()
		{
		}

		public static void InvokeUserCode_RpcHideIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static SpinPole()
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
