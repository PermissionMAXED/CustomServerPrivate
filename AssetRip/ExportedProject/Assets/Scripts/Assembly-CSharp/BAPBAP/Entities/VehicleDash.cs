using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(Vehicle))]
	public class VehicleDash : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public Vehicle vehicle;

		[SerializeField]
		[Header("Dash Config")]
		public float impulseVel;

		[SerializeField]
		public float impulseDecel;

		[SerializeField]
		[Header("Settings")]
		public CommandId commandId;

		[SerializeField]
		public float castDuration;

		[SerializeField]
		public float cdDuration;

		[SerializeField]
		public AudioClipData[] dashCastSfx;

		[SerializeField]
		public GameObject dashCastVfx;

		[NonSerialized]
		public bool isDashing;

		[NonSerialized]
		public bool inCooldown;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void StartDash()
		{
		}

		public void EndDash()
		{
		}

		public void DoDash()
		{
		}

		[ClientRpc]
		public void RpcOnDashStart()
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

		public void UserCode_RpcOnDashStart()
		{
		}

		public static void InvokeUserCode_RpcOnDashStart(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static VehicleDash()
		{
		}
	}
}
