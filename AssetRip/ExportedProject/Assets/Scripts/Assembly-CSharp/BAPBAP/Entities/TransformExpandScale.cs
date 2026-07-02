using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TransformExpandScale : NetworkBehaviour
	{
		[SerializeField]
		public AnimationCurve lerpCurve;

		[SyncVar]
		[SerializeField]
		public float duration;

		[SyncVar]
		[SerializeField]
		public Vector3 targetScale;

		[NonSerialized]
		public Vector3 startScale;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool isEnabled;

		public float Networkduration
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

		public Vector3 NetworktargetScale
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

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
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
