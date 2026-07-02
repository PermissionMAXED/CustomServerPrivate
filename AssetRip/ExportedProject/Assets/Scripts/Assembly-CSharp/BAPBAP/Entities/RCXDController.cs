using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using BAPBAP.Player;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class RCXDController : NetworkBehaviour, ICharInteractable
	{
		[CompilerGenerated]
		public sealed class _003CWaitToDestroy_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public RCXDController _003C_003E4__this;

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
			public _003CWaitToDestroy_003Ed__35(int _003C_003E1__state)
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
		public Vehicle vehicle;

		[SerializeField]
		[Header("References")]
		public Collider detonateHitCollider;

		[SerializeField]
		public VFXTeamColor vfxBlinkTeamColor;

		[SerializeField]
		public AB_RCXD_SO rcxdAb;

		[Header("Config")]
		[SerializeField]
		public float destroyWaitTime;

		[SerializeField]
		[Min(0.1f)]
		public float timeUntilEnableCollider;

		[SerializeField]
		[Header("Hitbox Settings")]
		public GameObject hitboxPrefab;

		[SerializeField]
		public int dmg;

		[Range(0f, 1f)]
		[SerializeField]
		public float dmgHpPercentage;

		[Tooltip("For npc targets, only add up to this flat amount of the percentage of their maxHp to the damage. If -1, limit wont be applied")]
		[SerializeField]
		public int addDamageHpPercentageNpcsLimit;

		[SerializeField]
		public float radius;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SyncVar(hook = "OnControllerPlayerChanged")]
		[NonSerialized]
		public PlayerManager controllerPlayer;

		[NonSerialized]
		public bool _isClient;

		[NonSerialized]
		public bool _isServer;

		[NonSerialized]
		public float colliderTimer;

		[NonSerialized]
		public bool detonated;

		[NonSerialized]
		public UIProgressBarElement currentHpProgress;

		[NonSerialized]
		public float elapsedTime;

		[NonSerialized]
		public float activeTtl;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___controllerPlayerNetId;

		public Action<PlayerManager, PlayerManager> _Mirror_SyncVarHookDelegate_controllerPlayer;

		public bool Detonated => false;

		public PlayerManager NetworkcontrollerPlayer
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

		public void Start()
		{
		}

		public override void OnStartServer()
		{
		}

		public void OnDestroy()
		{
		}

		public void Initialize(PlayerManager playerController)
		{
		}

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void OnCollisionEnter(Collision collision)
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		[Server]
		public void OnDetonate()
		{
		}

		public void SpawnExplosionHitbox()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToDestroy_003Ed__35))]
		public IEnumerator WaitToDestroy()
		{
			return null;
		}

		[ClientRpc]
		public void RpcOnDetonate()
		{
		}

		public void ClApplyAuth(PlayerManager player)
		{
		}

		public void ClRemoveAuth(PlayerManager player)
		{
		}

		public void OnInteractableTriggerEnter(EntityManager entityManager)
		{
		}

		public void OnStartHovering(EntityManager entityManager)
		{
		}

		public void OnEnter(EntityManager entityManager)
		{
		}

		public void OnExit(EntityManager entityManager)
		{
		}

		public void OnInteract(EntityManager entityManager)
		{
		}

		public void OnLocalAuthPlayerChanged(EntityManager entityManager)
		{
		}

		public bool IsSelectable(EntityManager entityManager)
		{
			return false;
		}

		public EntityManager GetEntityManager()
		{
			return null;
		}

		public Transform GetTransform()
		{
			return null;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void OnControllerPlayerChanged(PlayerManager oldValue, PlayerManager newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnDetonate()
		{
		}

		public static void InvokeUserCode_RpcOnDetonate(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static RCXDController()
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
