using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TransformLookAtTarget : NetworkBehaviour
	{
		[SyncVar]
		public Transform target;

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

		public void Update()
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
