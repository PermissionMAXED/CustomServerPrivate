using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HittableUnkillable : NetworkBehaviour
	{
		[SerializeField]
		public float respawnDuration;

		[SerializeField]
		public SpriteRenderer ringRenderer;

		[NonSerialized]
		public bool spawning;

		[NonSerialized]
		public EntityManager entityManager;

		[SyncVar(hook = "OnRespawnTimerChanged")]
		[NonSerialized]
		public float _respawnTimer;

		public Action<float, float> _Mirror_SyncVarHookDelegate__respawnTimer;

		public float Network_respawnTimer
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

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void HitTrigger(Vector3 hitDirection, int dmg, StatusEffectInfo[] statusEffects, int playerId, int teamId, Collider collider)
		{
		}

		[ServerCallback]
		public void Update()
		{
		}

		[ClientRpc]
		public void RpcResetProgressRing()
		{
		}

		public void OnRespawnTimerChanged(float oldValue, float newValue)
		{
		}

		public void SetProgressRing(float percentage)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcResetProgressRing()
		{
		}

		public static void InvokeUserCode_RpcResetProgressRing(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static HittableUnkillable()
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
