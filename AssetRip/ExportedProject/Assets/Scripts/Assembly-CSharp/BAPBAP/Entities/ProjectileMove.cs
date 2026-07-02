using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ProjectileMove : NetworkBehaviour
	{
		[NonSerialized]
		[SyncVar]
		public float speed;

		[NonSerialized]
		public float ttl;

		[NonSerialized]
		public float elapsedTime;

		[NonSerialized]
		public bool enableSpeedCurve;

		[NonSerialized]
		public AnimationCurve speedCurve;

		[NonSerialized]
		public HitboxBase hitbox;

		[NonSerialized]
		public bool firstFrame;

		public float Networkspeed
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

		public override void OnStartServer()
		{
		}

		public void FixedUpdate()
		{
		}

		public void ResetElapsedTime()
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
