using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class EntityBehaviour : NetworkBehaviour
	{
		public struct HitInfo
		{
			public Vector3 hitDirection;

			public StatusEffectInfo[] statusEffects;

			public int playerId;

			public int teamId;
		}

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharHurtbox charHurtbox;

		[Header("Configs")]
		[SerializeField]
		public bool isHittable;

		[SerializeField]
		[ConditionalHide("isHittable", true)]
		public bool isHittableWhileOnCooldown;

		[SerializeField]
		[ConditionalHide("isHittable", true)]
		public bool onlyHitOnce;

		[ConditionalHide("isHittable", true)]
		[FormerlySerializedAs("socketTriggerHit")]
		[SerializeField]
		public bool doSocketTriggerHit;

		[SerializeField]
		public bool resetOnFreeze;

		[SerializeField]
		public bool canChangeTeamsOnHit;

		[SerializeField]
		public bool setTransformDirOnHit;

		[ConditionalHide("setTransformDirOnHit", true)]
		[SerializeField]
		public Transform customTransformForDir;

		[FormerlySerializedAs("cooldownTime")]
		[Min(0f)]
		[SerializeField]
		public float cooldownDuration;

		[SerializeField]
		[Header("Activation Events")]
		public EntityActivateBase[] onHitActivations;

		[Min(0f)]
		[FormerlySerializedAs("activateTime")]
		[SerializeField]
		public float activateDelay;

		[SerializeField]
		public EntityActivateBase[] activations;

		[SerializeField]
		[Header("Lifetime Activations")]
		public EntityActivateBase[] onStartActivations;

		[SerializeField]
		public EntityActivateBase[] onResetActivations;

		[SerializeField]
		public EntityActivateBase[] onRespawnActivations;

		[NonSerialized]
		public Action svOnActivateAction;

		[NonSerialized]
		public Action svOnResetAction;

		[NonSerialized]
		public Action<float> svOnCooldownTickAction;

		[NonSerialized]
		public Action clOnActivateAction;

		[NonSerialized]
		public Action clOnResetAction;

		[NonSerialized]
		public Action<float> clOnCooldownTickAction;

		[NonSerialized]
		public Action<bool> clOnIsActivatedAction;

		[NonSerialized]
		public bool isHitted;

		[NonSerialized]
		public HitInfo lastHit;

		[SyncVar(hook = "OnIsActivatedChanged")]
		[NonSerialized]
		public bool isActivated;

		[NonSerialized]
		public float activateTimer;

		[NonSerialized]
		[SyncVar(hook = "OnCooldownTimerChanged")]
		public float cooldownTimer;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isActivated;

		public Action<float, float> _Mirror_SyncVarHookDelegate_cooldownTimer;

		public bool IsActivated => false;

		public bool IsHitted => false;

		public bool NetworkisActivated
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

		public float NetworkcooldownTimer
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

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		[ServerCallback]
		public void DoHit(Vector3 hitDirection, int dmg, StatusEffectInfo[] statusEffects, int playerId, int teamId, Collider collider)
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		[Server]
		public void Activate()
		{
		}

		[Server]
		public void Reset()
		{
		}

		public void TriggerHit()
		{
		}

		public bool IsHittable()
		{
			return false;
		}

		public bool IsOnCooldown()
		{
			return false;
		}

		public void OnEntityRespawned()
		{
		}

		public void OnReset()
		{
		}

		[ClientRpc]
		public virtual void RpcOnHit()
		{
		}

		[ClientRpc]
		public void RpcActivate()
		{
		}

		[ClientRpc]
		public void RpcReset()
		{
		}

		public void OnCooldownTimerChanged(float oldValue, float newValue)
		{
		}

		public void OnIsActivatedChanged(bool oldValue, bool newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public virtual void UserCode_RpcOnHit()
		{
		}

		public static void InvokeUserCode_RpcOnHit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcActivate()
		{
		}

		public static void InvokeUserCode_RpcActivate(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcReset()
		{
		}

		public static void InvokeUserCode_RpcReset(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityBehaviour()
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
