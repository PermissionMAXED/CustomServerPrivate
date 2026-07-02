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
	public class RCDroneController : NetworkBehaviour, ICharInteractable
	{
		[CompilerGenerated]
		public sealed class _003CWaitToDestroy_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public RCDroneController _003C_003E4__this;

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
			public _003CWaitToDestroy_003Ed__40(int _003C_003E1__state)
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

		[Header("References")]
		[SerializeField]
		public VFXTeamColor vfxBlinkTeamColor;

		[SerializeField]
		public GameObject aimIndicatorObj;

		[SerializeField]
		public AB_RCDrone_SO droneAb;

		[SerializeField]
		public Animator droneAnimator;

		[SerializeField]
		[Header("Config")]
		public float camZoomOutMultiplier;

		[SerializeField]
		public Transform uiPivot;

		[SerializeField]
		public float destroyWaitTime;

		[SerializeField]
		public string droneStartAnim;

		[SerializeField]
		public string droneEndAnim;

		[SerializeField]
		public AudioClipData startSfxData;

		[SerializeField]
		public AudioClipData destroyBeginSfxData;

		[Header("Hitbox Settings")]
		[SerializeField]
		public GameObject hitboxPrefab;

		[SerializeField]
		public int dmg;

		[SerializeField]
		[Range(0f, 1f)]
		public float dmgHpPercentage;

		[Tooltip("For npc targets, only add up to this flat amount of the percentage of their maxHp to the damage. If -1, limit wont be applied")]
		[SerializeField]
		public int addDamageHpPercentageNpcsLimit;

		[SerializeField]
		public float radius;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float travelTime;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public GameObject visibleIndicatorPrefab;

		[SerializeField]
		public GameObject visibleIndicatorEnemyPrefab;

		[SyncVar(hook = "OnControllerPlayerChanged")]
		[NonSerialized]
		public PlayerManager controllerPlayer;

		[NonSerialized]
		public bool _isClient;

		[NonSerialized]
		public bool _isServer;

		[NonSerialized]
		public UIProgressBarElement currentHpProgress;

		[NonSerialized]
		public float elapsedTime;

		[NonSerialized]
		public float activeTtl;

		[NonSerialized]
		public bool destroyed;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___controllerPlayerNetId;

		public Action<PlayerManager, PlayerManager> _Mirror_SyncVarHookDelegate_controllerPlayer;

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

		public void LateUpdate()
		{
		}

		[Server]
		public void DropBomb()
		{
		}

		[Server]
		public void DoDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToDestroy_003Ed__40))]
		public IEnumerator WaitToDestroy()
		{
			return null;
		}

		[ClientRpc]
		public void RpcOnStart()
		{
		}

		[ClientRpc]
		public void RpcOnAmmoChanged(int ammo)
		{
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 position)
		{
		}

		[ClientRpc]
		public void RpcOnDestroy()
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

		public void OnAmmoChanged(int ammo)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnStart()
		{
		}

		public static void InvokeUserCode_RpcOnStart(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnAmmoChanged__Int32(int ammo)
		{
		}

		public static void InvokeUserCode_RpcOnAmmoChanged__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnVisibleIndicator__Vector3(Vector3 position)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnDestroy()
		{
		}

		public static void InvokeUserCode_RpcOnDestroy(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static RCDroneController()
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
