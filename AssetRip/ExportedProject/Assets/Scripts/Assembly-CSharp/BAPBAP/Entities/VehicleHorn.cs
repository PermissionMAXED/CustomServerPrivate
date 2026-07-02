using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(Vehicle))]
	public class VehicleHorn : NetworkBehaviour
	{
		[NonSerialized]
		public Vehicle vehicle;

		[SerializeField]
		[Header("References")]
		public AudioSource hornAudioSource;

		[SerializeField]
		public GameObject hornFxHolder;

		[Header("Settings")]
		[SerializeField]
		public KeyCode hornKey;

		[SerializeField]
		[Tooltip("Is the horn state controlled by an on/off toggle?")]
		public bool isToggleHorn;

		[ConditionalInverseHide("isToggleHorn", true)]
		[Tooltip("Is the horn abled to be sustained on held, or only a single time?")]
		[SerializeField]
		public bool isHoldHorn;

		[SyncVar(hook = "OnHornActionedChanged")]
		[NonSerialized]
		public bool hornActioned;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_hornActioned;

		public bool NetworkhornActioned
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

		public override void OnValidate()
		{
		}

		public void Awake()
		{
		}

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void ClDriverHornInput()
		{
		}

		[Command]
		public void CmdSendVehicleHornAuth(bool isActioned)
		{
		}

		[ClientRpc]
		public void RpcActionHorn()
		{
		}

		[Client]
		public void ClActionHorn()
		{
		}

		public void OnHornActionedChanged(bool oldValue, bool newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_CmdSendVehicleHornAuth__Boolean(bool isActioned)
		{
		}

		public static void InvokeUserCode_CmdSendVehicleHornAuth__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcActionHorn()
		{
		}

		public static void InvokeUserCode_RpcActionHorn(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static VehicleHorn()
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
