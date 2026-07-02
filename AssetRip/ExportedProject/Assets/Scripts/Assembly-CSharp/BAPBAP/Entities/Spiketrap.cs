using System;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Spiketrap : NetworkBehaviour
	{
		[SerializeField]
		[Header("References")]
		public EntityActivateBase[] activations;

		[SerializeField]
		public GameObject spikes;

		[SerializeField]
		public bool startTimerDuration;

		[SerializeField]
		public bool doTimer;

		[SerializeField]
		[Min(0f)]
		public float spikeDuration;

		[Min(0f)]
		[SerializeField]
		public float spikeAnimTime;

		[SerializeField]
		[Min(0f)]
		public float loopDuration;

		[Min(0f)]
		[SerializeField]
		public float startDelay;

		[SerializeField]
		public AudioClipData upAudio;

		[SerializeField]
		public AudioClipData downAudio;

		[SerializeField]
		public AnimationCurve jumpLerpCurve;

		[NonSerialized]
		public Vector3 spikeDownPos;

		[NonSerialized]
		public Vector3 spikeUpPos;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float spikeTimer;

		[NonSerialized]
		public float clientTimer;

		[SyncVar(hook = "OnUpChanged")]
		[NonSerialized]
		public bool up;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_up;

		public bool Networkup
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

		public void Start()
		{
		}

		public void FixedUpdate()
		{
		}

		public void GoUp()
		{
		}

		[ClientRpc]
		public void RpcGoUp()
		{
		}

		[ClientRpc]
		public void RpcGoDown()
		{
		}

		public void OnUpChanged(bool oldValue, bool newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcGoUp()
		{
		}

		public static void InvokeUserCode_RpcGoUp(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcGoDown()
		{
		}

		public static void InvokeUserCode_RpcGoDown(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static Spiketrap()
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
