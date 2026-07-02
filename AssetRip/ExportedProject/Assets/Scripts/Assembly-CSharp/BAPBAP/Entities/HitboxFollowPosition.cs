using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxFollowPosition : NetworkBehaviour
	{
		[SyncVar]
		[SerializeField]
		public Transform target;

		[SerializeField]
		public Vector3 localOffset;

		[SerializeField]
		public NetworkTransform networkTransformToDeactivate;

		public Transform Networktarget
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

		public void FixedUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
