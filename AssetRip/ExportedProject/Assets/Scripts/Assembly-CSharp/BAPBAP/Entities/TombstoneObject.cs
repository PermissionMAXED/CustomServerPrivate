using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TombstoneObject : NetworkBehaviour
	{
		[Header("References")]
		[SyncVar]
		[NonSerialized]
		public int tombstoneAssetId;

		[SyncVar]
		[NonSerialized]
		public Vector3 randomDirection;

		[SyncVar]
		[NonSerialized]
		public string labelStr;

		[Header("References")]
		[SerializeField]
		public LabelElement labelElement;

		[NonSerialized]
		public TombstoneObjectView tombstoneView;

		public int NetworktombstoneAssetId
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

		public Vector3 NetworkrandomDirection
		{
			get
			{
				return default(Vector3);
			}
			[param: In]
			set
			{
			}
		}

		public string NetworklabelStr
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

		public void Initialize(int tombstoneAssetId, string labelStr)
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStopClient()
		{
		}

		[ClientRpc]
		public void RpcPlayLandingAnim()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlayLandingAnim()
		{
		}

		public static void InvokeUserCode_RpcPlayLandingAnim(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static TombstoneObject()
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
