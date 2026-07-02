using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TransformExpandRadius : NetworkBehaviour
	{
		[SerializeField]
		public AnimationCurve lerpCurve;

		[SyncVar]
		[SerializeField]
		public float duration;

		[SerializeField]
		[SyncVar]
		public float targetRadius;

		[Tooltip("If enabled, dont apply scale changes on the y axis")]
		[SerializeField]
		public bool doConstantYAxis;

		[NonSerialized]
		public float startRadius;

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

		public float NetworktargetRadius
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
