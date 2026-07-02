using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HittableTrap : NetworkBehaviour
	{
		[NonSerialized]
		public EntityBehaviour entityBehaviour;

		[Header("References")]
		[SerializeField]
		public Animator animator;

		[SerializeField]
		public GameObject trapAnimObj;

		[SerializeField]
		public SpriteRenderer ringRenderer;

		[SerializeField]
		public GameObject resetVfxObj;

		[Header("Anim States")]
		[SerializeField]
		public string idleState;

		[SerializeField]
		public string activateState;

		[SerializeField]
		public string cooldownState;

		[SerializeField]
		public string resetState;

		[NonSerialized]
		public float cooldownDuration;

		[SyncVar(hook = "OnCooldownChanged")]
		[NonSerialized]
		public float cooldown;

		[NonSerialized]
		public bool prevCd;

		[NonSerialized]
		public bool triggeredDeactivate;

		public Action<float, float> _Mirror_SyncVarHookDelegate_cooldown;

		public float Networkcooldown
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

		public void OnDestroy()
		{
		}

		public void SetCooldown(float cd)
		{
		}

		public void OnActivate()
		{
		}

		public void OnReset()
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

		public void SetProgressRing(float percentage)
		{
		}

		public void OnCooldownChanged(float oldValue, float newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
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

		static HittableTrap()
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
