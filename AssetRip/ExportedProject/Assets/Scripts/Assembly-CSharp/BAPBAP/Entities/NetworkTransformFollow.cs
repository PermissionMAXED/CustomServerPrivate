using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NetworkTransformFollow : NetworkBehaviour
	{
		[NonSerialized]
		[SyncVar]
		public bool isFollowForward;

		[NonSerialized]
		[SyncVar]
		public Transform followTarget;

		[NonSerialized]
		[SyncVar]
		public Vector3 localOffset;

		public bool NetworkisFollowForward
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

		public Transform NetworkfollowTarget
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

		public Vector3 NetworklocalOffset
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

		public override void OnStartClient()
		{
		}

		public void FixedUpdate()
		{
		}

		public void LateUpdate()
		{
		}

		public void UpdateTransform()
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
